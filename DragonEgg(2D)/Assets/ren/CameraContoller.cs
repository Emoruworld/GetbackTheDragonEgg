using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraContoller : MonoBehaviour
{
    private Vector2 tmp;
    public static GameObject powerUpCanvas;
    //public static GameObject canvas;//���ƂŕύX
    public static int flag = 1;
    public GameObject camera;
    float x, y;

    // Start is called before the first frame update
    void Start()
    {
        // tmp = GameObject.Find("Main Camera").transform.position;
        powerUpCanvas = GameObject.Find("PowerUpCanvas");
        //canvas = GameObject.Find("Canvas");
        //camera = GameObject.Find("CameraController");
    }

    // Update is called once per frame
    void Update()
    {
        tmp = GameObject.Find("Main Camera").transform.position;
        x = tmp.x;
        y = tmp.y;
        //Debug.Log(y);

        if (Input.GetKeyDown(KeyCode.Escape))//������ʂ��烂���X�^�[BOX��
        {
            CameraMove1();

        }
        if (Input.GetKeyDown(KeyCode.Space) && flag != 0.0f)//�����X�^�[BOX���狭����ʂ�
        {
            CameraMove2();
        }


        if (flag == 1)
        {
            powerUpCanvas.SetActive(false);
            //canvas.SetActive(true);
            MonsterBox(y);
        }
        else if (flag == 0)
        {
            powerUpCanvas.SetActive(true);
            //canvas.SetActive(false);
        }

    }

    public static void CameraMove1()
    {
        GameObject.Find("Main Camera").transform.position = new Vector3(-80, 0, -10);
        flag = 1;
    }
    public static void CameraMove2()
    {
        GameObject.Find("Main Camera").transform.position = new Vector3(0, 0, -10);
        flag = 0;
    }

    public static void MonsterBox(float y)//�J���������ꂢ��y=0�Ŏ~�܂�Ȃ��@����I�ɂ͖��Ȃ����ǋC�ɂȂ邩�獡��C��
    {
        if (Input.GetKey(KeyCode.UpArrow) && flag != 0 && y <= 0.00f)
        {
            GameObject.Find("Main Camera").transform.position += new Vector3(0.0f, 0.01f, 0.0f); //�J��������ֈړ��B
        }
        else if (Input.GetKey(KeyCode.DownArrow) && flag != 0 && y >= -28.00f)
        {
            GameObject.Find("Main Camera").transform.position += new Vector3(0.0f, -0.01f, 0.0f); //�J���������ֈړ��B
        }
    }


    //public void OnClick()
    //{
    //    Debug.Log("�����ꂽ!");  // ���O���o��
    //    CameraMove1();
    //}
}
