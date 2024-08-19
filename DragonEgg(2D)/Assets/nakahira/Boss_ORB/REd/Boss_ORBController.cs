using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss_ORBController : ORBController // 継承
{
    private FadeManager fadeManager;
    private float bossTimer = 0;
    private float bossInterval = 3; // ボスが情けをかける間隔
    private float bossGap = 0.3f; // その時間
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

    // 動く関連の処理はORBと同じ
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
        // 一時的にめっちゃ長くして元に戻す
        shootSpan = 10;
        yield return new WaitForSeconds(time);
        shootSpan = initShootSpan;
    }

    protected override void OnDeath()
    {
        base.OnDeath();
        canMove = false; // 親のORBスクリプトでcanShootもfalseにしてます。
    }

    public void LoadClearScene(int value)
    {
        fadeManager.FadeOutSwitch(value);
    }
}
