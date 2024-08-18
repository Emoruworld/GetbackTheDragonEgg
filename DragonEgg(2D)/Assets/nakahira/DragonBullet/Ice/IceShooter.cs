using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonRace;

public class IceShooter : Shooter
{
    // ���\�[�X�t�@�C�����烍�[�h
    private GameObject iceBullet;

    // Find
    private GameObject chargeMeter;
    private PlayerChargeMeterController meter;

    private Vector3 instanceOffset = new Vector3(0, 0.3f, 0); // �␳�ł��B

    private float timer = 0; // ������
    private const float iceBulletInterval = 0.2f; // ���̒e�����������Ԋu
    private float instantiateThreshold = iceBulletInterval; // ���I�ɕς��
    private int bulletCount = 0; // �����̒e���o�����Ă��邩
    private int bulletAngle = 30; // ���x��]���邩
    private int angleOffset = 0; // ���̖��̒ʂ�
    private const int maxBulletCount = 7; // �ő剽�o���������邩
                                          // �����Ŕߕ�ł�
                                          // �r������萔�������[�L�������P�[�X�ŏ����Ă܂���
                                          // ���X�ς���܂���@
    private float meterFactor = 1 / (iceBulletInterval * maxBulletCount);
    private AudioClip se; // ���\�[�X
    private bool isPlayedSE = false; // ����̒e������SE��炵�����ǂ���

    private void Start()
    {
        Debug.Log(iceBulletInterval * maxBulletCount);
        iceBullet = (GameObject)Resources.Load("IceBullet");
        se = (AudioClip)Resources.Load("IceCharge");

        // �A�^�b�`����Ă���h���S�����E��������
        // �e�𐶐����������ς���
        // �`���[�W���[�^�[�̍��E���ς���@
        if (gameObject.name == "ChildDragonRight")
        {
            bulletAngle *= -1;
            angleOffset *= -1;
            chargeMeter = GameObject.Find("RightChargeMeter");
        }
        else
        {
            chargeMeter = GameObject.Find("LeftChargeMeter");
        }
        // �R���|�[�l���g�擾
        meter = chargeMeter.transform.GetChild(0).GetComponent<PlayerChargeMeterController>();
    }

    void Update()
    {
        if (!canShoot) return;
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

            if (!isPlayedSE) // ������ʂ�������񂾂������
            {
                // �܂��Đ�����Ă��Ȃ�������
                GameAudio.InstantiateSE(se);
                isPlayedSE = true;
            }

            if (timer > instantiateThreshold)
            {
                // ��]�𐶐�
                Quaternion bulletRotation = Quaternion.AngleAxis(bulletAngle * bulletCount + angleOffset, Vector3.forward);

                // �C���X�^���X�� �e�͎����ɂ��āA�ǔ�������
                Instantiate(iceBullet, 
                    transform.position + bulletRotation * instanceOffset, // Quaternion�Ńx�N�g������]�ł���̂��A�c��
                    bulletRotation,
                    transform);

                bulletCount++;
                // �����ł܂�Interval�b��ɐ��������悤�ɂ���
                // Timer��~�ς���������������
                instantiateThreshold = iceBulletInterval * (bulletCount + 1);
                isPlayedSE = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) // �L�[�𗣂�����
        {
            // �ړ����鏈���͒e���g�Ɏ������Ă���
            // �e�̐������Z�b�g
            bulletCount = 0;
            // �^�C�}�[�֘A�����Z�b�g
            timer = 0;
            instantiateThreshold = iceBulletInterval;
            isPlayedSE = false; // SE�t���O�����Z�b�g
        }

        Debug.Log($"�^�C�}�[{timer}");
        // ���[�^�[�`��
        Debug.Log($"���[�^�[�̗�{timer * meterFactor}");
        meter.FillMeter(timer * meterFactor);
    }
}
