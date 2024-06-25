using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCameraController : MonoBehaviour
{
    public const int BOSSPOINT = 15;

    public static Vector2 cameraSpeed = new Vector2(0, 0);// �J�����̈ړ��X�s�[�h
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(cameraSpeed.x * Time.deltaTime, cameraSpeed.y * Time.deltaTime, 0f);
        if (transform.position.y > BOSSPOINT) // �{�X��Ŏ~�܂�
        {
            cameraSpeed = Vector2.zero;
        }
    }
}
