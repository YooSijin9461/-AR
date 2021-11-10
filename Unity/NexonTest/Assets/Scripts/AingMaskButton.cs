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

        // ��ư ������ �� ����
        arFaceManager = GetComponent<ARFaceManager>();
        arFaceManager.facePrefab = prefabs[0];
        Debug.Log("��������");

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
