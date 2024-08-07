using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRapidBulletController : PlayerBullet
{
    private const int RAPIDFIREATTACK = 3;　// この値にドラゴンの攻撃力を掛けるつもり
    public AudioClip rapidFireAttackSound;

    private void Awake()
    {
        baseAttack = RAPIDFIREATTACK;
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        bulletSpeedy = 10f; // 弾速。動く速さ
        bulletSpeedx = 0;
        // 音鳴らす
        AudioSource.PlayClipAtPoint(rapidFireAttackSound, transform.position);
    }

    // Update is called once per frame
    protected override void Update() // 生まれたら一直線に縦方向に移動する
    {
        base .Update();
    }

    private void OnTriggerStay2D(Collider2D collision) // ボスに当たったらさすがに消える
    {
        if (collision.gameObject.CompareTag("Boss"))
        {
            Destroy(gameObject);
        }
    }
}
