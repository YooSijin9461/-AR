using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;

public class CameraScript : MonoBehaviour
{
    static WebCamTexture cam;
    public RawImage cameraViewImage; //카메라가 보여질 화면
    // Start is called before the first frame update
    void Start()
    {
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
                cam = new WebCamTexture(devices[selectedCameraIndex].name);
                // break;
            }
        }

        //카메라 켜기
        if(selectedCameraIndex >= 0){
            // camTexture = new WebCamTexture(devices[selectedCameraIndex].name);
            cam.requestedFPS = 30; //안버벅이면 60, 버벅이면 30
            cameraViewImage.texture = cam;


            // cameraViewImage.material.mainTexture = camTexture;
            cam.Play();
        }
    }
    // For photo varibles
    // void OnGUI()
    // {
    //     // 버튼 UI를 코드상으로 생성한 후 버튼 이벤트(TakeSnapshot()) 지정
    //     if (GUI.Button(new Rect(10, 70, 300, 300), "TakeAndSave"))
    //         TakeSnapshot();

    // }

    // 지정한 경로( _savepath)에 PNG 파일형식으로 저장합니다.
    private string _SavePath = @"C:\"; //경로 바꾸세요!
    int _CaptureCounter = 0; // 파일명을 위한
 
    public void TakeSnapshot()
    {
        Texture2D snap = new Texture2D(cam.width, cam.height);
        snap.SetPixels(cam.GetPixels());
        snap.Apply();
        cameraViewImage.texture = snap;

        System.IO.File.WriteAllBytes(_SavePath + _CaptureCounter.ToString() + ".png", snap.EncodeToPNG());
        ++_CaptureCounter;
    }
}
