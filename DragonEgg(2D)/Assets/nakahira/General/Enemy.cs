using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected float speedx = 0;
    protected float speedy = 0;

    protected Vector2 offsetSpeed = BattleCameraController.cameraSpeed;

    protected Animator animator;
    protected Camera cameraComponent;

    protected float hitPoint = 1; // �̗́I

    protected bool canMove = true; // �����邩
    protected bool canShoot = true;  // �e���Ă邩

    public int attack { get; protected set; }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        cameraComponent = Camera.main;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (canMove)
        {
            Move();
        }
        if (canShoot)
        {
            Shoot();
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

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Damage(collision.gameObject.GetComponent<PlayerBullet>().finalAttack);
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
        
    }
    protected virtual void Shoot() // �e���֘A�̏����͂����ɏ����܂��傤
    {

    }

    protected virtual void OnDeath() // �����On���\�b�h�ł��BHp��0�ɂȂ����Ƃ��Ɏ��s����܂��B
    {
        animator.SetTrigger("Death"); // �p�������I�u�W�F�N�g�ɂ͕K��Death�����邱��
    }
}
