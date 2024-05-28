using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Device;

public class PlayerBullet : MonoBehaviour
{
    protected Camera cameraComponent;
    protected float bulletSpeedy = 2f; // 移動速度
    protected float bulletSpeedx = 0;
    public float attack { get; protected set; }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        cameraComponent = Camera.main;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        // 毎フレーム移動
        transform.Translate(bulletSpeedx * Time.deltaTime, bulletSpeedy * Time.deltaTime, 0f);

        // 画面外に出たら
        if (OffScreenJudgment())
        {
            Destroy(gameObject);
        }
    }
    protected bool OffScreenJudgment() // 画面内ならtrue、外ならfalse
    {
        Vector2 viewPos = cameraComponent.WorldToViewportPoint(transform.position);
        return (viewPos.y < 0 ||
                viewPos.y > 1 ||
                viewPos.x < 0 ||
                viewPos.x > 1); // これ短くならないかな
    }
}