using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCameraController : MonoBehaviour
{
    // �{�X�̂����W�Ł[��
    public const int BOSSPOINT = 29;

    public static Vector2 cameraSpeed = new Vector2(0, 0.5f);// �J�����̈ړ��X�s�[�h

    public static GameObject mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(cameraSpeed * Time.deltaTime);
        if (transform.position.y > BOSSPOINT) // �{�X��Ŏ~�܂�
        {
            cameraSpeed = Vector2.zero;
        }
    }
}
