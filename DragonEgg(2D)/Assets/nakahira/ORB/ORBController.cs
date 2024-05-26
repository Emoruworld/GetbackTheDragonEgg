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
    private float shootSpan = 1; // ���b�����ɒe�𔭎˂��邩

    private bool canMove = true; // �����邩
    private bool canShoot = true;  // �e���Ă邩

    private Animator animator;
    private Camera cameraComponent;
     //�v���n�u�Ȃ̂ŃG�f�B�^�����낵��
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        cameraComponent = Camera.current;
    }

    // Update is called once per frame
    void Update()
    {
        angle += Time.deltaTime;
        shootTimer += Time.deltaTime;

        if (canMove) // �����֘A�̏���
        {
            speedx = (float)Math.Cos(angle * cycleSpeed) * Time.deltaTime * moveSpeed;
            transform.Translate(speedx, speedy, 0f);
        }

        if (canShoot)
        {
            if (shootTimer > shootSpan)
            {
                shootTimer = 0;
                Instantiate(bullet, transform.position, Quaternion.identity);
            }
        }

        // ��ʊO�ɏo�������
        Vector2 viewPos = cameraComponent.WorldToViewportPoint(transform.position);
        if (viewPos.y > 1)
        {
            Destroy(gameObject);
        }
    }

    private async Task OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("�ʉ�");
        if (collision.gameObject.tag == "PlayerBullet")
        {
            canMove = false;
            canShoot = false;
            animator.SetTrigger("Death"); // ���S���[�V�������Đ�
            await Task.Delay(TimeSpan.FromSeconds(0.5f));// ���[�V�����I��(0.5�b�Œ�A����ҏW���悤��)�܂ő҂�
            Destroy(gameObject);
        }
    }
}
