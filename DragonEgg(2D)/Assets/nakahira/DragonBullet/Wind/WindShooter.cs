using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindShooter : MonoBehaviour
{
    // ���\�[�X�t�@�C�����烍�[�h
    private GameObject windBullet;

    private Vector3 instanceOffset = new Vector3(0, 0.2f, 0); // �������甭�˂��邽�߂̕␳�ł��B

    private PlayerChargeMeterController meter;

    private void Start()
    {
        windBullet = (GameObject)Resources.Load("WindBullet");

        if (name == "ChildDragonRight")
        {
            meter = GameObject.Find("RightChargeMeter").GetComponent<PlayerChargeMeterController>();
        }
        else
        {
            meter = GameObject.Find("LeftChargeMeter").GetComponent<PlayerChargeMeterController>();
        }
    }

    private void Update()
    {
        // �X�y�[�X�L�[�Œe�𔭎ˁB
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))
        {
            //�@���ŒP�����ň��e���o��
            Instantiate(windBullet, transform.position + instanceOffset, Quaternion.identity);
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) // Space�L�[��������
        {
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) // �L�[�𗣂�����
        {
        }


    }
}
