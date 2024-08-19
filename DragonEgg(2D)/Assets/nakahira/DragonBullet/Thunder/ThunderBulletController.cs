using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderBulletController : PlayerBullet
{
    private bool isStay = true; // �ŏ��͑ҋ@s
    private AudioClip se;

    protected override void Start()
    {
        base.Start();
        se = (AudioClip)Resources.Load("�d�����@2");
    }

    protected override void Update()
    {
        // �L�[�𗣂�����
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isStay = false;
        }

        if (isStay)
        {
            // ���ƂȂ�������
        }
        else
        {
            base.Update(); // �����̓���������
        }
    }

    public void  SetAttack(int attack)
    {
        finalAttack = attack;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
        }
    }
}
