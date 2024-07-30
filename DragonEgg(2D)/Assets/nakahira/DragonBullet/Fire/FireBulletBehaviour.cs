using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBulletBehaviour : MonoBehaviour
{
    // ���\�[�X�t�@�C�����烍�[�h
    private GameObject playerRapidBullet;
    private GameObject playerFireBullet;

    private Vector3 instanceOffset = new Vector3(0, 0.3f, 0); // �������甭�˂��邽�߂̕␳�ł��B

    private const float fireInterval = 0.2f; // ���˂���܂ł̒���������
    private const float srowFireRate = 0.1f; // ���ˊԊu
    private float fireTimer = -fireInterval; // �����l��fireInterval�����炵�Ă���

    private int attack = 0;

    private void Start()
    {
        playerFireBullet = (GameObject)Resources.Load("PlayerFire");
        playerRapidBullet = (GameObject)Resources.Load("PlayerRapidBullet");

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
            // ����͋����đ����r�[�����o��
            // ���������Ă���ƍL�͈͂ɍL���鉊���o��
            // �����̌��݈ʒu�ɒe�̃v���n�u������
            GameObject bullet = Instantiate(playerRapidBullet, transform.position + instanceOffset, Quaternion.identity);
            // �����̍U���͂���悹
            bullet.GetComponent<PlayerBullet>().AttackCalc(attack);
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) // Space�L�[��������
        {
            fireTimer += Time.deltaTime;
            if (fireTimer > srowFireRate) // fireRate�b�Ɉ�񉊂����˂����
            {
                GameObject bullet = Instantiate(playerFireBullet, transform.position + instanceOffset, Quaternion.identity);
                // �����̍U���͂���悹
                bullet.GetComponent<PlayerBullet>().AttackCalc(attack);
                fireTimer = 0; // �^�C�}�[���Z�b�g
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) // �L�[�𗣂�����
        {
            fireTimer = -fireInterval; // fireTimer�̏����l��fireInterval�����炵�Ă���
        }
    }
}
