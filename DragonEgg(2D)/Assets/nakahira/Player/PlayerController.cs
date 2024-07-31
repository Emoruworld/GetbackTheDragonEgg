using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static GameObject player;

    private TestDragonStatus playerStatus;

    private float speed = 1f;
    private float hitPoint = 10;

    private Camera cameraComponent;

    // �r���[�|�[�g�̕␳���`
    private float viewOffsetRight = 0.38f;
    private float viewOffset = 0.1f;

    private Animator animator; // �����̃A�j���[�^�[�R���|�[�l���g
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject; // ����Ōl�����J�ł��邩��
        cameraComponent = Camera.main; // �J�����R���|�[�l���g�擾
        animator = GetComponent<Animator>();
        SetStatusFromData();
        // �����̎푰�ɉ����ďo��e��ݒ肷��
        // ���̓e�X�g�ŉ�
        gameObject.AddComponent<FireShooter>();
    }

    private void SetStatusFromData()
    {
        // Static�N���X���玩���̃f�[�^���擾
        // ����͂����܂ł��e�X�g
        BattleTeam.sParentDragonData = DragonRace.races.thunder;
        playerStatus = new TestDragonStatus("2,2,2,2,2,2,2");
        hitPoint = playerStatus.hp;
        speed = playerStatus.speed;
    }

    // Update is called once per frame
    void Update()
    {
        //���X�e�B�b�N
        Vector2 speedVec = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
 
        //Debug.Log("H" + Input.GetAxis("Horizontal"));
        //Debug.Log("V" + Input.GetAxis("Vertical"));

        //Debug.Log($"{speedVec}, {fadeSpeed}");
        Move(speedVec, speed);
    }

    private void Move(Vector2 speedVec, float speed) // �ړ��\����Ƃ����l�ߍ���
    {
        // �܂��P�ʃx�N�g����
        Vector2 generalVec = speedVec.normalized;
        // �֐��ŕ�����g���`��ϐ��Ƃ��Đ錾
        float speedX = generalVec.x * speed * Time.deltaTime;
        float speedY = generalVec.y * speed * Time.deltaTime;
        // �����̍��W���J��������o�Ȃ��悤�ɐ���
        Vector2 viewPos = cameraComponent.WorldToViewportPoint(transform.position);

        // �z������i�߂Ȃ�
        // �E�����ɂ�UI������̂Œǉ��ŕ␳����
        if (viewPos.x + viewOffsetRight < 1.0f && speedX > 0)
        {
            transform.Translate(speedX, 0f, 0f);
        }
        if (viewPos.x - viewOffset > 0f && speedX < 0)
        {
            transform.Translate(speedX, 0f, 0f);
        }
        if (viewPos.y + viewOffset < 1.0f && speedY > 0)
        {
            transform.Translate(0f, speedY, 0f);
        }
        if (viewPos.y - viewOffset > 0f && speedY < 0)
        {
            transform.Translate(0f, speedY, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject temp = collision.gameObject;
        if (temp.CompareTag("Enemy") || temp.CompareTag("Boss")) // �G�ɓ���������
        {
            Damage(collision.GetComponent<Enemy>().attack);
        }
        else if (temp.CompareTag("EnemyBullet"))
        {
            Damage(collision.GetComponent<EnemyBullet>().attack);
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
