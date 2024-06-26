using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Vector2 speed = Vector2.zero;

    protected Animator animator;
    protected Camera cameraComponent;

    protected float hitPoint = 1; // 体力！

    protected bool canMove = true; // 動けるか
    protected bool canShoot = true;  // 弾撃てるか

    public int attack { get; protected set; }

    protected float shootSpan = 0; // 何秒おきに球を撃つか(canShootがfalseの時は関係ない)
    protected float shootTimer = 0; // 計測する変数
    // Start is called before the first frame update
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        cameraComponent = Camera.main;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (canMove)
        {
            Move();
        }
        if (canShoot)
        {
            shootTimer += Time.deltaTime;
            if (shootTimer > shootSpan)
            {
                shootTimer = 0;
                Shoot();
            }
        }

        // 画面外に出たら
        if (OffScreenJudgment(0.2f))
        {
            // 消す
            Destroy(gameObject);
        }
    }

    protected bool OffScreenJudgment(float offset) // 画面内ならtrue、外ならfalse
    {
        // offsetは外側方向に広げるように働く
        Vector2 viewPos = cameraComponent.WorldToViewportPoint(transform.position);
        return (viewPos.y + offset < 0 ||
                   viewPos.y - offset > 1 ||
                   viewPos.x + offset < 0 ||
                   viewPos.x - offset > 1); // これ短くならないかな
    }

    protected void DestroyThisGameobject() // アニメーションイベントに献上するやつ
    {
        Destroy(gameObject);
    }

    protected Vector2 UnitVector(GameObject gameObject) // この敵から引数のオブジェクトへの単位ベクトルを生成します。
    {
        Vector3 relativeDistance = gameObject.transform.position - transform.position;
        return relativeDistance.normalized;
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision) // colisionとtrigger併用できないの本特措
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Damage(collision.gameObject.GetComponent<PlayerBullet>().finalAttack);
            return;
        }
        // もしプレイヤーに衝突したら
        if (collision.gameObject.CompareTag("Player"))
        {
            // 死
            OnDeath();
            return;
        }
    }

    protected void Damage(int attack) // hitPointはここから減らすこと
    {
        DamageNumberGenerator.GenerateText(attack, transform.position, Color.white);
        hitPoint -= attack;
        if (hitPoint <= 0)
        {
            OnDeath();
        }
    }

    protected virtual void Move() // 移動関連の処理はここに書きましょう
    {
        // カメラの移動にあわせて動いておく
        // これで派生クラスはカメラの移動を意識せずに実装できる
        transform.Translate(BattleCameraController.cameraSpeed * Time.deltaTime, Space.World);
    }
    protected virtual void Shoot() // 弾撃つ関連の処理はここに書きましょう
    {

    }

    protected virtual void OnDeath() // 自作のOnメソッドです。Hpが0になったときに実行されます。
    {
        animator.SetTrigger("Death"); // 継承したオブジェクトには必ずDeathをつけること
    }
}
