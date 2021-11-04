using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PetSpawnerSelect: MonoBehaviour
{
    public ARRaycastManager arRaycaster;
    public GameObject[] placeObjects;
    public GameObject selectObject;

    public Button aBtn;
    public Button bBtn;
    public Button cBtn;
    public Button dBtn;


    bool redPandaState = false;
    bool penguinState = false;
    bool oxState = false;
    bool walrusState = false;

    GameObject redPandaObject;
    GameObject penguinObject;
    GameObject oxObject;
    GameObject walrusObject;
    void Awake()
    {
        aBtn.onClick.AddListener(AFilter);
        bBtn.onClick.AddListener(BFilter);
        cBtn.onClick.AddListener(CFilter);
        dBtn.onClick.AddListener(DFilter);
    }
    void AFilter()
    {
        // 버튼 눌렀을 때 할일
        selectObject = placeObjects[0];
        redPandaState = true;
        penguinState = false;
        oxState = false;
        walrusState = false;

    }
    void redPandaControl()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            // 스크린에 터치가 일어난다면
            if (arRaycaster.Raycast(touch.position, hits, TrackableType.Planes))
            {
                Pose hitPose = hits[0].pose;
                // 물체가 없으면
                if (!redPandaObject)
                {
                    redPandaObject = Instantiate(selectObject, hitPose.position, hitPose.rotation);
                }
                // 물체가 있으면
                else
                {
                    redPandaObject.transform.position = hitPose.position;
                    redPandaObject.transform.rotation = hitPose.rotation;
                }
            }

        }
    }
    void BFilter()
    {
        // 버튼 눌렀을 때 할일
        selectObject = placeObjects[1];
        redPandaState = false;
        penguinState = true;
        oxState = false;
        walrusState = false;


    }
    void penguinControl()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            // 스크린에 터치가 일어난다면
            if (arRaycaster.Raycast(touch.position, hits, TrackableType.Planes))
            {
                Pose hitPose = hits[0].pose;
                // 물체가 없으면
                if (!penguinObject)
                {
                    penguinObject = Instantiate(selectObject, hitPose.position, hitPose.rotation);
                }
                // 물체가 있으면
                else
                {
                    penguinObject.transform.position = hitPose.position;
                    penguinObject.transform.rotation = hitPose.rotation;
                }
            }

        }
    }
    void CFilter()
    {
        // 버튼 눌렀을 때 할일
        selectObject = placeObjects[2];
        redPandaState = false;
        penguinState = false;
        oxState = true;
        walrusState = false;
    }
    void oxControl()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            // 스크린에 터치가 일어난다면
            if (arRaycaster.Raycast(touch.position, hits, TrackableType.Planes))
            {
                Pose hitPose = hits[0].pose;
                // 물체가 없으면
                if (!oxObject)
                {
                    oxObject = Instantiate(selectObject, hitPose.position, hitPose.rotation);
                }
                // 물체가 있으면
                else
                {
                    oxObject.transform.position = hitPose.position;
                    oxObject.transform.rotation = hitPose.rotation;
                }
            }

        }
    }
    void DFilter()
    {
        // 버튼 눌렀을 때 할일
        selectObject = placeObjects[3];
        redPandaState = false;
        penguinState = false;
        oxState = false;
        walrusState = true;
    }


    void walrusControl()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            // 스크린에 터치가 일어난다면
            if (arRaycaster.Raycast(touch.position, hits, TrackableType.Planes))
            {
                Pose hitPose = hits[0].pose;
                // 물체가 없으면
                if (!walrusObject)
                {
                    walrusObject = Instantiate(selectObject, hitPose.position, hitPose.rotation);
                }
                // 물체가 있으면
                else
                {
                    walrusObject.transform.position = hitPose.position;
                    walrusObject.transform.rotation = hitPose.rotation;
                }
            }

        }

    }
    void isState()
    {
        if (redPandaState)
        {
            redPandaControl();
        }
        else if (penguinState)
        {
            penguinControl();
        }
        else if (oxState)
        {
            oxControl();
        }
        else if (walrusState)
        {
            walrusControl();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isState();
    }
}
