using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ARFilterManager : MonoBehaviour
{
  
  public GameObject parentUI; // 부모 객체, content
  private GameObject contentTotal; //전체
  private GameObject contentMaple; //메이플
  private GameObject contentCA; //크아
  private GameObject contentRest; //기타
  public GameObject filterItem; //추가할 요소

  void Start()
    {

    contentTotal = GameObject.Find("ContentTotal").gameObject;
    contentMaple = GameObject.Find("ContentMaple").gameObject;
    contentCA = GameObject.Find("ContentCA").gameObject;
    contentRest = GameObject.Find("ContentRest").gameObject;

    DirectoryInfo dir = new DirectoryInfo(Application.dataPath + "/Scenes"); ///Scenes/SceneTypeOne
    FileInfo[] info = dir.GetFiles("*.unity");

    // 파일 길이 만큼 AssetItem 생성해서 Total에 넣어줌
    /*foreach (FileInfo f in info){
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
    }*/

  }

    void Update()
    {
        
    }

    //전체 목록 출력
    public void showTotalList() {
    Debug.Log("showTotalList");
    contentTotal.SetActive(true);
    contentMaple.SetActive(false);
    contentCA.SetActive(false);
    contentRest.SetActive(false);
  }
    //메이플 목록 출력
    public void showMapleList() {
    Debug.Log("showMapleList");
    contentTotal.SetActive(false);
    contentMaple.SetActive(true);
    contentCA.SetActive(false);
    contentRest.SetActive(false);
    }

    //크아 목록 출력
    public void showCAList()
    {
        Debug.Log("showCAList");
        contentTotal.SetActive(false);
        contentMaple.SetActive(false);
        contentCA.SetActive(true);
        contentRest.SetActive(false);
    }
    //기타 목록 출력
    public void showRestList()
    {
        Debug.Log("showRestList");
        contentTotal.SetActive(false);
        contentMaple.SetActive(false);
        contentCA.SetActive(false);
        contentRest.SetActive(true);
    }
}
