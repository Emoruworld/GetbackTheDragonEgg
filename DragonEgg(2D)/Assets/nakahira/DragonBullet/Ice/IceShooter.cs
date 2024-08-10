using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceShooter : MonoBehaviour
{
    // ���\�[�X�t�@�C�����烍�[�h
    private GameObject iceBullet;

    private Vector3 instanceOffset = new Vector3(0, 0.3f, 0); // �␳�ł��B

    private int attack = 0;
    private float timer = 0; // ������
    private float iceBulletInterval = 0.2f; // ���̒e�����������Ԋu
    private int bulletCount = 0; // �����̒e���o�����Ă��邩
    private int bulletAngle = 30; // ���x��]���邩
    private int angleOffset = 0; // ���̖��̒ʂ�
    private const int maxBulletCount = 7; // �ő剽�o���������邩
    // �����Ŕߕ�ł�
    // �r������萔�������[�L�������P�[�X�ŏ����Ă܂���
    // ���X�ς��Ȃ����ǁ@

    private void Start()
    {
        iceBullet = (GameObject)Resources.Load("IceBullet");

        // �A�^�b�`����Ă���h���S�����E��������
        // �e�𐶐����������ς���@
        if (gameObject.name == "ChildDragonRight")
        {
            bulletAngle *= -1;
            angleOffset *= -1;
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

            if (bulletCount >= maxBulletCount) return; // �w��ȏ�Ȃ琶�����Ȃ�

            if (timer > iceBulletInterval)
            {
                // ��]�𐶐�
                Quaternion bulletRotation = Quaternion.AngleAxis(bulletAngle * bulletCount + angleOffset, Vector3.forward);

                // �C���X�^���X�� �e�͎����ɂ��āA�ǔ�������
                GameObject instance = Instantiate(iceBullet, 
                    transform.position, 
                    bulletRotation ,
                    transform);

                // �������炵�ĉ�]���������́A
                // ��񎩕����S�ŉ�]�����Ă���
                // ���̂��ƒu�������ꏊ�ɂ��点�΂�낵�@
                instance.transform.position += bulletRotation * instanceOffset;

                bulletCount++;
                timer = 0;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) // �L�[�𗣂�����
        {
            // �ړ����鏈���͒e���g�Ɏ������Ă���
            // �e�̐������Z�b�g
            bulletCount = 0;
            timer = 0;
        }
    }
}
