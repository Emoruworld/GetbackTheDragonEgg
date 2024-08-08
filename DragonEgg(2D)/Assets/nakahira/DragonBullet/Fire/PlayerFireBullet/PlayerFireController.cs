using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireController : PlayerBullet
{
    private const int FIREATTACK = 1; // ���̒l�Ƀh���S���̍U���͂��|�������
    // �G�f�B�^��
    // Resource�͌��ʂ��������Ȃ�
    public AudioClip audioClip;
    private void Awake()
    {
        baseAttack = FIREATTACK;
    }

    protected override void Start()
    {
        base.Start();
        bulletSpeedx = Random.Range(-1f, 1f); // �΂������
        // ���̏�ɉ���炷
        AudioSource.PlayClipAtPoint(audioClip, transform.position);
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        // �G�ɓ��������������
        GameObject g = collision.gameObject;
        if (g.CompareTag("Enemy") ||
            g.CompareTag("Boss"))
        {
            Destroy(gameObject);
        }
    }
}
