using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ARFilterManager : MonoBehaviour
{
  
  public GameObject parentUI; // 부모 객체, content
  private GameObject contentTotal; //전체
  private GameObject contentKart; //카트라이더
  public GameObject filterItem; //추가할 요소

  void Start()
    {

    contentTotal = GameObject.Find("ContentTotal").gameObject;
    contentKart = GameObject.Find("ContentKart").gameObject;

    DirectoryInfo dir = new DirectoryInfo(Application.dataPath + "/Scenes"); ///Scenes/SceneTypeOne
    FileInfo[] info = dir.GetFiles("*.unity");

    // 파일 길이 만큼 AssetItem 생성해서 Total에 넣어줌
    foreach (FileInfo f in info){
      GameObject child = Instantiate(filterItem);
      child.transform.SetParent(contentTotal.transform);
      // 버튼 내 text 변경
      child.GetComponentInChildren<Text>().text = f.Name.ToString().Substring(0, f.Name.ToString().LastIndexOf("."));
    }

    dir = new DirectoryInfo(Application.dataPath + "/Scenes/SceneTypeOne"); ///Scenes/SceneTypeOne
    info = dir.GetFiles("*.unity");

    // 파일 길이 만큼 AssetItem 생성해서 kart 넣어줌
    foreach (FileInfo f in info){
      GameObject child = Instantiate(filterItem);
      child.transform.SetParent(contentKart.transform);
      // 버튼 내 text 변경
      child.GetComponentInChildren<Text>().text = f.Name.ToString().Substring(0, f.Name.ToString().LastIndexOf("."));
    }

  }

    void Update()
    {
        
    }

    //전체 목록 출력
    public void showTotalList() {
    Debug.Log("showKartList");
    contentTotal.SetActive(true);
    contentKart.SetActive(false);
  }
    //카트 목록 출력
    public void showKartList() {
    Debug.Log("showKartList");
    contentTotal.SetActive(false);
    contentKart.SetActive(true);
  }

}
