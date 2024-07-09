using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss_ORBController : ORBController // �p��
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        hitPoint = 100;
        shootSpan = 0.3f;
        attack = 5;
    }

    // �����֘A�̏�����ORB�Ɠ���

    private void OnDestroy() // ���񂾂Ƃ��A�N���A��ʂ�
    {
        SceneManager.LoadScene("ClearScene"); // OnDestroy�ł̓R���[�`���g���Ȃ��񂩂�
    }

    protected override void OnDeath()
    {
        base.OnDeath();
        canMove = false; // �e��ORB�X�N���v�g��canShoot��false�ɂ��Ă܂��B
    }
}
