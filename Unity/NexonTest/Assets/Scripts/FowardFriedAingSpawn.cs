using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class FowardFriedAingSpawn : MonoBehaviour
{
    public GameObject placeObject;
    GameObject spawnObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlaceObjectByTouch();
    }
    private void PlaceObjectByTouch()
    {
        // 스크린에 터치가 일어난다면
        if (Input.touchCount > 0)
        {
            // 스크린 좌표를 월드 좌표로 변환함
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 touchPos = new Vector2(wp.x, wp.y);

            // 오브젝트의 위치를 갱신함
            transform.position = touchPos;

            // 물체가 없으면
            if (!spawnObject)
            {
                spawnObject = Instantiate(placeObject, transform.position, Quaternion.identity) as GameObject;
            }
            // 물체가 있으면
            else
            {
                spawnObject.transform.position = touchPos;
            }

        }
        // 마우스 왼쪽 버튼을 클릭 했다면
        if (Input.GetMouseButtonDown(0))
        {
            // 스크린 좌표를 월드 좌표로 변환함
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 touchPos = new Vector2(wp.x, wp.y);

            // 오브젝트의 위치를 갱신함
            transform.position = touchPos;

            // 생성
            GameObject instObj = Instantiate(placeObject, transform.position, Quaternion.identity) as GameObject;

            
        }
    }
}
