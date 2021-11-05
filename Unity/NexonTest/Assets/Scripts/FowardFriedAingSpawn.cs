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
        // ��ũ���� ��ġ�� �Ͼ�ٸ�
        if (Input.touchCount > 0)
        {
            // ��ũ�� ��ǥ�� ���� ��ǥ�� ��ȯ��
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 touchPos = new Vector2(wp.x, wp.y);

            // ������Ʈ�� ��ġ�� ������
            transform.position = touchPos;

            // ��ü�� ������
            if (!spawnObject)
            {
                spawnObject = Instantiate(placeObject, transform.position, Quaternion.identity) as GameObject;
            }
            // ��ü�� ������
            else
            {
                spawnObject.transform.position = touchPos;
            }

        }
        // ���콺 ���� ��ư�� Ŭ�� �ߴٸ�
        if (Input.GetMouseButtonDown(0))
        {
            // ��ũ�� ��ǥ�� ���� ��ǥ�� ��ȯ��
            Vector3 wp = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 touchPos = new Vector2(wp.x, wp.y);

            // ������Ʈ�� ��ġ�� ������
            transform.position = touchPos;

            // ����
            GameObject instObj = Instantiate(placeObject, transform.position, Quaternion.identity) as GameObject;

            
        }
    }
}
