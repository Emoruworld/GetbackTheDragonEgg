using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �r�[��������transform��localScale���������ĕό`���Ă��܂��B
// ����ɂ��r�[���̊�ꕔ���̕ό`��������邽�߂�
// �X�v���C�g��X�N���v�g�𕪊�����K�v����������ł��ˁB�@
public class BeamBaseController : MonoBehaviour
{
    private Vector3 beamOffset = new Vector3(0, 0.5f, 0);

    private float beamLifeSpan = 2; // �r�[���̎���

    public GameObject myParent; // �ǔ��� HadouShooter���璼�ڂ�������Ⴈ��

    // Update is called once per frame
    void Update()
    {
        // �v���C���[�̌����ɒǔ�����
        // �v���C���[�̎q�I�u�W�F�N�g�ɂ����
        // �R���C�_�[�֘A�ŕs�s�����o�邽��
        transform.position = myParent.transform.position + beamOffset;

        // ��莞�Ԃ��������������
        if (beamLifeSpan < 0)
        {
            Destroy(gameObject);
        }

        beamLifeSpan -= Time.deltaTime; // �^�C�}�[���Z
    }
}
