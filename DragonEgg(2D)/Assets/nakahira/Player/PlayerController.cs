using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speedx = 1f;
    private float speedy = 1f;

    // �G�f�B�^�ŃA�^�b�`
    [SerializeField] private GameObject playerRapidBullet;
    [SerializeField] private GameObject cameraObject;

    private Camera cameraComponent;

    private int hitPoint = 10;

    private bool canFire; // �������Ă�󋵂��ǂ���

    private float fireRate; // ���ˊ��o
    private float fireTimer;

    // Start is called before the first frame update
    void Start()
    {
        cameraComponent = cameraObject.GetComponent<Camera>(); // �J�����R���|�[�l���g�擾
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(blinking);

        // �ړ��I
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

        // �X�y�[�X�L�[�Œe�𔭎�
        // ����͋����đ����r�[�����o��
        // ���������Ă���ƍL�͈͂ɍL���鉊���o��
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // �����̌��݈ʒu�ɒe�̃v���n�u������
            Instantiate(playerRapidBullet, transform.position, Quaternion.identity);

            StartCoroutine(FireCharge(0.5f)); // �����b�`���[�W����canFire��true��
        }

        if (canFire)
        {

        }
    }

    private void Move(float x, float y) // �ړ��\����Ƃ����l�ߍ���
    {
        // �����̍��W���J��������o�Ȃ��悤�ɐ���
        Vector2 viewPos = cameraComponent.WorldToViewportPoint(transform.position);
        // �ړ����x,y���r���[�|�[�g��0�`1�ɂ����܂��Ă��瓮���Ă悢
        // �Ǎۂł����������ɂȂ�i�߂�
        if (viewPos.x + x < 1.0f && viewPos.x + x > 0f)
        {
            transform.Translate(x, 0f, 0f);
        }
        if (viewPos.y + y < 1.0f && viewPos.y + y > 0f)
        {
            transform.Translate(0f, y, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "PlayerBullet") // �����̒e�ȊO�ɓ���������
        {
            hitPoint--;
            if (hitPoint > 0) // �����Ă�����_�ł�����
            {
                StartCoroutine(Blinking(4, 0.05f));
            }
            else
            {
                Destroy(gameObject); // ��
                // HP���[���ɂȂ����玀�S�A�j���[�V�������Đ����ă��g���C��ʂȂ�Ȃ�Ȃ�
            }
        }
    }

    IEnumerator Blinking(int count, float interval) // interval�͕b�P��
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Color visibleColor = new Color(255, 255, 255, 255);
        Color invisibleColor = new Color(255, 255, 255, 0);
        for (int i = 0; i < count; i++) // count��J��Ԃ�
        {
            spriteRenderer.color = invisibleColor;
            yield return new WaitForSeconds(interval); // interval�b�҂�
            spriteRenderer.color = visibleColor;
            yield return new WaitForSeconds(interval); // ����Ȃ���Ł@�ǂ��ł��傤
        }
    }

    IEnumerator FireCharge(float chargeTime)
    {
        for (float time = 0; time < chargeTime; time += Time.deltaTime) // chargeTime�b�܂ő҂�
        {
            if (Input.GetKey(KeyCode.Space)) // �{�^���������ςȂ�
            {
                Debug.Log("����[��");
                yield return null;
            }
            else // ���������߂���
            {
                Debug.Log("���f");
                yield break; // �R���[�`���I��
            }
        }
        Debug.Log("�т�[��");
        canFire = true;
    }
}
