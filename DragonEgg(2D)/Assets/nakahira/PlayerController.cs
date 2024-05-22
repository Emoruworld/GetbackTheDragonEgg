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
        // �ړ��I
        if (Input.GetKey(KeyCode.W))
        {
            Move(0f, speedy);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Move(-speedx, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Move(0f, -speedy);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Move(speedx, 0f);
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

    private void Move(float x, float y) // �ړ��\����Ƃ����l�ߍ���
    {
        // �����̍��W���J��������o�Ȃ��悤�ɐ���
        Vector2 viewPos = cameraComponent.WorldToViewportPoint(transform.position);
        Debug.Log(viewPos);
        // x,y���r���[�|�[�g��0�`1�ɂ����܂��Ă��瓮���Ă悢
        if (viewPos.x < 1.0f && viewPos.x > 0f ||
            viewPos.y < 1.0f && viewPos.y > 0f)
        {
            transform.Translate(x, y, 0f);
        }

    }
}
