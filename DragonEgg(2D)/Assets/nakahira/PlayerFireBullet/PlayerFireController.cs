using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireController : PlayerBullet
{
    private const int FIREATTACK = 1; // この値にドラゴンの攻撃力を掛けるつもり
    // Start is called before the first frame update

    private void Awake()
    {
        baseAttack = FIREATTACK;
    }

    protected override void Start()
    {
        base.Start();
        bulletSpeedx = Random.Range(-1f, 1f); // ばらつかせる
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        // 少しずつ減速する
        bulletSpeedx *= 0.99f;
        bulletSpeedy *= 0.99f;

        // 速度が一定以下になっても消す
        if (bulletSpeedy < 0.8f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // 敵に当たったら炎自身も消える
    {
        if (collision.gameObject.CompareTag("Enemy") ||
            collision.gameObject.CompareTag("Boss"))
        {
            Destroy(gameObject);
        }
    }
}
