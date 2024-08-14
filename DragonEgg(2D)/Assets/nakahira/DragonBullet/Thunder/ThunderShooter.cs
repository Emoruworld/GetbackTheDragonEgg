using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderShooter : MonoBehaviour
{
    // ���\�[�X�t�@�C�����烍�[�h
    private GameObject thunderBullet;

    private Vector3 instanceOffset = new Vector3(0, 0.5f, 0); // �������甭�˂��邽�߂̕␳�ł��B

    private PlayerChargeMeterController meter;

    private float timer = 0; // ������
    private const int maxAttack = 8; // �`���[�W�ő�̍U����
    private const float maxChargeTime = 3; // �ő�З͂ɂȂ邽�߂̃`���[�W����
    private const float meterFactor = 1 / maxChargeTime; // ���[�^�[�������邽�߂̌W��
    private const float maxBulletScale = 2; // �ő�T�C�Y
    // �ő�`���[�W���Ԃōő�T�C�Y�ɂȂ��@�ȌW��
    private const float maxScaleFacter = maxBulletScale / maxChargeTime;
    private const float maxAttackFacter = maxAttack / maxChargeTime;

    private float attack = 0; // �e�̍U���́@�`���[�W�ŕϓ�

    private GameObject thunderBulletInstance; // �C���X�^���X�ۑ��p
    private GameObject thunderBulletController; // �R���|�[�l���g�ۑ��p

    private void Start()
    {
        thunderBullet = (GameObject)Resources.Load("ThunderBullet");
        // ���ꍶ�E�ŃQ�[�W�Ⴄ�̉��Ƃ��ł��Ȃ�����
        if (name == "ChildDragonRight")
        {
            meter = GameObject.Find("RightChargeMeterInside").GetComponent<PlayerChargeMeterController>();
        }
        else
        {
            meter = GameObject.Find("LeftChargeMeterInside").GetComponent<PlayerChargeMeterController>();
        }
    }

    private void Update()
    {
        // �X�y�[�X�L�[�Œe�𔭎ˁB
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))
        {
            // �e�𐶐� �e�����g�ɐݒ�
            thunderBulletInstance = Instantiate(thunderBullet,
                transform.position + instanceOffset,
                Quaternion.identity,
                transform);
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) // Space�L�[��������
        {
            timer += Time.deltaTime; // �����̂��Ƃ��^�C�}�[�v��
            // �ő傽�ߎ��ԂɒB������}����
            if (timer > maxChargeTime)
            {
                timer = maxChargeTime;
            }

            // �^�C�}�[�ɉ����ăT�C�Y��ύX
            thunderBulletInstance.transform.localScale = new Vector3(
                timer * maxScaleFacter,
                timer * maxScaleFacter,
                1);

            // �^�C�}�[�ɉ����čU���͂�ύX
            attack = timer * maxAttackFacter;
            // �U���͌v�Z�������������t���[���s��
            // �`�F�[���\�[�݂����ɂȂ�
            thunderBulletInstance.GetComponent<ThunderBulletController>().SetAttack((int)attack);
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) // �L�[�𗣂�����
        {
            // �e����(�e�q����)
            thunderBulletInstance.transform.parent = null;
            // ���̃`���[�W���Ԃɑ������U���͂ƒe�T�C�Y�ŕ��o�����@
            timer = 0;
        }

        // ���t���[���Q�[�W�`��
        meter.FillMeter(timer * meterFactor);
    }
}
