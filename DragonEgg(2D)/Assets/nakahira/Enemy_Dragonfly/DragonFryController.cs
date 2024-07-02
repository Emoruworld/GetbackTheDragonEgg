using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFryController : Enemy
{
    private const int DRAGONFRYATTACK = 1;
    private const float SHOOTSPAN = 1;
    private Rigidbody2D myRigid;
    // �悯��ۂ̑���
    private float DodgeForce = 250;
    // �G�f�B�^��
    public GameObject bulletPrefab;
    protected override void Start()
    {
        base.Start();
        attack = DRAGONFRYATTACK;
        myRigid = GetComponent<Rigidbody2D>();
        shootSpan = SHOOTSPAN;
    }

    protected override void Update()
    {
        base.Update();
    }

    public void Dodge()
    {
        // ���E�̂ǂ���ɂ悯�邩�B0�����A1���E
        int LeftOrRight = 1;
        // ���[���h���W���E�ɂ�����
        if (transform.position.x > 0)
        {
            // -1�ɋ��������Ă��炢�܂���
            LeftOrRight = -1;
        }
        // �㉺�̊p�x(���W�A����)
        float direction = Random.Range(-10f, 10f) * Mathf.Deg2Rad;
        // �ړ�����x�N�g�����쐬
        Vector2 dodgeDir = new Vector2(Mathf.Cos(direction) * DodgeForce * LeftOrRight, Mathf.Sin(direction) * DodgeForce);
        // ���s
        myRigid.AddForce(dodgeDir);
    }

    protected override void Shoot()
    {
        base.Shoot();
        // �����̂悤�Ƀv���C���[�̈ʒu�ɋ���
        Vector2 playerVec = UnitVector(PlayerController.player);
        // ��������
        GameObject bulletInstance = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bulletInstance.GetComponent<DragonFryBulletController>().SetAngle(playerVec);
    }
}