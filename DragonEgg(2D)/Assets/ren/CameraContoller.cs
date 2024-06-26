using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class CameraContoller : MonoBehaviour
{ 
    public static GameObject powerUpCanvas;
    public static GameObject iconUI;//���ƂŕύX
    public static GameObject teamCastam;//���ƂŕύX
    public static GameObject selectUI;//���ƂŕύX
    public Vector3 cameraPos;//�J�����̈ʒu
    bool boxFlag = false;//�{�b�N�X
    bool powerUpFlag = false;//�������[�h��I�񂾂��ǂ���
    bool teamFlag = false;//�Ґ����[�h��I�񂾂��ǂ���



    //public RectTransform childDragonIcon;//RectTransform�^�̕ϐ�a��錾�@�쐬�����e�L�X�g�I�u�W�F�N�g���A�^�b�`���Ă���
    void Start()
    {
        //������ʂł�UI
        powerUpCanvas = GameObject.Find("PowerUpUI");
        //�����X�^�[BOX�ł�UI
        iconUI = GameObject.Find("ChildDragonIcon_Test");
        //�Ґ��ł�UI
        teamCastam = GameObject.Find("TeamCastam");
        //�Z���N�g��ʂ�UI
        selectUI = GameObject.Find("SelectUI");
        //�Z���N�g��ʂ��ŏ��̉�ʂɂ���
        CameraMoveSelectMenu();
    }

    // Update is called once per frame
    void Update()
    {
        //�����X�^�[�{�b�N�X�ł̃J�����̈ړ�
        MonsterBox();

        //���݂̈ʒu���擾
        Vector3 pos = this.gameObject.transform.position;
       //Escape�L�[�������ƂЂƂO�̉�ʂɖ߂�
        if (boxFlag && Input.GetKeyDown(KeyCode.Escape))
        {
            CameraMoveSelectMenu();
        }
        if (powerUpFlag && Input.GetKeyDown(KeyCode.Escape))
        {
            CameraMoveMonsterBoxPowerUp();
        }
        if (teamFlag && Input.GetKeyDown(KeyCode.Escape))
        {
            CameraMoveMonsterBoxTeam();
        }
    }
    // Start is called before the first frame update
    //�Z���N�g��ʂɈړ�����یĂяo�����֐�
    public void CameraMoveSelectMenu()
    {
        transform.position = new Vector3(-160, 0, -10);
        selectUI.SetActive(true);
        powerUpCanvas.SetActive(false);
        iconUI.SetActive(false);
        teamCastam.SetActive(false);
        boxFlag = false;
        powerUpFlag = false;
    }
    //�Ґ�(Team)���������ۂ̃����X�^�[BOX��ʂɈړ�����یĂяo�����֐�
    public void CameraMoveMonsterBoxTeam()
    {
        transform.position = new Vector3(-240, 0, -10);
        selectUI.SetActive(false);
        powerUpCanvas.SetActive(false);
        iconUI.SetActive(false);
        teamCastam.SetActive(true);
        boxFlag = true;
        teamFlag = false;
    }
    //����(PowerUp)���������ۂ̃����X�^�[BOX��ʂɈړ�����یĂяo�����֐�
    public void CameraMoveMonsterBoxPowerUp()
    {
        transform.position = new Vector3(-80, 0, -10);
        selectUI.SetActive(false);
        powerUpCanvas.SetActive(false);
        iconUI.SetActive(true);
        teamCastam.SetActive(false);
        boxFlag = true;
        powerUpFlag = false;
    }
    //������ʂɈړ�����یĂяo�����֐�
    public void CameraMovePowerUp()
    {
        transform.position = new Vector3(0, 0, -10);
        selectUI.SetActive(false);
        powerUpCanvas.SetActive(true);
        iconUI.SetActive(false);
        teamCastam.SetActive(false);
        boxFlag = false;
        powerUpFlag = true;
    }
    
    //�����X�^�[BOX�ł̃J��������
    public void MonsterBox()//�J���������ꂢ��y=0�Ŏ~�܂�Ȃ��@����I�ɂ͖��Ȃ����ǋC�ɂȂ邩�獡��C��
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("up");
            if (transform.position.y <= 0.00f && boxFlag)
            {
                transform.Translate(0f, 0.1f, 0f);
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("down");
            //���݂̈ʒu����x������1�ړ�����

            if (transform.position.y >= -28.00f && boxFlag)
            {
                transform.Translate(0f, -0.1f, 0f);
            }
        }
    }


}
