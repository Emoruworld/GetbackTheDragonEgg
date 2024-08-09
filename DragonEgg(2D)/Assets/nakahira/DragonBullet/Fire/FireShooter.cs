using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShooter : MonoBehaviour
{
    // ���\�[�X�t�@�C�����烍�[�h
    private GameObject playerRapidBullet;
    private GameObject playerFireBullet;
    private GameObject fireChargeMeter;
    private PlayerChargeMeterController meter;

    private Vector3 instanceOffset = new Vector3(0, 0.3f, 0); // �������甭�˂��邽�߂̕␳�ł��B
    private Vector3 meterPosition = new Vector3(550, 225, 0);

    private const float rapidFireCooldown = 0.5f; // �N�[���^�C��
    private float rapidFireTimer = rapidFireCooldown; // �ŏ��͌��Ă�
    private const float fireInterval = 0.1f; // �A�ˉ��𔭎˂���܂ł̒���������
    private const float maxFireRateTime = 10f;// �Œ��̔��ˊԊu�ɂȂ�܂ł̎���
    private const float maxFireRateTimeFactor = 1 / maxFireRateTime;// �|���Z�p
    private float shootFireRate = 0; // (�ϐ�)���ˊԊu
    private const float recoverySpeed = 5; // �Q�[�W�̉񕜌W��
    private float fireRateTimer = maxFireRateTime; // ���ˊԊu�𐧌䂷�邽�߂̃^�C�}�[
    private float fireShootTimer = -fireInterval; // �����l��fireInterval�����炵�Ă���

    private int attack = 0;

    private void Start()
    {
        playerFireBullet = (GameObject)Resources.Load("PlayerFire");
        playerRapidBullet = (GameObject)Resources.Load("PlayerRapidBullet");
        fireChargeMeter = (GameObject)Resources.Load("FireChargeMeter");

        // ���[�^�[��ݒu �Ȃ񂾂���
        GameObject tempInstance = Instantiate(fireChargeMeter, GameObject.Find("Canvas").transform);
        tempInstance.transform.SetSiblingIndex(1); // �L�����o�X�̂��������̂Ƃ���ɒu�����ƂŃt�F�[�hUI�̉���
        meter = tempInstance.transform.GetChild(0).GetComponent<PlayerChargeMeterController>();

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
        // �^�C�}�[���Z
        rapidFireTimer += Time.deltaTime;

        // �X�y�[�X�L�[�Œe�𔭎ˁB
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))
        {
            // ���˒e�̃N�[���^�C���𒴂��Ă����
            if (rapidFireTimer > rapidFireCooldown)
            {
                // �����̌��݈ʒu�ɒe�̃v���n�u������
                GameObject bullet = Instantiate(playerRapidBullet, transform.position + instanceOffset, Quaternion.identity);
                // �����̍U���͂���悹
                bullet.GetComponent<PlayerBullet>().AttackCalc(attack);
                // �N�[���^�C�����ۂ�
                rapidFireTimer = 0;
            }
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) // Space�L�[��������
        {
            fireShootTimer += Time.deltaTime;

            if (fireShootTimer < 0) return; // �����o��܂ŃQ�[�W�͏���Ȃ�

            fireRateTimer -= Time.deltaTime;

            if (fireRateTimer < 0)
            {
                // 0�����ɂȂ낤�Ƃ�����}����
                fireRateTimer = 0;
            }
            // ������fireRateTimer�ɉ�����shootFireRate��ς���
            if (fireRateTimer > 3)
            {
                shootFireRate = 0.07f;
            }
            else if (fireRateTimer > 1f)
            {
                shootFireRate = 0.2f;
            }
            else
            {
                shootFireRate = 0.3f;
            }
            Debug.Log(fireRateTimer);
            Debug.Log(shootFireRate);
            if (fireShootTimer > shootFireRate) // fireRate�b�Ɉ�񉊂����˂����
            {
                GameObject bullet = Instantiate(playerFireBullet, transform.position + instanceOffset, Quaternion.identity);
                // �����̍U���͂���悹
                bullet.GetComponent<PlayerBullet>().AttackCalc(attack);
                fireShootTimer = 0; // �^�C�}�[���Z�b�g
            }
        }
        else
        {
            // �����Ă��Ȃ��Ƃ��A�Q�[�W�񕜁B
            fireRateTimer += Time.deltaTime * recoverySpeed;
            if (fireRateTimer > maxFireRateTime)
            {
                // ���}����
                fireRateTimer = maxFireRateTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) // �L�[�𗣂�����
        {
            fireShootTimer = -fireInterval; // fireTimer�̏����l��fireInterval�����炵�Ă���
        }

        // �Ō�ɃQ�[�W��`��
        meter.FillMeter(fireRateTimer * maxFireRateTimeFactor);
    }
}
