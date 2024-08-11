using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBulletController : PlayerBullet
{
    private const int ICEATTACK= 1;

    private bool isStay = true;

    [SerializeField] // �G�f�B�^
    private AudioClip generateSoundEffect; // ��������SE

    private void Awake()
    {
        baseAttack = ICEATTACK;
    }

    protected override void Start()
    {
        base.Start();
        AudioSource.PlayClipAtPoint(generateSoundEffect, transform.position);
    }

    protected override void Update()
    {
        // �L�[���͂̏���������
        if (Input.GetKeyUp(KeyCode.Space))
        {
            // iceShooter���X�y�[�X�L�[�������Œe�𐶐����Ă���̂�
            // ������͗����Ĕ��˂̏���������
            // �������邱�Ƃ�Shooter����Instantiate���������̃I�u�W�F�N�g��
            // Shooter���L�����Ȃ��Ă����@
            isStay = false;
            // �e�q����
            transform.parent = null;
        }

        if (isStay)
        {
            // �ҋ@���̓R�h���h���S���ɂ��Ă���
            // ���E�œ������Ⴄ����ǂ����悤��
            // �ړ��̃X�N���v�g�������Ɋۂ��Ə������Ƃ��ł��邪
            // �h���S�����Őe�q�o�^����
            // �������ŉ��������炢���̂ł́H�@
            // �܂肱���ł͉������Ȃ�
        }
        else
        {
            // ���ʂɐi��
            // ��ʊO�ŏ����鏈����Update�ōs���Ă���̂�
            // isStay���L���Ȃ��ʊO�ŏ����Ȃ��@
            base.Update();
        }
    }
}
