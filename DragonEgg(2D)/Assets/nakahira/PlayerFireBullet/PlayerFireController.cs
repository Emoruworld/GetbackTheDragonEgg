using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireController : PlayerBullet
{
    private float FIREATTACK = 1f;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        attack = FIREATTACK;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("通った");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
