using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static GameObject player;

    private TestDragonStatus playerStatus;

    private float speedx = 1f;
    private float speedy = 1f;
    private float hitPoint = 10;
    private int attack = 1;

    // �G�f�B�^�ŃA�^�b�`
    [SerializeField] private GameObject playerRapidBullet;
    [SerializeField] private GameObject playerFireBullet;

    private Camera cameraComponent;



    private const float fireInterval = 0.2f; // ���˂���܂ł̒���������
    private const float srowFireRate = 0.1f; // ���ˊԊu
    private float fireTimer = -fireInterval; // �����l��fireInterval�����炵�Ă���

    private Vector3 instanceOffset = new Vector3(0, 0.3f, 0); // �������甭�˂��邽�߂̕␳�ł��B

    private Animator animator; // �����̃A�j���[�^�[�R���|�[�l���g
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject; // ����Ōl�����J�ł��邩��
        cameraComponent = Camera.main; // �J�����R���|�[�l���g�擾
        animator = GetComponent<Animator>();
        SetStatusFromData();
    }

    private void SetStatusFromData()
    {
        // ScriptableObject���玩���̃f�[�^���擾
        // ����͂����܂ł��e�X�g
        StaticDataManager.sParentDragonData = new TestDragonStatus("0,50,2,3,4,5,6");
        playerStatus = StaticDataManager.sParentDragonData;
        hitPoint = playerStatus.hp;
        speedx = playerStatus.speed;
        attack = playerStatus.attack;
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
            Instantiate(playerRapidBullet, transform.position + instanceOffset, Quaternion.identity);
        }
        if (Input.GetKey(KeyCode.Space)) // Space�L�[��������
        {
            fireTimer += Time.deltaTime;
            if (fireTimer > srowFireRate) // fireRate�b�Ɉ�񉊂����˂����
            {
                GameObject bullet = Instantiate(playerFireBullet, transform.position + instanceOffset, Quaternion.identity);
                // �����̍U���͂���悹
                bullet.GetComponent<PlayerBullet>().AttackCalc(attack);
                fireTimer = 0; // �^�C�}�[���Z�b�g
            }
        }

        if (Input.GetKeyUp(KeyCode.Space)) // �L�[�𗣂�����
        {
            fireTimer = -fireInterval; // fireTimer�̏����l��fireInterval�����炵�Ă���
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
        if (collision.gameObject.CompareTag("Enemy")) // �G�ɓ���������
        {
            Damage(collision.GetComponent<Enemy>().attack);
        }
        else if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Damage(collision.GetComponent<ORBBulletController>().attack);
        }
    }

    private void Damage(int attack) // hitPoint�͂������猸�炷����
    {
        DamageNumberGenerator.GenerateText(attack, transform.position, Color.red);
        hitPoint -= attack;
        if (hitPoint > 0) // �����Ă�����
        {
            StartCoroutine(Blinking(4, 0.05f)); // �_��
        }
        else // �łȂ����
        {
            animator.SetTrigger("Death"); // ���b���[�V�������Đ�
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
}
