using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class AingMaskButton : MonoBehaviour
{
    public Button aingBtn;
    ARFaceManager arFaceManager;

    public GameObject[] prefabs;


    void Awake()
    {        
        aingBtn.onClick.AddListener(AingFilter);
    }
    void AingFilter()
    {

        // 버튼 눌렀을 때 할일
        arFaceManager = GetComponent<ARFaceManager>();
        arFaceManager.facePrefab = prefabs[0];
        Debug.Log("아잉필터");

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
