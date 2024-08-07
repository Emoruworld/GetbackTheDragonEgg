using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static GameObject player;

    private TestDragonStatus playerStatus;

    private float speed = 1f;
    private float hitPoint = 10;

    private Camera cameraComponent;

    // ビューポートの補正を定義
    private float viewOffsetRight = 0.38f;
    private float viewOffset = 0.1f;

    private Animator animator; // 自分のアニメーターコンポーネント

    [SerializeField] // Resourseファイルがゴミ屋敷になりそうなのでアウトレット接続
    private AudioClip audioClip;

    private GameObject fadePanel;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject; // これで個人情報公開できるかな
        cameraComponent = Camera.main; // カメラコンポーネント取得
        animator = GetComponent<Animator>();
        SetStatusFromData();
        fadePanel = GameObject.Find("FadePanel");
    }

    private void SetStatusFromData()
    {
        // Staticクラスから自分のデータを取得
        // これはあくまでもテスト
        BattleTeam.sParentDragonData = DragonRace.races.thunder;
        playerStatus = new TestDragonStatus("2,50,2,2,2,2,2");
        hitPoint = playerStatus.hp;
        speed = playerStatus.speed;
    }

    // Update is called once per frame
    void Update()
    {
        //左スティック
        Vector2 speedVec = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //Debug.Log("H" + Input.GetAxis("Horizontal"));
        //Debug.Log("V" + Input.GetAxis("Vertical"));

        //Debug.Log($"{speedVec}, {fadeSpeed}");

        if (hitPoint <= 0) // 死んだら
        {
            // カメラに取り残される感じで親解除
            transform.parent = null;
        }
        else
        {
            Move(speedVec, speed);
        }
    }

    private void Move(Vector2 speedVec, float speed) // 移動可能判定とかを詰め込んだ
    {
        // まず単位ベクトル化
        Vector2 generalVec = speedVec.normalized;
        // 関数で複数回使う形を変数として宣言
        float speedX = generalVec.x * speed * Time.deltaTime;
        float speedY = generalVec.y * speed * Time.deltaTime;
        // 自分の座標がカメラから出ないように制限
        Vector2 viewPos = cameraComponent.WorldToViewportPoint(transform.position);

        // 越えたら進めない
        // 右方向にはUIがあるので追加で補正する
        if (viewPos.x + viewOffsetRight < 1.0f && speedX > 0)
        {
            transform.Translate(speedX, 0f, 0f);
        }
        if (viewPos.x - viewOffset > 0f && speedX < 0)
        {
            transform.Translate(speedX, 0f, 0f);
        }
        if (viewPos.y + viewOffset < 1.0f && speedY > 0)
        {
            transform.Translate(0f, speedY, 0f);
        }
        if (viewPos.y - viewOffset > 0f && speedY < 0)
        {
            transform.Translate(0f, speedY, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject temp = collision.gameObject;
        if (temp.CompareTag("Enemy") || temp.CompareTag("Boss")) // 敵に当たったら
        {
            Damage(collision.GetComponent<Enemy>().attack);
        }
        else if (temp.CompareTag("EnemyBullet"))
        {
            Damage(collision.GetComponent<EnemyBullet>().attack);
        }
    }

    private void Damage(int attack) // hitPointはここから減らすこと
    {
        AudioSource.PlayClipAtPoint(audioClip, transform.position);

        DamageNumberGenerator.GenerateText(attack, transform.position, Color.red);
        hitPoint -= attack;
        if (hitPoint > 0) // 生きていたら
        {
            StartCoroutine(Blinking(4, 0.05f)); // 点滅
        }
        else // でなければ
        {
            animator.SetTrigger("Death"); // 脂肪モーションを再生
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

    // 死亡時の処理
    public void Death()
    {
        fadePanel.GetComponent<FadeManager>().FadeOutSwitch(12);
    }
}
