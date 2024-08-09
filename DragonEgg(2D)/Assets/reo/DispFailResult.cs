// �X�e�[�W�ɓ���ۂɕ\�������郁�b�Z�[�W�𑀍삷��X�N���v�g

// �\��+���X�ɕ������\�������+
// ���b�Z�[�W���S�ĕ\�����ꂽ��{�^���\��+
// �X�y�[�X�L�[�������ƃ��b�Z�[�W�𑦑S���\��
using System.Collections;
using UnityEngine;
using UnityEngine.UI; // ���Ƃ�
using TMPro;
using System.Threading;  // sleep�p


public class DispFailResult : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ResultText;
    [SerializeField] private GameObject GoHomeButton;
    [SerializeField] private GameObject GoStageButton;
    [TextArea(5, 5)]

    private GameObject DispDragonImage;
    //[SerializeField] private string msgText;  // �g��Ȃ��Ȃ���

    private float msgSpeed = 0.03f;  // �e�L�X�g�\���Ԋu
    private float msgLineSpeedEnter = 0.08f;  // ���s���ҋ@����
    private float msgSpeedEnter = 0.01f;  // ���ҋ@����
    //private float summonDragonSpeed = 0.2f;  // �h���S����\������܂ł̑ҋ@����
    //private float summonDragonFirstSpeed = 0.5f;  // �h���S����\������܂ł̑ҋ@����
    //private int eggAnimNum = 8;  // ����ւ����
    private int eggAnimNum = 10;  // �A�j���[�V�����̊��鐔
    private float eggAnimSpeed = 0.6f;  // �A�j���[�V�����̑��x
    //private int tempExp = 1234567;  // exp(��)

    float dragonScale = 3.5f;

    //int stageNum = 0;
    string dialogText = "";  // �񓯊�������foreach���̎w��ł��������̂ŕϐ�������ĉ���������

    [SerializeField] private GameObject Panel;

    //int test = 0;


    // �Q�[���V�[������N���A�����X�e�[�W�Ə��N���A���ǂ�����Ⴄ
    int clearStageNum = 1;
    bool isFirstClear = false;

    // 


    void Start()
    {
        //DialogText.text = dialogText;
        GoHomeButton.SetActive(false);  // �{�^�����B��
        GoStageButton.SetActive(false);
        //StartCoroutine(TypeDisplay());

        DispResultFunc();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) // �X�y�[�X�L�[�������ꂽ��
        {
            StopAllCoroutines();
            //DialogText.text = dialogText;  // DialogText.text�֐���dialogText�ϐ��̒��g����
            ResultText.text = "";
            foreach (char item in dialogText)
            {
                if (item == '|')
                {
                    // <br>��DialogText.text�ɑ������
                    ResultText.text += "<br>";
                }
                else if (item == '/')
                {
                    // �������Ȃ�
                }
                else
                {
                    ResultText.text += item;  // 
                }
            }

            GoHomeButton.SetActive(true);  // �{�^����\��
            GoStageButton.SetActive(true);
        }
    }

    public void DispResultFunc()
    {
        ResultText.text = "";
        
        dialogText = "//////S/t/a/g/e// F/a/i/l/e/d/...||" + "Continue?";  //  + "(dragon.png)" dialogText�ϐ��ɕ�����

        GoHomeButton.SetActive(false);  // �{�^�����B��
        GoStageButton.SetActive(false);

        //StartCoroutine(ScaleChange());
        StartCoroutine(TypeDisplay());  // ���b�Z�[�W�\�����J�n


        //Debug.Log("Stage " + LoadingScene.stageNum + "||Ready?");
        //Debug.Log(DialogText.text);
    }

    IEnumerator TypeDisplay()  // ���b�Z�[�W��\��������@�\ IEnumerator�͔񓯊��������s�����߂ɗp����f�[�^�^�̈��
    {
        GoHomeButton.SetActive(false);  // �{�^�����B��
        GoStageButton.SetActive(false);

        foreach (char item in dialogText)
        {
            if (item == '|')
            {
                // <br>��DialogText.text�ɑ������
                ResultText.text += "<br>";
                yield return new WaitForSeconds(msgLineSpeedEnter);
            }
            else if (item == '.')
            {
                ResultText.text += item;
                yield return new WaitForSeconds(msgSpeedEnter);
            }
            else if (item == '/')
            {
                // �\�������҂���
                yield return new WaitForSeconds(msgSpeedEnter);
            }
            else
            {
                ResultText.text += item;  // 
            }

            yield return new WaitForSeconds(msgSpeed);  // ���b�Z�[�W��msgSpeed���ɕ\���H
        }

        GoHomeButton.SetActive(true);  // �{�^����\��
        GoStageButton.SetActive(true);

    }
}