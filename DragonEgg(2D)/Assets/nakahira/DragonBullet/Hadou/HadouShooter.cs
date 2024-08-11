using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HadouShooter : MonoBehaviour
{
    // ���\�[�X�t�@�C�����烍�[�h
    private GameObject hadouKen;
    private GameObject hadouBeam;
    // �o�����r�[�������΂炭�g���̂Ń����o�[�ϐ��ɓ����
    private GameObject beamInstance;

    private Vector3 instanceOffset = new Vector3(0, 0.2f, 0); // �������甭�˂��邽�߂̕␳�ł��B

    private int attack = 0;

    private float hadouKenTimer = 0;
    private const float hadouKenCoolTime = 0.2f;

    private float beamChargeTimer = 0;
    private const float beamChargeMax = 2f;
    // �r�[���`���[�W���Ԃ̋t�����g���Ċ���Z�̐������炵�܂��B
    private const float chargeMeterFactor = 1 / beamChargeMax;

    private PlayerChargeMeterController chargeMeterUI;

    private Coroutine chargeMeterCoroutine = null; // �ǂ�Ŏ��̂��Ƃ��`���[�W���[�^�[�p�̕ϐ��ł��B

    private void Start()
    {
        hadouKen = (GameObject)Resources.Load("HadouBullet");
        hadouBeam = (GameObject)Resources.Load("HadouBeamBase");
        chargeMeterUI = GameObject.Find("PlayerChargeMeterInside").GetComponent<PlayerChargeMeterController>();

        // Start����PlayerPrefs����U���͂��Q��
        // �����f�[�^��������Ȃ������珉���l�Ƃ���1���Z�[�u�@
        attack = PlayerPrefs.GetInt("Attack", 0);
        if (attack == 0)
        {
            attack = 1;
            PlayerPrefs.SetInt("Attack", 1);
            PlayerPrefs.Save();
        }
    }

    private void Update()
    {
        // Debug.Log(beamChargeTimer);

        // �r�[�����o�Ă�Ԓe���̂��֎~����
        if (beamInstance != null) return;

        // �g�����N�[���^�C�}�[���Z
        hadouKenTimer += Time.deltaTime;

        // �X�y�[�X�L�[�Œe�𔭎ˁB
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("joystick button 0"))
        {
            // �`���[�W���[�^�[���d�����Ȃ������������ē`����
            // Debug.Log(chargeMeterCoroutine);
            if (chargeMeterCoroutine != null) { StopCoroutine(chargeMeterCoroutine); }
            
            // ��莞�Ԃ̃N�[���^�C����݂���퓅��i
            if (hadouKenTimer > hadouKenCoolTime)
            {
                Instantiate(hadouKen, transform.position + instanceOffset, Quaternion.identity);

                hadouKenTimer = 0; // ������ƌ��ɖ߂��Ă���
            }
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) // Space�L�[��������
        {
            // �X�y�[�X��������Ă���ԁA�`���[�W����
            beamChargeTimer += Time.deltaTime;
            // ���ߒl���ő�ɂȂ����炻��ȏ�̓`���[�W���Ȃ�
            if (beamChargeTimer > beamChargeMax)
            {
                beamChargeTimer = beamChargeMax;
            }
            // �`���[�W�󋵂�UI�ɔ��f
            chargeMeterUI.FillMeter(beamChargeTimer * chargeMeterFactor);
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyDown("joystick button 0")) // �L�[�𗣂�����
        {
            float reduceTime = 0.2f; // �߂�̂ɗv���鎞�ԁB�r�[���������Əo�鎞�ȊO�͑f�����߂�
            // �L�[�𗣂����Ƃ��A�`���[�W���ő�Ȃ�r�[�����o��
            if (beamChargeTimer >= beamChargeMax)
            {
                beamInstance = Instantiate(hadouBeam);
                reduceTime = beamChargeMax; // �`���[�W�Ɠ������Ԃ����Ė߂�A�����Ă銴�����o��
            }
            // �����łȂ��Ă��g�����̃N�[���^�C�����������Ă��畁�ʂ̒e���ł�
            else if (hadouKenTimer > hadouKenCoolTime)
            {
                Instantiate(hadouKen, transform.position + instanceOffset, Quaternion.identity);

                hadouKenTimer = 0; // ������ƌ��ɖ߂��Ă���
            }
            // �r�[���̃`���[�W�����Z�b�g
            beamChargeTimer = 0;
            // UI���^����ꂽ���x�Ŗ߂�
            chargeMeterCoroutine = StartCoroutine(chargeMeterUI.ReduceMeter(reduceTime));
        }
    }
}
