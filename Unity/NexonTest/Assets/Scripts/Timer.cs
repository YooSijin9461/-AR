using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float total = 5.0f;
    [SerializeField] Text countDown;
    public void TakePic(){
        countDown.text = total.ToString();
        InvokeRepeating("CountDown", 0.0f, 1f);
        Invoke("Quit", 4f);
    }
    public void CountDown(){
        total -= 1.0f;
    }
    void Quit(){
        CancelInvoke("CountDown");
    }
}
