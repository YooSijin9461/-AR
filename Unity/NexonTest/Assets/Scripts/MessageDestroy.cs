using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageDestroy : MonoBehaviour
{
    public Text message;
    // Start is called before the first frame update
    void Delay()
    {
        Destroy(message);
    }
    void Start()
    {
        Invoke("Delay", 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
