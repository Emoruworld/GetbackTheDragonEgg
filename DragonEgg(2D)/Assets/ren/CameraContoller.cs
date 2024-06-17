using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class CameraContoller : MonoBehaviour
{ 
    public static GameObject powerUpCanvas;
    public static GameObject icon;//���ƂŕύX
    public Vector3 cameraPos;
    bool boxFlag = false;
    bool powerUpFlag = false;



    //public RectTransform childDragonIcon;//RectTransform�^�̕ϐ�a��錾�@�쐬�����e�L�X�g�I�u�W�F�N�g���A�^�b�`���Ă���
    void Start()
    {
        powerUpCanvas = GameObject.Find("PowerUpCanvas");
        icon = GameObject.Find("ChildDragonIcon");
        CameraMoveSelectMenu();
    }

    // Update is called once per frame
    void Update()
    {
       // this.transform.Translate(0f, 0.1f, 0f);
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
        //���݂̈ʒu���擾
        Vector3 pos = this.gameObject.transform.position;
       
        if (boxFlag && Input.GetKeyDown(KeyCode.Escape))
        {
            CameraMoveSelectMenu();
        }
        if (powerUpFlag && Input.GetKeyDown(KeyCode.Escape))
        {
            CameraMoveMonsterBox();
        }
    }
    // Start is called before the first frame update
    public void CameraMoveSelectMenu()
    {
        transform.position = new Vector3(-160, 0, -10);
        powerUpCanvas.SetActive(false);
        icon.SetActive(false);
        boxFlag = false;
        powerUpFlag = false;
    }
    public void CameraMoveMonsterBox()
    {
        transform.position = new Vector3(-80, 0, -10);
        powerUpCanvas.SetActive(false);
        icon.SetActive(true);
        boxFlag = true;
        powerUpFlag = false;
    }
    public void CameraMovePowerUp()
    {
        transform.position = new Vector3(0, 0, -10);
        powerUpCanvas.SetActive(true);
        icon.SetActive(false);
        boxFlag = false;
        powerUpFlag = true;
    }


    public void MonsterBox()//�J���������ꂢ��y=0�Ŏ~�܂�Ȃ��@����I�ɂ͖��Ȃ����ǋC�ɂȂ邩�獡��C��
    {
       
    }


}
