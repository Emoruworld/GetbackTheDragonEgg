using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using DragonRace;

public class LeftChildDragonController : MonoBehaviour
{
    // �A�j���[�V������؂�ւ���

    private races myRace;
    private Animator myAnimator;
    // IDragonBullet�̃C���^�[�t�F�[�X�^�̕ϐ���錾����
    // ����Ɋe�����̒e��Start���ɓ����

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        // �Ґ���������󂯎��
        // ���Ńo�g���`�[���ɓK���ȃf�[�^������
        //BattleTeam.sChildDragonDataLeft = races.wind;
        myRace = BattleTeam.sChildDragonDataLeft;
        Debug.Log($"�푰{myRace}");
        // ���ꂼ��ɑΉ������A�j���[�V�����ƁA�e�����Ă�悤�ɂ���
        switch (myRace)
        {
            case races.player:
                myAnimator.SetTrigger("Player");
                break;
            case races.fire:
                myAnimator.SetTrigger("Fire");
                gameObject.AddComponent<FireShooter>();
                break;
            case races.ice:
                myAnimator.SetTrigger("Ice");
                gameObject.AddComponent<IceShooter>();
                break;
            case races.wind:
                myAnimator.SetTrigger("Wind");
                gameObject.AddComponent<WindShooter>();
                break;
            case races.thunder:
                myAnimator.SetTrigger("Thunder");
                gameObject.AddComponent<ThunderShooter>();
                break;
            case races.none:
                myAnimator.SetTrigger("Empty");
                break;
            default:
                myAnimator.SetTrigger("Error");
                Debug.Log("Error!!");
                break;
        }
    }
}
