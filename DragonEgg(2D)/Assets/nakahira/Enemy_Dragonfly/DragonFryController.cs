using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFryController : Enemy
{
    private const int DRAGONFRYATTACK = 1;
    private Rigidbody2D myRigid;
    // �悯��ۂ̑���
    private float DodgeForce;
    protected override void Start()
    {
        base.Start();
        attack = DRAGONFRYATTACK;
        myRigid = GetComponent<Rigidbody2D>();
    }

    protected override void Update()
    {
        base.Update();
    }

    public void Dodge()
    {
        // ���E�̂ǂ���ɂ悯�邩�B0�����A1���E
        int LeftOrRight = Random.Range(0, 1);
        if (LeftOrRight == 0)
        {
            // 0�̏ꍇ�������-1�ɋ��������Ă��炢�܂���
            LeftOrRight = -1;
        }
        // �㉺�̊p�x
        float direction = Random.Range(-30.0f, 30.0f);
        // �ړ�����x�N�g�����쐬
        Vector2 dodgeDir = new Vector2(Mathf.Cos(direction) * DodgeForce * LeftOrRight, Mathf.Sin(direction) * DodgeForce);
        // ���s
        myRigid.AddForce(dodgeDir);
    }
}