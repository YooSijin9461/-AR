using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEngine.EventSystems;

public class ARPhotoManager : MonoBehaviour
{
    public RawImage fullScreen; //unity상에서 rawImage를 꽂아줄 것
    public Button successBtn; //성공 버튼
    public Button failBtn; //실패 버튼
    public Button videoMsgBtn;
    private Texture2D reserveImage; //임시로 보여주고 저장할 사진
    private GameObject canvasAll; //UI 전체
    private GameObject backgroundScrollView;
    private GameObject backgroundScrollMenu;
    private GameObject takeButton;
    private GameObject backButton;
    private GameObject shareButton;
    private GameObject saveButton;
    private GameObject cameraChangeButton;
    private GameObject videoChangeButton;
    private GameObject videoButton;


    void Start()
    {
        canvasAll = GameObject.Find("Canvas").gameObject;
        backgroundScrollView = GameObject.Find("ScrollView").gameObject;
        backgroundScrollMenu = GameObject.Find("BackgroundFolder").gameObject;
        takeButton = GameObject.Find("Take").gameObject;
        backButton = GameObject.Find("Back").gameObject;
        shareButton = GameObject.Find("Share").gameObject;
        saveButton = GameObject.Find("Save").gameObject;
        cameraChangeButton = GameObject.Find("CameraChange").gameObject;
        videoChangeButton = GameObject.Find("VideoChange").gameObject;
        videoButton = GameObject.Find("Video").gameObject;

        successBtn.gameObject.SetActive(false);
        failBtn.gameObject.SetActive(false);
        videoMsgBtn.gameObject.SetActive(false);
        backButton.SetActive(false);
        shareButton.SetActive(false);
        saveButton.SetActive(false);
        fullScreen.gameObject.SetActive(false);
        videoButton.SetActive(false);
        cameraChangeButton.SetActive(false);

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
        //모든 UI 날리기
        canvasAll.SetActive(false);

        // StartCoroutine("TakeSnapshotDetail");

        //흰색배경이 같이 넘어감
        // reserveImage = ScreenCapture.CaptureScreenshotAsTexture();
        // fullScreen.texture = reserveImage; 

        // 전체화면(UI까지 다나옴)
        reserveImage = new Texture2D((int)fullScreen.rectTransform.rect.width, (int)fullScreen.rectTransform.rect.height);
        reserveImage.ReadPixels(new Rect(0, 0, (int)fullScreen.rectTransform.rect.width, (int)fullScreen.rectTransform.rect.height), 0, 0);
        reserveImage.Apply();
        // ++_CaptureCounter;
        fullScreen.texture = reserveImage; //사진찍는 법(찍고 나서 아래 UI를 바꾸면 됨)

        fullScreen.gameObject.SetActive(true);
        backgroundScrollView.SetActive(false);
        backgroundScrollMenu.SetActive(false);
        takeButton.SetActive(false);
        backButton.SetActive(true);
        shareButton.SetActive(true);
        saveButton.SetActive(true);
        canvasAll.SetActive(true);
    }

    IEnumerator TakeSnapshotDetail()
    {
        yield return new WaitForEndOfFrame();
        //흰색배경이 같이 넘어감
        // reserveImage = ScreenCapture.CaptureScreenshotAsTexture();
        // fullScreen.texture = reserveImage; 

        // 전체화면(UI까지 다나옴)
        reserveImage = new Texture2D((int)fullScreen.rectTransform.rect.width, (int)fullScreen.rectTransform.rect.height);
        reserveImage.ReadPixels(new Rect(0, 0, (int)fullScreen.rectTransform.rect.width, (int)fullScreen.rectTransform.rect.height), 0, 0);
        reserveImage.Apply();
        // ++_CaptureCounter;
        fullScreen.texture = reserveImage; //사진찍는 법(찍고 나서 아래 UI를 바꾸면 됨)
    }

    public void returnToCamera()
    {
        fullScreen.gameObject.SetActive(false);
        backButton.SetActive(false);
        shareButton.SetActive(false);
        saveButton.SetActive(false);
        backgroundScrollView.SetActive(true);
        backgroundScrollMenu.SetActive(true);
        takeButton.SetActive(true);
    }
    void DelaySuccess()
    {
        successBtn.gameObject.SetActive(false);
    }
    void DelayFail()
    {
        failBtn.gameObject.SetActive(false);
    }

