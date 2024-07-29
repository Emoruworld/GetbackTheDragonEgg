using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBulletBehaviour : MonoBehaviour, IDragonBullet
{ 
    // ���\�[�X�t�@�C���ŃA�^�b�`
    private GameObject playerRapidBullet;
    private GameObject playerFireBullet;

    private Vector3 instanceOffset = new Vector3(0, 0.3f, 0); // �������甭�˂��邽�߂̕␳�ł��B

    private const float fireInterval = 0.2f; // ���˂���܂ł̒���������
    private const float srowFireRate = 0.1f; // ���ˊԊu
    private float fireTimer = -fireInterval; // �����l��fireInterval�����炵�Ă���

    private void Start()
    {
        playerFireBullet = (GameObject)Resources.Load("PlayerFire");
        playerRapidBullet = (GameObject)Resources.Load("PlayerRapidBullet");
    }

    public void GetKeyDownBehaviour(int attack)
    {
        // ����͋����đ����r�[�����o��
        // ���������Ă���ƍL�͈͂ɍL���鉊���o��
        // �����̌��݈ʒu�ɒe�̃v���n�u������
        GameObject bullet = Instantiate(playerRapidBullet, transform.position + instanceOffset, Quaternion.identity);
        // �����̍U���͂���悹
        bullet.GetComponent<PlayerBullet>().AttackCalc(attack);
    }

    public void GetKeyBehaviour(int attack)
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

    public void GetKeyUpBehaviour(int attack)
    {
        fireTimer = -fireInterval; // fireTimer�̏����l��fireInterval�����炵�Ă���
    }
}
