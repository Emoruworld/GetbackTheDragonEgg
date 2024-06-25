using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BeldumController : Enemy
{
    private const int BELDUMHP = 2;
    private const int BELDUMATTACK = 2;
    // �p���x�B1�b�ɉ��x��]�ł��邩
    private int rotaSpeed = 120;
    // ����
    private float speed = 1f;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        // �U���͂�HP��ݒ�
        hitPoint = BELDUMHP;
        attack = BELDUMATTACK;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void Move()
    {
        base.Move();
        // �z�[�~���O�@�\����
        // �v���C���[�Ƃ̑��Έʒu���m�F����(����֐�)
        Vector2 relativeVec = UnitVector(PlayerController.player);
        Debug.Log(relativeVec);
        // �������ǂ������Ă邩���x�N�g���ɂ���
        Vector2 myAngleVector = GeneralAngleToVector2(transform.localEulerAngles.z);
        // �����̌����Ƃ̊p�x��x���œ��o
        float angle = Vector2.SignedAngle(myAngleVector, relativeVec);
        // �����������Ă�������Ƌ߂������ɉ�]
        if (angle < 0)
        {
            // ���v���̕����߂��Ƃ�
            transform.Rotate(0f, 0f, -rotaSpeed * Time.deltaTime);
        }
        else
        {
            // �����v���̕����߂��Ƃ�
            transform.Rotate(0f, 0f, rotaSpeed * Time.deltaTime);
        }
        // ���Ƃ̓v���C���[�Ɍ������Đi��
        transform.position = Vector2.MoveTowards(transform.position, PlayerController.player.transform.position, speed * Time.deltaTime);
    }

    // ���̖��̒ʂ�0�`360��P�ʃx�N�g���ɂ��܂�
    private Vector2 GeneralAngleToVector2(float angle)
    {
        Vector2 result = Vector2.one;

        result.x = Mathf.Cos(angle * Mathf.Deg2Rad);
        result.y = Mathf.Sin(angle * Mathf.Deg2Rad);

        // Debug.Log($"�֐��ŏo�Ă錋��:{result}");
        return result;
    }

    protected override void OnDeath()
    {
        // �����蔻�������
        GetComponent<CapsuleCollider2D>().enabled = false;
        canMove = false;
        base.OnDeath();
    }
}
