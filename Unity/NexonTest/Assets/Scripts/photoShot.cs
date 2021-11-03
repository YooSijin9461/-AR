using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class photoShot : MonoBehaviour
{
    static WebCamTexture cam;
    bool IsPause;
    // Start is called before the first frame update
    void Start()
    {
        IsPause = false;
        transform.localScale = new Vector3((float)Screen.width, (float)Screen.height, 1);

        if(cam == null) cam = new WebCamTexture();

        GetComponent<Renderer>().material.mainTexture = cam;

        if(!cam.isPlaying) cam.Play();           
    }

    public void TakePhotoShot()
    {
        if(IsPause == false){
            Time.timeScale = 0;
            IsPause = true;
            return;
        }

        if(IsPause == true){
            Time.timeScale = 1;
            IsPause = false;
            return;
        }
    }
}
