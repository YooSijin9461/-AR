using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.EventSystems;

public class PetSpawnerSelect: MonoBehaviour
{
    public ARRaycastManager arRaycaster;
    public GameObject[] placeObjects;
    public GameObject selectObject;

    public Button aBtn;
    public Button bBtn;
    public Button cBtn;
    public Button dBtn;
    public Button eBtn;
    public Button fBtn;
    public Button gBtn;
    public Button hBtn;
    public Button iBtn;
    public Button jBtn;
    public Button kBtn;
    public Button lBtn;


    bool redPandaState = false;
    bool penguinState = false;
    bool oxState = false;
    bool walrusState = false;
    bool catState = false;
    bool rabbitState = false;
    bool dogState = false;
    bool flamingoState = false;
    bool hippoState = false;
    bool parrotState = false;
    bool sheepState = false;
    bool zebraState = false;

    GameObject redPandaObject;
    GameObject penguinObject;
    GameObject oxObject;
    GameObject walrusObject;
    GameObject catObject;
    GameObject rabbitObject;
    GameObject dogObject;
    GameObject flamingoObject;
    GameObject hippoObject;
    GameObject parrotObject;
    GameObject sheepObject;
    GameObject zebraObject;
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
    void Awake()
    {
        aBtn.onClick.AddListener(AFilter);
        bBtn.onClick.AddListener(BFilter);
        cBtn.onClick.AddListener(CFilter);
        dBtn.onClick.AddListener(DFilter);
        eBtn.onClick.AddListener(EFilter);
        fBtn.onClick.AddListener(FFilter);
        gBtn.onClick.AddListener(GFilter);
        hBtn.onClick.AddListener(HFilter);
        iBtn.onClick.AddListener(IFilter);
        jBtn.onClick.AddListener(JFilter);
        kBtn.onClick.AddListener(KFilter);
        lBtn.onClick.AddListener(LFilter);
    }
    void AFilter()
    {
        // 버튼 눌렀을 때 할일
        selectObject = placeObjects[0];
        redPandaState = true;
        penguinState = false;
        oxState = false;
        walrusState = false;
        catState = false;
        rabbitState = false;
        dogState = false;
        flamingoState = false;
        hippoState = false;
        parrotState = false;
        sheepState = false;
        zebraState = false;

    }
    
