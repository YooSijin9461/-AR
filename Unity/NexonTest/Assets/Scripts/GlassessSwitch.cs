using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
public class GlassessSwitch : MonoBehaviour
{
    ARFaceManager arFaceManager;

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
        // foreach (ARFace face in arFaceManager.trackables)
        // {
        // face.GetComponent<MeshRenderer>().material = materials[switchCount];
        // face = prefabs[switchCount];
        // }

        switchCount = (switchCount + 1) % prefabs.Length;
        arFaceManager.facePrefab = prefabs[switchCount];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
            SwitchFaces();
        }
    }
}