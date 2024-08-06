using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HadouShooter : MonoBehaviour
{
    // ���\�[�X�t�@�C�����烍�[�h
    private GameObject hadouBullet;

    private Vector3 instanceOffset = new Vector3(0, 0.2f, 0); // �������甭�˂��邽�߂̕␳�ł��B

    private int attack = 0;

    private void Start()
    {
        hadouBullet = (GameObject)Resources.Load("HadouBullet");

        // Start����PlayerPrefs����U���͂��Q��
        // �����f�[�^��������Ȃ������珉���l�Ƃ���1���Z�[�u�@
        attack = PlayerPrefs.GetInt("Attack", 0);
        if (attack == 0)
        {
            attack = 1;
            PlayerPrefs.SetInt("Attack", 1);
            PlayerPrefs.Save();
        }
    }

    private void Update()
    {
        // �X�y�[�X�L�[�Œe�𔭎ˁB
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))
        {
            //�@���ŒP�����ň��e���o��
            GameObject bullet = Instantiate(hadouBullet, transform.position + instanceOffset, Quaternion.identity);
            bullet.GetComponent<PlayerBullet>().AttackCalc(attack);
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) // Space�L�[��������
        {
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) // �L�[�𗣂�����
        {
        }
    }
}
