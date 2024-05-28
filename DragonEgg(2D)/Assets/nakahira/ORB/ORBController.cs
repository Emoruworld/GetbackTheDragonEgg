using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class ORBController : MonoBehaviour
{
    public float speedx = 0f;
    public float speedy = 0f;

    public float cycleSpeed = 5f; // �傫������Ή�]�������������Ȃ�A��葁���������܂��B
    public float moveSpeed = 5f; // �傫������΂�葁���ړ����A���a���傫���Ȃ�܂��B

    private float angle; // �p�x�̌v�Z�Ɏg���^�C�}�[
    private float shootTimer; // �e�̔��˂𐧌䂷��^�C�}�[
    private float shootSpan = 2; // ���b�����ɒe�𔭎˂��邩

    private bool canMove = true; // �����邩
    private bool canShoot = true;  // �e���Ă邩

    private Animator animator;
    private Camera cameraComponent;
    private GameObject player;
     //�v���n�u�Ȃ̂ŃG�f�B�^�����낵��
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        cameraComponent = Camera.main;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        angle += Time.deltaTime;
        shootTimer += Time.deltaTime;

        if (canMove) // �����֘A�̏���
        {
            speedx = (float)Math.Cos(angle * cycleSpeed) * moveSpeed;
            transform.Translate(speedx * Time.deltaTime, speedy * Time.deltaTime, 0f);
        }

        if (canShoot)
        {
            if (shootTimer > shootSpan)
            {
                shootTimer = 0;
                // �v���C���[�Ɍ����ċ���������
                Vector3 relativeDistance = player.transform.position - transform.position;
                GameObject bulletInstance = Instantiate(bullet, transform.position, Quaternion.identity);
                bulletInstance.GetComponent<ORBBulletController>().speed = relativeDistance.normalized; // Vector2��Vector3�Ԃ�����ő��v���Ȃ�
            }
        }

        // ��ʊO�ɏo�������
        Vector2 viewPos = cameraComponent.WorldToViewportPoint(transform.position);
        if (viewPos.y < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            //canMove = false;
            canShoot = false;
            animator.SetTrigger("Death"); // ���S���[�V�������Đ��B�I��������Destroy
        }
    }

    private void DestroyThisGameobject() // �A�j���[�V�����C�x���g�Ɍ��シ����
    {
        Destroy(gameObject);
    }
}
