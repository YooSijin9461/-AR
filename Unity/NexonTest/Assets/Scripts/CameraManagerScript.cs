using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;
using System;
using System.IO;

public class CameraManagerScript : MonoBehaviour
{
  WebCamTexture camTexture;
  public RawImage cameraViewImage; //카메라가 보여질 화면

  // public GameObject canvasUI;
  private GameObject backgroundScrollView;
  private GameObject backgroundScrollMenu;
  private GameObject takeButton;
  private GameObject backButton;
  private GameObject shareButton;
  private GameObject saveButton;
  
  private int selectedCameraIndex = -1;


  void Start() {
    backgroundScrollView = GameObject.Find("ScrollView").gameObject;
    backgroundScrollMenu = GameObject.Find("BackgroundFolder").gameObject;
    takeButton = GameObject.Find("Take").gameObject;
    backButton = GameObject.Find("Back").gameObject;
    shareButton = GameObject.Find("Share").gameObject;
    saveButton = GameObject.Find("Save").gameObject;
      backButton.SetActive(false);
      shareButton.SetActive(false);
      saveButton.SetActive(false);
  }
  public void CameraOn() {
    Debug.Log("ON");
    //갤러리 권한
    if(!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
    {
        Permission.RequestUserPermission(Permission.ExternalStorageWrite);
    }
      //카메라 권한
    if(!Permission.HasUserAuthorizedPermission(Permission.Camera))
    {
        Permission.RequestUserPermission(Permission.Camera);
    }
    // 카메라가 없다면
    if(WebCamTexture.devices.Length == 0) {
      Debug.Log("No Camera!");
      return;
    }

    WebCamDevice[] devices = WebCamTexture.devices;

    for (int i = 0; i < devices.Length; i++){
    // 전면 카메라 찾기
          Debug.Log("Find Camera!: "+devices[i].name);
        if(devices[i].isFrontFacing){
          selectedCameraIndex = i;
          // Debug.Log("Find Camera!: "+devices[selectedCameraIndex].name);
          camTexture = new WebCamTexture(devices[selectedCameraIndex].name);
          // break;
      }
    }

    //카메라 켜기
    if(selectedCameraIndex >= 0){
      // camTexture = new WebCamTexture(devices[selectedCameraIndex].name);
      camTexture.requestedFPS = 30; //안버벅이면 60, 버벅이면 30
      cameraViewImage.texture = camTexture;


      // cameraViewImage.material.mainTexture = camTexture;
      camTexture.Play();
    }
  }

  public void CameraOff() {
    Debug.Log("OFF");
    if(camTexture != null){
      camTexture.Stop();
      WebCamTexture.Destroy(camTexture);
      camTexture = null;
    }
  }

  int _CaptureCounter = 0; // 파일명을 위한
  public void TakeSnapshot()
  {
      backgroundScrollView.SetActive(false);
      backgroundScrollMenu.SetActive(false);
      takeButton.SetActive(false);
      backButton.SetActive(true);
      shareButton.SetActive(true);
      saveButton.SetActive(true);

      Texture2D snap = new Texture2D(camTexture.width, camTexture.height);
      snap.SetPixels(camTexture.GetPixels());
      snap.Apply();
      ++_CaptureCounter;
      cameraViewImage.texture = snap; //사진찍는 법(찍고 나서 아래 UI를 바꾸면 됨)
  }

  public void returnSearchFilter()
  {
    backButton.SetActive(false);
    shareButton.SetActive(false);
    saveButton.SetActive(false);
    backgroundScrollView.SetActive(true);
    backgroundScrollMenu.SetActive(true);
    takeButton.SetActive(true);
    CameraOff();
    CameraOn();
  }


  public void SharePicture(){
    StartCoroutine("SharePictureNow");
  }
  IEnumerator SharePictureNow(){
      yield return new WaitForEndOfFrame();
      Texture2D tx = new Texture2D(camTexture.width, camTexture.height, TextureFormat.RGB24, false);
      tx.ReadPixels(new Rect(0, 0, camTexture.width, camTexture.height), 0, 0);
      tx.Apply();
      string txtdate = DateTime.Now.ToString("yyyyMMddHHmmss");
      string path = Path.Combine(Application.temporaryCachePath, txtdate+".png");
      File.WriteAllBytes(path, tx.EncodeToPNG());
      Destroy(tx);
      new NativeShare()
          .AddFile(path)
          .SetSubject("image share")
          .SetText("image")
          .Share();
  }
}
