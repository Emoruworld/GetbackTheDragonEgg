using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;
using UnityEngine.UIElements;

public class ORBController : Enemy
{

    protected float cycleSpeed = 2f; // �傫������Ή�]�������������Ȃ�A��葁���������܂��B
    protected float moveSpeedX = 2f; // �傫������΂�葁���ړ����A���a���傫���Ȃ�܂��B

    protected float angle; // �p�x�̌v�Z�Ɏg���^�C�}�[

     //�v���n�u�Ȃ̂ŃG�f�B�^�����낵��
    public GameObject bullet;
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        hitPoint = 3;
        attack = 1;
        speed.y = -0.5f;
        shootSpan = 1;
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
        transform.Translate(speed.x * Time.deltaTime, speed.y * Time.deltaTime, 0f);
    }

    protected override void Shoot()
    {
        base.Shoot();
        // �v���C���[�Ɍ����ċ���������
        GameObject bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity);
        bulletInstance.GetComponent<ORBBulletController>().SetAngle(UnitVector(PlayerController.player)); // Vector2��Vector3�Ԃ�����ő��v���Ȃ�
    }

    protected override void OnDeath()
    {
        base.OnDeath();
        canShoot = false;
        GetComponent<CircleCollider2D>().enabled = false; // �e�I�u�W�F�N�g�̃R���C�_�[���e���Ő؂邱�ƁB
    }
}
