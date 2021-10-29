using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera : MonoBehaviour
{
    private bool camAvailable;
    private WebCamTexture backCam;
    private Texture defaultBackground;

    // 유니티에서 카메라 화면을 띄울 raw image
    public RawImage background;
    public AspectRatioFitter fit;

//   public bool isCamFrontFacing;

  void Start() {
        defaultBackground = background.texture;
        // 장치 목록을 가져옴
        WebCamDevice[] devices = WebCamTexture.devices;

    // 카메라 없다
        if(devices.Length == 0) {
            Debug.Log("no camera detected");
            camAvailable = false;
            return;
        }

        for (int i = 0; i < devices.Length; i++)
        {
            // if(!devices[i].isFrontFacing){
            if(devices[i].isFrontFacing){
                // device name0: Camera 0
                //카메라가 통채로 1개밖에 없다.
                // Debug.Log("device name"+i+": "+devices[i].name);
                backCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
            }
        }


        // 백 캠을 못찾음
        if(backCam == null){
            Debug.Log("Unable to find back camera");
            return;
        }
        backCam.Play();
        background.texture = backCam;

        // isCamFrontFacing = backCam.is
    }


    void Update()
    {
        if(!camAvailable){
            return;   
        }

        float ratio = (float)backCam.width / (float)backCam.height;
        fit.aspectRatio = ratio;

        // 텍스처 이미지가 수직으로 뒤집힌 경우
        // float scaleY = frontCam.videoVerticallyMirrored ? -1f : 1f;
        // background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        // 회전 코드인 것 같음.
        // int orient = -backCam.videoRotationAngle;
        // background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
    } 
}