    void BFilter()
    {
        // 버튼 눌렀을 때 할일
        selectObject = placeObjects[1];
        redPandaState = false;
        penguinState = true;
        oxState = false;
        walrusState = false;
        catState = false;
        rabbitState = false;
        dogState = false;
        flamingoState = false;
        hippoState = false;
        parrotState = false;
        sheepState = false;
        zebraState = false;

    }
    void CFilter()
    {
        // 버튼 눌렀을 때 할일
        selectObject = placeObjects[2];
        redPandaState = false;
        penguinState = false;
        oxState = true;
        walrusState = false;
        catState = false;
        rabbitState = false;
        dogState = false;
        flamingoState = false;
        hippoState = false;
        parrotState = false;
        sheepState = false;
        zebraState = false;

    }
    void DFilter()
    {
        // 버튼 눌렀을 때 할일
        selectObject = placeObjects[3];
        redPandaState = false;
        penguinState = false;
        oxState = false;
        walrusState = true;
        catState = false;
        rabbitState = false;
        dogState = false;
        flamingoState = false;
        hippoState = false;
        parrotState = false;
        sheepState = false;
        zebraState = false;

    }
    void EFilter()
    {
        // 버튼 눌렀을 때 할일
        selectObject = placeObjects[4];
        redPandaState = false;
        penguinState = false;
        oxState = false;
        walrusState = false;
        catState = true;
        rabbitState = false;
        dogState = false;
        flamingoState = false;
        hippoState = false;
        parrotState = false;
        sheepState = false;
        zebraState = false;

    }
    void FFilter()
    {
        // 버튼 눌렀을 때 할일
        selectObject = placeObjects[5];
        redPandaState = false;
        penguinState = false;
        oxState = false;
        walrusState = false;
        catState = false;
        rabbitState = true;
        dogState = false;
        flamingoState = false;
        hippoState = false;
        parrotState = false;
        sheepState = false;
        zebraState = false;

    }
    void GFilter()
    {
        // 버튼 눌렀을 때 할일
        selectObject = placeObjects[6];
        redPandaState = false;
        penguinState = false;
        oxState = false;
        walrusState = false;
        catState = false;
        rabbitState = false;
        dogState = true;
        flamingoState = false;
        hippoState = false;
        parrotState = false;
        sheepState = false;
        zebraState = false;

    }
    void HFilter()
    {
        // 버튼 눌렀을 때 할일
        selectObject = placeObjects[7];
        redPandaState = false;
        penguinState = false;
        oxState = false;
        walrusState = false;
        catState = false;
        rabbitState = false;
        dogState = false;
        flamingoState = true;
        hippoState = false;
        parrotState = false;
        sheepState = false;
        zebraState = false;

    }
    void IFilter()
    {
        // 버튼 눌렀을 때 할일
        selectObject = placeObjects[8];
        redPandaState = false;
        penguinState = false;
        oxState = false;
        walrusState = false;
        catState = false;
        rabbitState = false;
        dogState = false;
        flamingoState = false;
        hippoState = true;
        parrotState = false;
        sheepState = false;
        zebraState = false;

    }
    void JFilter()
    {
        // 버튼 눌렀을 때 할일
        selectObject = placeObjects[9];
        redPandaState = false;
        penguinState = false;
        oxState = false;
        walrusState = false;
        catState = false;
        rabbitState = false;
        dogState = false;
        flamingoState = false;
        hippoState = false;
        parrotState = true;
        sheepState = false;
        zebraState = false;

    }
    void KFilter()
    {
        // 버튼 눌렀을 때 할일
        selectObject = placeObjects[10];
        redPandaState = false;
        penguinState = false;
        oxState = false;
        walrusState = false;
        catState = false;
        rabbitState = false;
        dogState = false;
        flamingoState = false;
        hippoState = false;
        parrotState = false;
        sheepState = true;
        zebraState = false;

    }
    void LFilter()
    {
        // 버튼 눌렀을 때 할일
        selectObject = placeObjects[11];
        redPandaState = false;
        penguinState = false;
        oxState = false;
        walrusState = false;
        catState = false;
        rabbitState = false;
        dogState = false;
        flamingoState = false;
        hippoState = false;
        parrotState = false;
        sheepState = false;
        zebraState = true;

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
                else if (IsPointerOverUIObject() == false)
                {
                    redPandaObject.transform.position = hitPose.position;
                    redPandaObject.transform.rotation = hitPose.rotation;
                }
            }
        }
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
                else if (IsPointerOverUIObject() == false)
                {
                    penguinObject.transform.position = hitPose.position;
                    penguinObject.transform.rotation = hitPose.rotation;
                }
            }

        }
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
                else if (IsPointerOverUIObject() == false)
                {
                    oxObject.transform.position = hitPose.position;
                    oxObject.transform.rotation = hitPose.rotation;
                }
            }

        }
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
                else if (IsPointerOverUIObject() == false)
                {
                    walrusObject.transform.position = hitPose.position;
                    walrusObject.transform.rotation = hitPose.rotation;
                }
            }

        }
    }
    void catControl()
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
                if (!catObject)
                {
                    catObject = Instantiate(selectObject, hitPose.position, hitPose.rotation);
                }
                // 물체가 있으면
                else if (IsPointerOverUIObject() == false)
                {
                    catObject.transform.position = hitPose.position;
                    catObject.transform.rotation = hitPose.rotation;
                }
            }

        }
    }
    void rabbitControl()
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
                if (!rabbitObject)
                {
                    rabbitObject = Instantiate(selectObject, hitPose.position, hitPose.rotation);
                }
                // 물체가 있으면
                else if (IsPointerOverUIObject() == false)
                {
                    rabbitObject.transform.position = hitPose.position;
                    rabbitObject.transform.rotation = hitPose.rotation;
                }
            }

        }
    }
    void dogControl()
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
                if (!dogObject)
                {
                    dogObject = Instantiate(selectObject, hitPose.position, hitPose.rotation);
                }
                // 물체가 있으면
                else if (IsPointerOverUIObject() == false)
                {
                    dogObject.transform.position = hitPose.position;
                    dogObject.transform.rotation = hitPose.rotation;
                }
            }

        }
    }
    void flamingoControl()
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
                if (!flamingoObject)
                {
                    flamingoObject = Instantiate(selectObject, hitPose.position, hitPose.rotation);
                }
                // 물체가 있으면
                else if (IsPointerOverUIObject() == false)
                {
                    flamingoObject.transform.position = hitPose.position;
                    flamingoObject.transform.rotation = hitPose.rotation;
                }
            }

        }
    }
    void hippoControl()
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
                if (!hippoObject)
                {
                    hippoObject = Instantiate(selectObject, hitPose.position, hitPose.rotation);
                }
                // 물체가 있으면
                else if (IsPointerOverUIObject() == false)
                {
                    hippoObject.transform.position = hitPose.position;
                    hippoObject.transform.rotation = hitPose.rotation;
                }
            }

        }
    }
    void parrotControl()
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
                if (!parrotObject)
                {
                    parrotObject = Instantiate(selectObject, hitPose.position, hitPose.rotation);
                }
                // 물체가 있으면
                else if (IsPointerOverUIObject() == false)
                {
                    parrotObject.transform.position = hitPose.position;
                    parrotObject.transform.rotation = hitPose.rotation;
                }
            }

        }
    }
    void sheepControl()
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
                if (!sheepObject)
                {
                    sheepObject = Instantiate(selectObject, hitPose.position, hitPose.rotation);
                }
                // 물체가 있으면
                else if (IsPointerOverUIObject() == false)
                {
                    sheepObject.transform.position = hitPose.position;
                    sheepObject.transform.rotation = hitPose.rotation;
                }
            }

        }
    }
    void zebraControl()
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
                if (!zebraObject)
                {
                    zebraObject = Instantiate(selectObject, hitPose.position, hitPose.rotation);
                }
                // 물체가 있으면
                else if (IsPointerOverUIObject() == false)
                {
                    zebraObject.transform.position = hitPose.position;
                    zebraObject.transform.rotation = hitPose.rotation;
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
        else if (catState)
        {
            catControl();
        }
        else if (rabbitState)
        {
            rabbitControl();
        }
        else if (dogState)
        {
            dogControl();
        }
        else if (flamingoState)
        {
            flamingoControl();
        }
        else if (hippoState)
        {
            hippoControl();
        }
        else if (parrotState)
        {
            parrotControl();
        }
        else if (sheepState)
        {
            sheepControl();
        }
        else if (zebraState)
        {
            zebraControl();
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