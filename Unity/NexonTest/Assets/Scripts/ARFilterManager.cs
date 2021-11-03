using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARFilterManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      Debug.Log("START");
    object[] scenes = Resources.LoadAll("SceneTypeOne");
    for (int i = 0; i < scenes.Length; i++)
    {
      Debug.Log(i + " :" + scenes[i]);
    }
  }

    // Update is called once per frame
    void Update()
    {
        
    }
}
