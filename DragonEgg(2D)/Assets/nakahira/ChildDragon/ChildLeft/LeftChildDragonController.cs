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
        BattleTeam.sChildDragonDataLeft = DragonRace.races.thunder;
        myRace = BattleTeam.sChildDragonDataLeft;
        Debug.Log($"�푰{myRace}");
        switch (myRace)
        {
            case races.player:
                myAnimator.SetTrigger("Player");
                break;
            case races.fire:
                myAnimator.SetTrigger("Fire");
                break;
            case races.ice:
                myAnimator.SetTrigger("Ice");
                break;
            case races.wind:
                myAnimator.SetTrigger("Wind");
                break;
            case races.thunder:
                myAnimator.SetTrigger("Thunder");
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
