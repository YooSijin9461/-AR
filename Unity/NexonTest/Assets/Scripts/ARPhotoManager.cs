using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;
using System;
using System.IO;

public class ARPhotoManager : MonoBehaviour
{
  public new Camera camera; //unity상에서 AR 카메라를 꽂아줄 것
  public RawImage cameraSize; //unity상에서 Panel 꽂기
  private GameObject backgroundScrollView;
  private GameObject backgroundScrollMenu;
  private GameObject takeButton;
  private GameObject backButton;
  private GameObject shareButton;
  private GameObject saveButton;

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
    // //갤러리 권한
    // if(!Permission.HasUserAuthorizedPermission(Permission.ExternalStorageWrite))
    // {
    //     Permission.RequestUserPermission(Permission.ExternalStorageWrite);
    // }
    //   //카메라 권한
    // if(!Permission.HasUserAuthorizedPermission(Permission.Camera))
    // {
    //     Permission.RequestUserPermission(Permission.Camera);
    // }
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

    // camera.enabled = false;
    //문제점: set active 코드도 멈춤
    //해결1: 위 작업이 다 끝나고 진행하게

      Texture2D snap = new Texture2D((int) cameraSize.rectTransform.rect.width, (int) cameraSize.rectTransform.rect.height);
    //   snap.SetPixels(camera.);
      snap.ReadPixels(new Rect(0, 718,(int) cameraSize.rectTransform.rect.width, (int) cameraSize.rectTransform.rect.height), 0, 0);
    
      snap.Apply();
      ++_CaptureCounter;
      cameraSize.texture = snap; //사진찍는 법(찍고 나서 아래 UI를 바꾸면 됨)
  }

  public void returnSearchFilter()
  {
    backButton.SetActive(false);
    shareButton.SetActive(false);
    saveButton.SetActive(false);
    backgroundScrollView.SetActive(true);
    backgroundScrollMenu.SetActive(true);
    takeButton.SetActive(true);
    // CameraOff();
    // CameraOn();
  }


  public void SharePicture(){
    StartCoroutine("SharePictureNow");
  }
  IEnumerator SharePictureNow(){
      yield return new WaitForEndOfFrame();
      // 전체화면(UI까지 다나옴)
    //   Texture2D tx = new Texture2D(camera.pixelWidth, camera.pixelHeight, TextureFormat.RGB24, false);
    //   tx.ReadPixels(new Rect(0, 0, camera.pixelWidth, camera.pixelHeight), 0, 0);

    Texture2D tx = new Texture2D((int) (Screen.width * 1.0), (int) (Screen.height * 0.8), TextureFormat.RGB24, false);
    Debug.Log("@@@@@@@@@@@@@@@@@@@");
    Debug.Log((Screen.width * 1.0));
    Debug.Log((Screen.height * 0.8));
    Debug.Log((int)cameraSize.rectTransform.rect.width);
    Debug.Log((int)cameraSize.rectTransform.rect.height);
    Debug.Log("@@@@@@@@@@@@@@@@@@@");

    tx.ReadPixels(new Rect(0, 0,(int) cameraSize.rectTransform.rect.width, (int) cameraSize.rectTransform.rect.height), 0, 0);
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
