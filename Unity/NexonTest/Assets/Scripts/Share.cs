using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

public class Share : MonoBehaviour
{
    public void SharePicture(){
        StartCoroutine("SharePictureNow");
    }
    IEnumerator SharePictureNow(){
        yield return new WaitForEndOfFrame();

        Texture2D tx = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        tx.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
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
