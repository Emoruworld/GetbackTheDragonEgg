using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCameraController : MonoBehaviour
{
    // ボスのｙ座標でーす
    public const int BOSSPOINT = 29;

    public static Vector2 cameraSpeed = Vector2.zero;// カメラの移動スピード

    public static GameObject mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        // 動き出す
        cameraSpeed = new Vector2(0, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(cameraSpeed * Time.deltaTime);
        if (transform.position.y > BOSSPOINT) // ボス戦で止まる
        {
            cameraSpeed = Vector2.zero;
        }
    }
}
