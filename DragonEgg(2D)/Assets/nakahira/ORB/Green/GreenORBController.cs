using System;
using UnityEngine;

public class GreenORBController : Enemy
{

    protected float cycleSpeed = 2f; // �傫������Ή�]�������������Ȃ�A��葁���������܂��B
    protected float moveSpeedX = 2f; // �傫������΂�葁���ړ����A���a���傫���Ȃ�܂��B

    protected float angle; // �p�x�̌v�Z�Ɏg���^�C�}�[

    //�v���n�u�Ȃ̂ŃG�f�B�^�����낵��
    public GameObject bulletPrefab;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        hitPoint = 3;
        attack = 1;
        speed.y = -0.5f;
        shootSpan = 4;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void Move() // ����Update���Ŏ��s����Ă邱�Ƃ킩��Ȃ��ˁH
    {
        base.Move();
        angle += Time.deltaTime;
        speed.x = (float)Math.Cos(angle * cycleSpeed) * moveSpeedX;

        transform.Translate(speed.x * Time.deltaTime, 0f, 0f);

        // �Ȃ܂��p�����Ă邩�炱��ȏ������򂪂���c
        if (gameObject.CompareTag("Boss")) return;

        transform.Translate(0f, speed.y * Time.deltaTime, 0f);
    }

    protected override void Shoot()
    {
        base.Shoot();
        // �v���C���[�Ɍ����ċ���������
        // ����
        InstantiateBulletToAngle(bulletPrefab, UnitVector(PlayerController.player));
    }

    protected override void OnDeath()
    {
        base.OnDeath();
        canShoot = false;
        GetComponent<CircleCollider2D>().enabled = false; // �e�I�u�W�F�N�g�̃R���C�_�[���e���Ő؂邱�ƁB
    }
}