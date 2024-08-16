using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using DragonRace;

public class RightChildDragonController : MonoBehaviour
{
    // �A�j���[�V������؂�ւ���

    private races myRace;
    private Animator myAnimator;


    private Image meterImage;
    private Image meterGuageImage;

    MeterSpriteStore sprites;

    private void Start()
    {
        myAnimator = GetComponent<Animator>();
        meterImage = GameObject.Find("RightChargeMeter").GetComponent<Image>();
        meterGuageImage = GameObject.Find("RightChargeMeterInside").GetComponent<Image>();
        // �Ґ���������󂯎��
        // ���Ńo�g���`�[���ɓK���ȃf�[�^������
        //BattleTeam.sChildDragonDataRight = races.fire;
        myRace = BattleTeam.sChildDragonDataRight;
        // ScriptableObject���擾
        sprites = (MeterSpriteStore)Resources.Load("MeterSprites");
        //Debug.Log($"�푰{myRace}");
        // �����̎푰�̃Q�[�W��
        switch (myRace)
        {
            case races.player:
                myAnimator.SetTrigger("Player");
                gameObject.AddComponent<HadouShooter>();
                meterImage.sprite = sprites.playerMeterSprite;
                meterGuageImage.sprite = sprites.playerMeterGuageSprite;
                break;
            case races.fire:
                myAnimator.SetTrigger("Fire");
                gameObject.AddComponent<FireShooter>();
                meterImage.sprite = sprites.fireMeterSprite;
                meterGuageImage.sprite = sprites.fireMeterGuageSprite;
                break;
            case races.ice:
                myAnimator.SetTrigger("Ice");
                gameObject.AddComponent<IceShooter>();
                meterImage.sprite = sprites.iceMeterSprite;
                meterGuageImage.sprite = sprites.iceMeterGuageSprite;
                break;
            case races.wind:
                myAnimator.SetTrigger("Wind");
                gameObject.AddComponent<WindShooter>();
                meterImage.sprite = sprites.windMeterSprite;
                meterGuageImage.sprite = sprites.windMeterGuageSprite;
                break;
            case races.thunder:
                myAnimator.SetTrigger("Thunder");
                gameObject.AddComponent<ThunderShooter>();
                meterImage.sprite = sprites.thunderMeterSprite;
                meterGuageImage.sprite = sprites.thunderMeterGuageSprite;
                break;
            case races.none:
                myAnimator.SetTrigger("Empty");
                meterImage.sprite = sprites.noneMeterSprite;
                meterGuageImage.sprite = sprites.noneMeterGuageSprite;
                break;
            default:
                myAnimator.SetTrigger("Error");
                Debug.Log("Error!!");
                break;
        }
    }
}
