using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �h���S���̒e�̃C���^�[�t�F�[�X
// ����ς�C���^�[�t�F�[�X�̑��݈Ӌ`���悭�킩���
// �C���^�[�t�F�[�X���p�������N���X���C���^�[�t�F�[�X�̕ϐ��ɂԂ����ނƂȂ񂩂������Ƃ�����̂͂Ȃ�ƂȂ��킩����

// ���̃C���^�[�t�F�[�X���p������Monobehaviour�X�N���v�g��
// Start����AddComponent����΂����邩�I�H
public interface IDragonBullet
{
    // �X�y�[�X�L�[���������Ƃ��Ɏ��s�����ӂ�܂�
    // �����ƍׂ������������ق���������
    public void GetKeyDownBehaviour(int attack);

    public void GetKeyBehaviour(int attack);

    public void GetKeyUpBehaviour(int attack);
}
