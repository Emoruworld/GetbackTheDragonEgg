using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderBulletController : PlayerBullet
{
    private bool isStay = true; // �ŏ��͑ҋ@

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
}
