using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speedx = 1f;
    private float speedy = 1f;

    // エディタでアタッチ
    [SerializeField] private GameObject playerRapidBullet;
    [SerializeField] private GameObject cameraObject;

    private Camera cameraComponent;

    private int hitPoint = 10;

    private Coroutine blinking; // 自身が点滅中か記憶する
    // Start is called before the first frame update
    void Start()
    {
        cameraComponent = cameraObject.GetComponent<Camera>(); // カメラコンポーネント取得
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(blinking);

        // 移動！
        if (Input.GetKey(KeyCode.W))
        {
            Move(0f, speedy * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Move(-speedx * Time.deltaTime, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Move(0f, -speedy * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Move(speedx * Time.deltaTime, 0f);
        }

        // スペースキーで弾を発射
        // 初回は強くて速いビームが出る
        // 長押ししていると広範囲に広がる炎が出る
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 自分の現在位置に弾のプレハブを召喚
            Instantiate(playerRapidBullet, transform.position, Quaternion.identity);
        }
    }

    private void Move(float x, float y) // 移動可能判定とかを詰め込んだ
    {
        // 自分の座標がカメラから出ないように制限
        Vector2 viewPos = cameraComponent.WorldToViewportPoint(transform.position);
        // 移動後のx,yがビューポートの0〜1におさまってたら動いてよい
        // 壁際でも沿う方向になら進める
        if (viewPos.x + x < 1.0f && viewPos.x + x > 0f)
        {
            transform.Translate(x, 0f, 0f);
        }
        if (viewPos.y + y < 1.0f && viewPos.y + y > 0f)
        {
            transform.Translate(0f, y, 0f);
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag != "PlayerBullet") // 自分の弾以外に当たったら
    //    {
    //        hitPoint--;
    //        if (hitPoint > 0)
    //        {
    //            StartCoroutine(Blinking(4, 0.5f));
    //        }
    //        else
    //        {
    //            // HPがゼロになったら死亡アニメーションを再生してリトライ画面なりなんなり
    //        }
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "PlayerBullet") // 自分の弾以外に当たったら
        {
            hitPoint--;
            if (hitPoint > 0)
            {
                blinking = StartCoroutine(Blinking(4, 0.05f));
            }
            else
            {
                Destroy(gameObject); // 仮
                // HPがゼロになったら死亡アニメーションを再生してリトライ画面なりなんなり
            }
        }
    }

    IEnumerator Blinking(int count, float interval) // intervalは秒単位
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Color visibleColor = new Color(255, 255, 255, 255);
        Color invisibleColor = new Color(255, 255, 255, 0);
        for (int i = 0; i < count; i++) // count回繰り返す
        {
            spriteRenderer.color = invisibleColor;
            yield return new WaitForSeconds(interval); // interval秒待つ
            spriteRenderer.color = visibleColor;
            yield return new WaitForSeconds(interval); // こんなもんで　どうでしょう
        }
    }
}
