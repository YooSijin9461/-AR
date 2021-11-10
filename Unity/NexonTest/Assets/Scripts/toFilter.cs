using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class toFilter : MonoBehaviour
{
    public void FilterScene(){
        SceneManager.LoadScene("SearchFilter");
    }
    public void MainScene(){
        SceneManager.LoadScene("MainScene");
    }
    public void ShareScene(){
        SceneManager.LoadScene("ShareScene");
    }
    public void CheckScene(){
        SceneManager.LoadScene("CheckScene");
    }
}
