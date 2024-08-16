using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindShooter : Shooter
{
    // ���\�[�X�t�@�C�����烍�[�h
    private GameObject windBullet;

    private Vector3 instanceOffset = new Vector3(0, 0.2f, 0); // �������甭�˂��邽�߂̕␳�ł��B

    private bool isStraight = true; // �܂������ł����ɑł�(�O���f�B�E�X��Double)

    private const int angleRangeMax = 11;
    private const int angleRangeMin = -10;

    private int leftOrRight = 1;

    PlayerChargeMeterController meter;

    private void Start()
    {
        windBullet = (GameObject)Resources.Load("WindBullet");
        // ���E�ŉ��ɔ��˂���e�̌������t�ɂ��Ȃ����
        // ���ƃQ�[�W��
        if (name == "ChildDragonRight")
        {
            leftOrRight = -1;
            meter = GameObject.Find("RightChargeMeterInside").GetComponent<PlayerChargeMeterController>();
        }
        else
        {
            meter = GameObject.Find("LeftChargeMeterInside").GetComponent<PlayerChargeMeterController>();
        }
    }

    void Update()
    {
        if (!canShoot) return;
        // �X�y�[�X�L�[�Œe�𔭎ˁB
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))
        {

            // �P�����ň��e���o��
            if (isStraight)
            {
                // �p�x�����_��
                Quaternion angle = Quaternion.AngleAxis(Random.Range(angleRangeMin, angleRangeMax), Vector3.forward);
                // true�Ȃ�O�Ɍ���
                Instantiate(windBullet, transform.position + angle * instanceOffset, angle);
                isStraight = false;
                // �Q�[�W���X�C�b�`
                meter.FillMeter(1);
            }
            else
            {
                // �p�x�������_���ɂ���
                Quaternion angle = Quaternion.AngleAxis(Random.Range(80 * leftOrRight, 101 * leftOrRight), Vector3.forward);
                // false�Ȃ牡�ɂ��o����
                Instantiate(windBullet, transform.position + angle * instanceOffset, angle);
                isStraight = true;
                // �Q�[�W���X�C�b�`
                meter.FillMeter(0);
            }
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) // Space�L�[��������
        {
            // ����
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) // �L�[�𗣂�����
        {
            // ����
        }

        // �Q�[�W�ϓ����Ȃ��̂ł�������
    }
}