    public void saveImage()
    {
        try
        {
            //https://stackoverflow.com/questions/44756917/saving-screenshot-to-android-gallary-via-game/44757233
            StartCoroutine(CaptureScreenshotCoroutine(Screen.width, Screen.height));
            // 사진이 저장되었다면/실패했다면 그에 따른 안내 멘트
            successBtn.gameObject.SetActive(true);
            Invoke("DelaySuccess", 3f);
        }
        catch (System.Exception)
        {
            // 사진이 저장되었다면/실패했다면 그에 따른 안내 멘트
            failBtn.gameObject.SetActive(true);
            Invoke("DelayFail", 3f);
            throw;
        }

        //돌아가기는 필요 없을 듯

    }

    private IEnumerator CaptureScreenshotCoroutine(int width, int height)
    {
        yield return new WaitForEndOfFrame();
        // Texture2D tex = new Texture2D(width, height);
        // tex.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        // tex.Apply();

        yield return reserveImage;
        string path = SaveImageToGallery(reserveImage, "Name", "Description");
        Debug.Log("Picture has been saved at:\n" + path);
    }
    protected const string MEDIA_STORE_IMAGE_MEDIA = "android.provider.MediaStore$Images$Media";
    protected static AndroidJavaObject m_Activity;

    protected static string SaveImageToGallery(Texture2D a_Texture, string a_Title, string a_Description)
    {
        using (AndroidJavaClass mediaClass = new AndroidJavaClass(MEDIA_STORE_IMAGE_MEDIA))
        {
            using (AndroidJavaObject contentResolver = Activity.Call<AndroidJavaObject>("getContentResolver"))
            {
                AndroidJavaObject image = Texture2DToAndroidBitmap(a_Texture);
                return mediaClass.CallStatic<string>("insertImage", contentResolver, image, a_Title, a_Description);
            }
        }
    }

    protected static AndroidJavaObject Texture2DToAndroidBitmap(Texture2D a_Texture)
    {
        byte[] encodedTexture = a_Texture.EncodeToPNG();
        using (AndroidJavaClass bitmapFactory = new AndroidJavaClass("android.graphics.BitmapFactory"))
        {
            return bitmapFactory.CallStatic<AndroidJavaObject>("decodeByteArray", encodedTexture, 0, encodedTexture.Length);
        }
    }

    protected static AndroidJavaObject Activity
    {
        get
        {
            if (m_Activity == null)
            {
                AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                m_Activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            }
            return m_Activity;
        }
    }


    public void SharePicture()
    {
        //모든 UI 날리기
        canvasAll.SetActive(false);
        StartCoroutine("SharePictureNow");
        //모든 UI 살리기
        canvasAll.SetActive(true);
    }
    IEnumerator SharePictureNow()
    {
        yield return new WaitForEndOfFrame();

        reserveImage.Apply();
        string txtdate = DateTime.Now.ToString("yyyyMMddHHmmss");
        string path = Path.Combine(Application.temporaryCachePath, txtdate + ".png");
        File.WriteAllBytes(path, reserveImage.EncodeToPNG());
        Destroy(reserveImage);
        new NativeShare()
            .AddFile(path)
            .SetSubject("image share")
            .SetText("image")
            .Share();
    }
    public void CameraToVideo()
    {
        fullScreen.gameObject.SetActive(false);
        backButton.SetActive(false);
        shareButton.SetActive(false);
        saveButton.SetActive(false);
        backgroundScrollView.SetActive(true);
        backgroundScrollMenu.SetActive(true);
        takeButton.SetActive(false);
        videoButton.SetActive(true);
        cameraChangeButton.SetActive(true);
        videoChangeButton.SetActive(false);
    }
    public void VideoToCamera()
    {
        fullScreen.gameObject.SetActive(false);
        backButton.SetActive(false);
        shareButton.SetActive(false);
        saveButton.SetActive(false);
        backgroundScrollView.SetActive(true);
        backgroundScrollMenu.SetActive(true);
        takeButton.SetActive(true);
        videoButton.SetActive(false);
        cameraChangeButton.SetActive(false);
        videoChangeButton.SetActive(true);
    }
}