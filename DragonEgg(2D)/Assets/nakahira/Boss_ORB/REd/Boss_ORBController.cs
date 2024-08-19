using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss_ORBController : ORBController // �p��
{
    private FadeManager fadeManager;
    private float bossTimer = 0;
    private float bossInterval = 3; // �{�X�����������Ԋu
    private float bossGap = 0.3f; // ���̎���
    private float initShootSpan;
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
        initShootSpan = shootSpan;
    }

    // �����֘A�̏�����ORB�Ɠ���
    protected override void Update()
    {
        base.Update();
        bossTimer += Time.deltaTime;
        if (bossTimer > bossInterval)
        {
            StartCoroutine(DisableShootSpan(bossGap));
            bossTimer = 0;
        }
    }

    IEnumerator DisableShootSpan(float time)
    {
        // �ꎞ�I�ɂ߂����ᒷ�����Č��ɖ߂�
        shootSpan = 10;
        yield return new WaitForSeconds(time);
        shootSpan = initShootSpan;
    }

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
