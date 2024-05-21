using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speedx = 0.1f;
    private float speedy = 0.1f;

    // �G�f�B�^�ŃA�^�b�`
    [SerializeField] private GameObject playerRapidBullet;
    [SerializeField] private GameObject cameraObject;

    private Camera cameraComponent;
    // Start is called before the first frame update
    void Start()
    {
        cameraComponent = cameraObject.GetComponent<Camera>(); // �J�����R���|�[�l���g�擾
    }

    // Update is called once per frame
    void Update()
    {
        // �ړ��I ���ɉ�����Ƃ��͏����x��
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0f, speedy, 0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speedx, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0f, -speedy / 2, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speedx, 0f, 0f);
        }

        // �X�y�[�X�L�[�Œe�𔭎�
        // ����͋����đ����r�[�����o��
        // ���������Ă���ƍL�͈͂ɍL���鉊���o��
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // �����̌��݈ʒu�ɒe�̃v���n�u������
            Instantiate(playerRapidBullet, transform.position, Quaternion.identity);
        }
    }

    private void Move(Vector2 speed) // �ړ��\����Ƃ����l�ߍ���
    {
        //cameraComponent.orthographicSize
        //if 
        //transform.Translate(speed);
    }
}
