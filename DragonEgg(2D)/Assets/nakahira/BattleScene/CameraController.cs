using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static Vector2 cameraSpeed = new Vector2(0, 0.5f);// �J�����̈ړ��X�s�[�h
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <19) // �{�X��Ŏ~�܂�
        {
            transform.Translate(cameraSpeed.x * Time.deltaTime, cameraSpeed.y * Time.deltaTime, 0f);
        }
    }
}
