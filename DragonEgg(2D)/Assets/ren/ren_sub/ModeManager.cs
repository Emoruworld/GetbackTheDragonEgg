using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeManager : MonoBehaviour
{
    public static GameObject selectUI;//���ƂŕύX
    public static GameObject powerUpCanvas;
    public static GameObject DragonBoxUITeam;//���ƂŕύX
    public static GameObject DragonBoxUIPowerUp;//���ƂŕύX
    public static GameObject teamCastam;//���ƂŕύX
    
    bool boxFlag = false;//�{�b�N�X
    bool powerUpFlag = false;//�������[�h��I�񂾂��ǂ���
    bool teamFlag = false;//�Ґ����[�h��I�񂾂��ǂ���



    //public RectTransform childDragonIcon;//RectTransform�^�̕ϐ�a��錾�@�쐬�����e�L�X�g�I�u�W�F�N�g���A�^�b�`���Ă���
    void Start()
    {
        //�Z���N�g��ʂ�UI
        selectUI = GameObject.Find("SelectUI");
        Debug.Log("�ʂ�܂�");
        //�Z���N�g��ʂ��ŏ��̉�ʂɂ���
        MoveSelectMenu();
    }

    // Update is called once per frame
    void Update()
    {
        //Escape�L�[�������ƂЂƂO�̉�ʂɖ߂�
        if (boxFlag && Input.GetKeyDown(KeyCode.Escape))
        {
            MoveSelectMenu();
        }
        if (powerUpFlag && Input.GetKeyDown(KeyCode.Escape))
        {
            MoveMonsterBoxPowerUp();
        }
        if (teamFlag && Input.GetKeyDown(KeyCode.Escape))
        {
            MoveMonsterBoxTeam();
        }
    }
    // Start is called before the first frame update
    //�Z���N�g��ʂɈړ�����یĂяo�����֐�
    public void MoveSelectMenu()
    {
        selectUI.SetActive(true);
        boxFlag = false;
        powerUpFlag = false;
    }
    //�Ґ�(Team)���������ۂ̃����X�^�[BOX��ʂɈړ�����یĂяo�����֐�
    public void MoveMonsterBoxTeam()
    {
        selectUI.SetActive(false);
        boxFlag = true;
        teamFlag = false;
    }
    //����(PowerUp)���������ۂ̃����X�^�[BOX��ʂɈړ�����یĂяo�����֐�
    public void MoveMonsterBoxPowerUp()
    {
        selectUI.SetActive(false);
        boxFlag = true;
        powerUpFlag = false;
    }
    //������ʂɈړ�����یĂяo�����֐�
    public void MovePowerUp()
    {
        selectUI.SetActive(false);
        boxFlag = false;
        powerUpFlag = true;
    }

}
