using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//�X�N���v�g��UI(�e�L�X�g�Ȃ�)�����Ƃ��͂���K�{�I�I

public class CursorManager : MonoBehaviour
{
    public RectTransform cursor;//RectTransform�^�̕ϐ�a��錾�@�쐬�����e�L�X�g�I�u�W�F�N�g���A�^�b�`���Ă���

    //�X�^�[�g�֐�
    void Start()
    {
    }

    //�A�b�v�f�[�g�֐�
    void Update()
    {
        cursor.position += new Vector3(0.1f, 0, 0);//���t���[��x���W��0.1���v���X
                                                   //
    }
}
