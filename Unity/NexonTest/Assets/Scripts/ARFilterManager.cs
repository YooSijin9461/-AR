using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ARFilterManager : MonoBehaviour
{
  
    public GameObject parentUI; // 부모 객체
    public GameObject filterItem; //추가할 요소
    // Start is called before the first frame update
    void Start()
    {

    // 빌드 세팅에 올라간 씬 목록 가져오기
    // int sceneCount = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;     
    // string[] scenes = new string[sceneCount];
    // for( int i = 0; i < sceneCount; i++ )
    // {
    //     scenes[i] = System.IO.Path.GetFileNameWithoutExtension( UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex( i ) );
    //     Debug.Log(i + " :" + scenes[i]);
    // }

    DirectoryInfo dir = new DirectoryInfo(Application.dataPath + "/Scenes/SceneTypeOne");
    FileInfo[] info = dir.GetFiles("*.unity");
    foreach (FileInfo f in info){
      // Scene이름.unity에서 .unity를 때는 작업.
      Debug.Log(f.Name+" @@@@@@@@@@@@"+f.Name.ToString().Substring(0, f.Name.ToString().LastIndexOf(".")));
    }

    // 파일 길이 만큼 AssetItem 생성
    foreach (FileInfo f in info){
      GameObject child = Instantiate(filterItem);
      

      child.transform.SetParent(parentUI.transform);
      // 버튼 내 text 변경
      child.GetComponentInChildren<Text>().text = f.Name.ToString().Substring(0, f.Name.ToString().LastIndexOf("."));
      // GameObject textObject = child.transform.FindChild("Text").gameObject;
      // Text text = textObject.transform.GetChild(0);
      // textObject.getComponent<Text>().text = "hahah";

    }

    // GameObject filterItemPrefab;
    // foreach (FileInfo f in info){
    //   filterItemPrefab = Resources.Load<GameObject>("FilterItem");
    //   if (filterItemPrefab ==null)
    //   {
    //       Debug.Log("filterItemPrefab==null"); 
    //   }
    // }
  }

    // Update is called once per frame
    void Update()
    {
        
    }
}
