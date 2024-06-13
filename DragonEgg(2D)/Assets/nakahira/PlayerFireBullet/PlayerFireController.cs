using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireController : PlayerBullet
{
    private int FIREATTACK = 1; // ���̒l�Ƀh���S���̍U���͂��|�������
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        baseAttack = FIREATTACK;
        bulletSpeedx = Random.Range(-1f, 1f); // �΂������
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        // ��������������
        bulletSpeedx *= 0.99f;
        bulletSpeedy *= 0.99f;

        // ���x�����ȉ��ɂȂ��Ă�����
        if (bulletSpeedy < 0.8f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // �G�ɓ��������牊���g��������
    {
        if (collision.gameObject.CompareTag("Enemy") ||
            collision.gameObject.CompareTag("Boss"))
        {
            Destroy(gameObject);
        }
    }
}
