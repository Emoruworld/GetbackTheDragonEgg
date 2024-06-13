using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class CameraContoller : MonoBehaviour
{ 
    public static GameObject powerUpCanvas;
    public static GameObject icon;//���ƂŕύX
    public static int flag = 1;
    public Vector3 pos;




    //public RectTransform childDragonIcon;//RectTransform�^�̕ϐ�a��錾�@�쐬�����e�L�X�g�I�u�W�F�N�g���A�^�b�`���Ă���
    void Start()
    {
        powerUpCanvas = GameObject.Find("PowerUpCanvas");
        icon = GameObject.Find("ChildDragonIcon");
       
    }

    // Update is called once per frame
    void Update()
    {
        //���݂̈ʒu���擾
        Vector3 pos = this.gameObject.transform.position;
        
        //Transform myTransform = this.transform;
        //Vector3 Pos = Transform.position;
        //Pos.x = -80.0f; // x���W�ύX
        //Pos.y = 0.0f; // y���W�ύX
        //Pos.z = -10.0f; // z���W�ύX
        //transform.position = Pos; // �ύX��̍��W����
        Debug.Log(flag);
        //x = tmp.x;
        //y = tmp.y;
        //Debug.Log(y);

        if (flag == 0)//�Ȃ���0�ɂȂ�
        {
            CameraMove0();
            powerUpCanvas.SetActive(false);
            icon.SetActive(false);
            
        }
        if (flag == 1)
        {
            powerUpCanvas.SetActive(false);
            icon.SetActive(true);
            MonsterBox();
            CameraMove1();
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                flag = 0;
            }
        }
        if (flag == 2)
        {
            powerUpCanvas.SetActive(true);
            icon.SetActive(false);
            CameraMove2();
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                flag = 1;
            }
        }

        //�Ȃ���0�ɂȂ邭��
        //if (Input.GetKeyDown(KeyCode.Escape) && flag == 2)//������ʂ��烂���X�^�[BOX��
        //{
        //    CameraMove1();
        //}
        //if (Input.GetKeyDown(KeyCode.Escape) && flag == 1)
        //{
        //    CameraMove0();
        //}

    }
    // Start is called before the first frame update
    public static void CameraMove0()
    {
        GameObject.Find("Main Camera").transform.position = new Vector3(-160, 0, -10);
        flag = 0;
    }
    public static void CameraMove1()
    {
        GameObject.Find("Main Camera").transform.position = new Vector3(-80, 0, -10);
        flag = 1;
    }
    public static void CameraMove2()
    {
        GameObject.Find("Main Camera").transform.position = new Vector3(0, 0, -10);
        flag = 2;
    }


    public void MonsterBox()//�J���������ꂢ��y=0�Ŏ~�܂�Ȃ��@����I�ɂ͖��Ȃ����ǋC�ɂȂ邩�獡��C��
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("up");
            this.gameObject.transform.position = new Vector3(pos.x, pos.y + 0.01f, pos.z);
            //myTransform.Translate(0.0f, 0.01f, 0.0f);
            //transform.Translate(0.0f, 0.01f, 0.0f);
           // camera.transform.position += new Vector3(0.0f, 0.01f, 0.0f); //�J��������ֈړ��B
            //if (y >= 0.00f)
            //{
            //    camera.transform.position = new Vector3(-80.0f, 0.01f, -10.0f);
            //}
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("donw");
            //���݂̈ʒu����x������1�ړ�����
            this.gameObject.transform.position = new Vector3(pos.x, pos.y - 0.01f, pos.z);
            //myTransform.Translate(0.0f, -0.01f, 0.0f);
            //transform.Translate(0.0f, -0.01f, 0.0f);
            //camera.transform.position += new Vector3(0.0f, -0.01f, 0.0f); //�J���������ֈړ��B
            //if (y <= -28.00f)
            //{
            //    camera.transform.position = new Vector3(-80.0f, -28.00f, -10.0f);
            //}
        }
    }


}
