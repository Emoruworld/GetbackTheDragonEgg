using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeldumController : Enemy
{
    private const int BELDUMHP = 2;
    private const int BELDUMATTACK = 2;
    // �p���x�B��b�Ԃɉ��x��]�ł��邩
    private int rotaSpeed = 60;
    // ���݂̓��̈ʒu�B�����̉�������0��
    private int angle = 0;
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
        // �v���C���[�Ƃ̑��Έʒu���m�F����
        Vector2 relativePos = UnitVector(PlayerController.player);
        // �p�x�𓱏o
        //Mathf.Atan2();
        // �����������Ă�������Ƌ߂������ɉ�]
        // �p���x*��t���[���̎��Ԃ������
        transform.Rotate(0f, 0f, rotaSpeed * Time.deltaTime);
        transform.Translate(0f,0.1f,0f);
    }
}
