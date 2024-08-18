using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlueBeldumController : Enemy
{
    private const int BELDUMHP = 5;
    private const int BELDUMATTACK = 4;
    // �p���x�B1�b�ɉ��x��]�ł��邩
    private int rotaSpeed = 60;
    // ����(���ꂪ�p�x�ŕ��������)
    private float moveSpeed = 0.8f;
    // �N������n�t���[����ɂ܂�������Ԃ悤�ɂ���
    private int lifeSpan = 600;
    // �������ǂ������Ă��邩
    Vector2 myAngleVector;

    // ��]���Ă�������
    private bool canRotate = true;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        // �U���͂�HP��ݒ�
        hitPoint = BELDUMHP;
        attack = BELDUMATTACK;
        canShoot = false; // �ꉞ�g��Ȃ��@�\�̓I�t�ɂ��Ă���
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void Move()
    {
        base.Move();
        lifeSpan--;
        if (lifeSpan > 0)
        {
            // �z�[�~���O�@�\����
            // �v���C���[�Ƃ̑��Έʒu���m�F����(����֐�)
            Vector2 relativeVec = UnitVector(PlayerController.player);
            //Debug.Log(relativeVec);
            // �������ǂ������Ă邩���x�N�g���ɂ���
            myAngleVector = GeneralAngleToVector2(transform.localEulerAngles.z - 90f);
            // �����̌����Ƃ̊p�x��x���œ��o
            float angle = Vector2.SignedAngle(myAngleVector, relativeVec);
            // �����������Ă�������Ƌ߂������ɉ�]

            // ���Ƃ͎����̌����Ă�����Ɍ������Đi��
            MoveByMyAngle();

            if (!canRotate) return; // ��]������_���Ȃ炱���ŏI��

            if (angle < 0)
            {
                // ���v���̕����߂��Ƃ�
                transform.eulerAngles -= new Vector3(0f, 0f, rotaSpeed * Time.deltaTime);
            }
            else
            {
                // �����v���̕����߂��Ƃ�
                transform.eulerAngles += new Vector3(0f, 0f, rotaSpeed * Time.deltaTime);
            }
        }
        else
        {
            // �܂��������
            MoveByMyAngle();
        }
    }

    private void MoveByMyAngle()
    {
        transform.position += (Vector3)(myAngleVector * moveSpeed * Time.deltaTime);
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
        lifeSpan = 0;
        base.OnDeath();
    }
}
