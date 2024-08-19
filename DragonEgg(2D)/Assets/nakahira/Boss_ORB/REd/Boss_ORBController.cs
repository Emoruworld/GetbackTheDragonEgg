using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss_ORBController : ORBController // �p��
{
    private FadeManager fadeManager;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        hitPoint = 100;
        shootSpan = 0.3f;
        attack = 5;
        fadeManager = GameObject.Find("FadePanel").GetComponent<FadeManager>();
    }

    // �����֘A�̏�����ORB�Ɠ���

    protected override void OnDeath()
    {
        base.OnDeath();
        canMove = false; // �e��ORB�X�N���v�g��canShoot��false�ɂ��Ă܂��B
    }

    public void LoadClearScene(int value)
    {
        fadeManager.FadeOutSwitch(value);
    }
}
