using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceShooter : MonoBehaviour
{
    // ���\�[�X�t�@�C�����烍�[�h
    private GameObject iceBullet;

    private Vector3 instanceOffset = new Vector3(0, 1, 0); // �␳�ł��B

    private int attack = 0;
    private float timer = 0; // ������
    private float iceBulletInterval = 0.2f; // ���̒e�����������Ԋu
    private int bulletCount = 0; // �����̒e���o�����Ă��邩
    private int bulletAngle = 20; // ���x��]���邩

    private void Start()
    {
        iceBullet = (GameObject)Resources.Load("IceBullet");

        // �A�^�b�`����Ă���h���S�����E��������
        // �e�𐶐����������ς���@
        if (gameObject.name == "ChildDragonRight")
        {
            bulletAngle *= -1;
        }

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
            // �����Ȃ�
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) // Space�L�[��������
        {
            // ���������Ă���ƒe�����X�ɐ���
            timer += Time.deltaTime;

            if (bulletCount > 3) return; // �w��ȏ�Ȃ琶�����Ȃ�

            if (timer > iceBulletInterval)
            {
                // �C���X�^���X��
                GameObject instance = Instantiate(iceBullet, transform.position + instanceOffset, Quaternion.identity);

                // �������炵�ĉ�]���������́A
                // ��񎩕����S�ŉ�]������
                // �u�������ꏊ�ɂ��点�΂�낵�@
                Quaternion angleAxis = Quaternion.AngleAxis(bulletAngle * bulletCount, Vector3.forward);

                instance.transform.rotation *= angleAxis;

                bulletCount++;
                timer = 0;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) // �L�[�𗣂�����
        {
            // �����ƈ�Ăɔ��
            // ������e���g�Ɏ������Ă���
            bulletCount = 0;
        }
    }
}
