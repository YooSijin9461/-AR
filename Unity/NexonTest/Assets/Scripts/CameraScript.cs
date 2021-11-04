using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;
using UnityEngine.Windows;

public class CameraScript : MonoBehaviour
{
    public string gallery;
    static WebCamTexture cam;
    public RawImage cameraViewImage; //카메라가 보여질 화면

    void Start()
    {   
        Debug.Log("Permission check");
        if(false == UnityEngine.Android.Permission.HasUserAuthorizedPermission(UnityEngine.Android.Permission.ExternalStorageWrite))
        {
            return;
        }
        string galleryPath = string.Empty;
        string persistentDataPath = Application.persistentDataPath;
        Debug.Log(persistentDataPath);
        galleryPath = persistentDataPath.Substring(0, persistentDataPath.IndexOf("Android"))+"/DCIM/NZAR";
        Directory.CreateDirectory("NZAR");
        Debug.Log("Gallery Path: "+galleryPath);
        gallery = galleryPath;

        Invoke("CameraOn", 1f);
    }
    public void CameraOn(){
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
                Debug.Log("Find FFF Camera!: "+devices[selectedCameraIndex].name);
                cam = new WebCamTexture(devices[selectedCameraIndex].name);
                // break;
            }
        }


        //카메라 켜기
        if(selectedCameraIndex >= 0){
            // camTexture = new WebCamTexture(devices[selectedCameraIndex].name);
            cam.requestedFPS = 30; //안버벅이면 60, 버벅이면 30
            cameraViewImage.texture = cam;
            cam.Play();
        }  
    }

    // 지정한 경로( _savepath)에 PNG 파일형식으로 저장합니다.
    // private string _SavePath = @"C:\"; //경로 바꾸세요!
    int _CaptureCounter = 0; // 파일명을 위한
 
    public void TakeSnapshot()
    {
        Texture2D snap = new Texture2D(cam.width, cam.height);
        snap.SetPixels(cam.GetPixels());
        snap.Apply();
        cameraViewImage.texture = snap; //사진찍는 법(찍고 나서 아래 UI를 바꾸면 됨)

        System.IO.File.WriteAllBytes(gallery + _CaptureCounter.ToString() + ".png", snap.EncodeToPNG());
        ++_CaptureCounter;
    }
}
