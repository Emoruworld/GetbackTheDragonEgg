using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class ORBController : Enemy
{

    public float cycleSpeed = 5f; // �傫������Ή�]�������������Ȃ�A��葁���������܂��B
    public float moveSpeed = 5f; // �傫������΂�葁���ړ����A���a���傫���Ȃ�܂��B

    private float angle; // �p�x�̌v�Z�Ɏg���^�C�}�[
    private float shootTimer; // �e�̔��˂𐧌䂷��^�C�}�[
    private float shootSpan = 2; // ���b�����ɒe�𔭎˂��邩

    private bool canMove = true; // �����邩
    private bool canShoot = true;  // �e���Ă邩

     //�v���n�u�Ȃ̂ŃG�f�B�^�����낵��
    public GameObject bullet;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        hitPoint = 3;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        angle += Time.deltaTime;
        shootTimer += Time.deltaTime;

        if (canMove) // �����֘A�̏���
        {
            speedx = (float)Math.Cos(angle * cycleSpeed) * moveSpeed;
            transform.Translate(speedx * Time.deltaTime, speedy * Time.deltaTime, 0f);
        }

        if (canShoot)
        {
            if (shootTimer > shootSpan)
            {
                shootTimer = 0;
                // �v���C���[�Ɍ����ċ���������
                GameObject bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity);
                bulletInstance.GetComponent<ORBBulletController>().speed = UnitVector(PlayerController.player); // Vector2��Vector3�Ԃ�����ő��v���Ȃ�
            }
        }
    }


}
