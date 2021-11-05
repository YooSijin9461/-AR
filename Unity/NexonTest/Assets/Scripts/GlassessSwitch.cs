using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
public class GlassessSwitch : MonoBehaviour
{
    ARFaceManager arFaceManager;
    public new Camera camera;

    
    public GameObject[] prefabs;

    private int switchCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        arFaceManager = GetComponent<ARFaceManager>();
        arFaceManager.facePrefab = prefabs[0];
        
    }
    void SwitchFaces()
    {
        arFaceManager.facePrefab = prefabs[switchCount];
        
        
    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
            arFaceManager.facePrefab = null;
            switchCount = (switchCount + 1) % prefabs.Length;
            SwitchFaces();
        }
    }
}