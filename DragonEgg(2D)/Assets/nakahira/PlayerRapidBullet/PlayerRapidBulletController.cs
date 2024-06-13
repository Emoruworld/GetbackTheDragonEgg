using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRapidBulletController : PlayerBullet
{
    private int RAPIDFIREATTACK = 3;�@// ���̒l�Ƀh���S���̍U���͂��|�������
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        bulletSpeedy = 10f; // �e���B��������
        bulletSpeedx = 0;
        baseAttack = RAPIDFIREATTACK;
    }

    // Update is called once per frame
    protected override void Update() // ���܂ꂽ��꒼���ɏc�����Ɉړ�����
    {
        base .Update();
    }

    private void OnTriggerEnter2D(Collider2D collision) // �{�X�ɓ��������炳�����ɏ�����
    {
        if (collision.gameObject.CompareTag("Boss"))
        {
            Destroy(gameObject);
        }
    }
}
