using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtunScript : MonoBehaviour
{
    //private Vector2 tmp;
    //public GameObject camera;
    //public static float x, y;

    //// �{�^���������ꂽ�ꍇ�A����Ăяo�����֐�

    //// Start is called before the first frame update
    //void Start()
    //{
    //    camera = GameObject.Find("CameraController");

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    tmp = GameObject.Find("Main Camera").transform.position;
    //    x = tmp.x;
    //    y = tmp.y;
    //    if (Input.GetKeyDown(KeyCode.Escape))//������ʂ��烂���X�^�[BOX��
    //    {
    //        CameraContoller.CameraMove1();

    //    }

    //    if (CameraContoller.flag == 1)
    //    {
    //        CameraContoller.powerUpCanvas.SetActive(false);
    //        CameraContoller.canvas.SetActive(true);
    //        CameraContoller.MonsterBox(y);
    //    }
    //    else if (CameraContoller.flag == 0)
    //    {
    //        CameraContoller.powerUpCanvas.SetActive(true);
    //        CameraContoller.canvas.SetActive(false);
    //    }
    //}
    public void OnClick()
    {
        Debug.Log("�����ꂽ!");  // ���O���o��
        CameraContoller.CameraMove1();
    }

}
