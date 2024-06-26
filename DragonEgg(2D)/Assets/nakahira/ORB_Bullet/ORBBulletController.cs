using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ORBBulletController : MonoBehaviour
{
    private float speed = 1f;
    public const int ATTACK = 1;
    private Camera cameraComponent;
    // �C���X�^���X���ő�����Ă��炤
    public Vector2 angle;
    public int attack { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        attack = 1;
        cameraComponent = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //�@�J�����̈ړ����x�܂߂Ĉړ�
        transform.Translate((angle * speed + BattleCameraController.cameraSpeed) * Time.deltaTime);

        // ��ʊO�ɏo�������
        Vector2 viewPos = cameraComponent.WorldToViewportPoint(transform.position);
        if (viewPos.y < 0 ||
            viewPos.y > 1 ||
            viewPos.x < 0 ||
            viewPos.x > 1) // ���ꉽ�Ƃ��Z���Ȃ�Ȃ�����
        {
            Destroy(gameObject);
        }
    }
}
