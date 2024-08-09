using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBulletController : PlayerBullet
{
    private const int ICEATTACK= 1;

    private const float speedX = 1;
    private const float speedY = 1;

    public float angle = 0;

    protected override void Start()
    {
        base.Start();
        baseAttack = ICEATTACK;

        // �����ŃX�s�[�h��0��
        Stop();
    }

    protected override void Update()
    {
        base.Update();

        // �L�[���͂̏���������
        if (Input.GetKeyUp(KeyCode.Space))
        {
            // iceShooter���X�y�[�X�L�[�������Œe�𐶐����Ă���̂�
            // ������͗����Ĕ��˂̏���������
            // �������邱�Ƃ�Shooter����Instantiate���������̃I�u�W�F�N�g��
            // Shooter���L�����Ȃ��Ă����@
            Go(angle);
        }
    }

    public void Go(float angle)
    {
        Vector2 temp = new Vector2(speedX, speedY);
        temp = Quaternion.Euler(0, 0, angle) * temp;
        bulletSpeedx = temp.x; // ����σx�N�g���ɂ����
        bulletSpeedy = temp.y;
    }
}
