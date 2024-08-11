using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    protected Vector2 speed = Vector2.zero;

    protected Animator animator;
    protected Camera cameraComponent;

    protected float hitPoint = 1; // �̗́I

    protected bool canMove = true; // �����邩
    protected bool canShoot = true;  // �e���Ă邩

    public int attack { get; protected set; }

    protected float shootSpan = 0; // ���b�����ɋ�������(canShoot��false�̎��͊֌W�Ȃ�)
    protected float shootTimer = 0; // �v������ϐ�

    protected AudioClip deathSound; // �G�����ł���Ƃ��̉��͍���Œ�ɂ��悤

    protected float invincibleTime = 0.2f; // ���G���ԋL�^�p
    // Start is called before the first frame update
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        cameraComponent = Camera.main;
        // ���\�[�X�t�@�C��������
        deathSound = (AudioClip)Resources.Load("EnemyDeathSound");
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        // ���G���Ԃ̌��Z��������
        if (invincibleTime > 0)
        {
            invincibleTime -= Time.deltaTime;
        }
        else
        {
            invincibleTime = 0;
        }

        if (canMove)
        {
            Move();
        }
        if (canShoot)
        {
            shootTimer += Time.deltaTime;
            if (shootTimer > shootSpan)
            {
                shootTimer = 0;
                Shoot();
            }
        }

        // ��ʊO�ɏo����
        if (OffScreenJudgment(0.2f))
        {
            // ����
            Destroy(gameObject);
        }
    }

    protected bool OffScreenJudgment(float offset) // ��ʓ��Ȃ�true�A�O�Ȃ�false
    {
        // offset�͊O�������ɍL����悤�ɓ���
        Vector2 viewPos = cameraComponent.WorldToViewportPoint(transform.position);
        return (viewPos.y + offset < 0 ||
                   viewPos.y - offset > 1 ||
                   viewPos.x + offset < 0 ||
                   viewPos.x - offset > 1); // ����Z���Ȃ�Ȃ�����
    }

    protected void DestroyThisGameobject() // �A�j���[�V�����C�x���g�Ɍ��シ����
    {
        Destroy(gameObject);
    }

    protected Vector2 UnitVector(GameObject gameObject) // ���̓G��������̃I�u�W�F�N�g�ւ̒P�ʃx�N�g���𐶐����܂��B
    {
        Vector3 relativeDistance = gameObject.transform.position - transform.position;
        return relativeDistance.normalized;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // ���G���Ԓ��Ȃ瑁��riturn
        if (invincibleTime > 0) return;

        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            //Debug.Log(collision);
            Damage(collision.gameObject.GetComponent<PlayerBullet>().finalAttack);
            // ���G�ɂ���
            Invincible(0.33f);
            return;
        }

        // �{�X�Ȃ炱�̐�͎��s���Ȃ�
        if (gameObject.CompareTag("Boss")) return;

        // �����v���C���[�ɏՓ˂�����
        if (collision.gameObject.CompareTag("Player"))
        {
            // ��
            OnDeath();
            return;
        }
    }

    protected void Damage(int attack) // hitPoint�͂������猸�炷����
    {
        DamageNumberGenerator.GenerateText(attack, transform.position, Color.white);
        hitPoint -= attack;
        if (hitPoint <= 0)
        {
            OnDeath();
        }
    }

    protected virtual void Move() // �ړ��֘A�̏����͂����ɏ����܂��傤
    {
        // �J�����̈ړ��ɂ��킹�ē����Ă���
        // ����Ŕh���N���X�̓J�����̈ړ����ӎ������Ɏ����ł���

        // ������Ə�����������܂���
        // tag��boss��������ړ����Ȃ�
        if (gameObject.CompareTag("Boss")) return;
        transform.Translate(BattleCameraController.cameraSpeed * Time.deltaTime, Space.World);
    }
    protected virtual void Shoot() // �e���֘A�̏����͂����ɏ����܂��傤
    {

    }

    protected virtual void OnDeath() // �����On���\�b�h�ł��BHp��0�ɂȂ����Ƃ��Ɏ��s����܂��B
    {
        AudioSource.PlayClipAtPoint(deathSound, transform.position);
        animator.SetTrigger("Death"); // �p�������I�u�W�F�N�g�ɂ͕K��Death�����邱��
    }

    // ���̖��̒ʂ�����̌����ɋ���ł����̃Z�b�g�ł��B
    // �g�p�@����������̂Ŋ֐���
    // angle�͒P�ʃx�N�g���ɂ��Ȃ��Ƒ������ς�����Ⴄ��
    protected void InstantiateBulletToAngle(GameObject bullet, Vector2 angle)
    {
        // �����B������angle�̌����B
        GameObject bulletInstance = Instantiate(bullet, transform.position, Quaternion.FromToRotation(Vector3.down, angle));
        // �ړ������͕ʂŐݒ肷��B
        bulletInstance.GetComponent<EnemyBullet>().SetAngle(angle);
    }

    // ���G���Ԃ�t�^�ł���֐�
    public void Invincible(float time)
    {
        invincibleTime += time;
    }
}
