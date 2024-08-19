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


        fadeManager = GameObject.Find("FadePanel").GetComponent<FadeManager>();

        string sceneName = SceneManager.GetActiveScene().name;
        switch (sceneName)
        {
            case "Battle1":
                hitPoint = 100;
                attack = 5;
                shootSpan = 0.5f;
                break;
            case "Battle2":
                hitPoint = 300;
                attack = 8;
                shootSpan = 0.3f;
                break;
            case "Battle3":
                hitPoint = 500;
                attack = 13;
                shootSpan = 0.2f;
                break;
            case "Battle4":
                hitPoint = 1000;
                attack = 15;
                shootSpan = 0.1f;
                break;
        }
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
