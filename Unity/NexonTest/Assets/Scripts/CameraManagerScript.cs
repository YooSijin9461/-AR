using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class CameraManagerScript : MonoBehaviour
{
  WebCamTexture camTexture;
  public RawImage cameraViewImage; //카메라가 보여질 화면

  public void CameraOn() {
    Debug.Log("ON");
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
    int selectedCameraIndex = -1;

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
}
