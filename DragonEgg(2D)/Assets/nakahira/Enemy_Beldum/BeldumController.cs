using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BeldumController : Enemy
{
    private const int BELDUMHP = 2;
    private const int BELDUMATTACK = 2;
    // �p���x�B��t���[���ɉ��x��]�ł��邩
    private int rotaSpeed = 1;
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
        // �p�x��x���œ��o
        // float angle = Vector3.SignedAngle(relativeVec, );
        // �����������Ă�������Ƌ߂������ɉ�]
        //// �Ƃ肠�����v���C���[�̕����ɑ����ɉ�]��OK
        //transform.eulerAngles = new Vector3(0f, 0f, generalDec);
        // �p���x*��t���[���̎��Ԃ������
        //transform.Rotate(0f, 0f, rotaSpeed * Time.deltaTime);
        //transform.Translate(0f,0.1f,0f);
    }

    // �p�x���擾���Ă���̈�ʊp�̕�����Vector2�𐶐�
    // private Vector2 AngleToVector
}
