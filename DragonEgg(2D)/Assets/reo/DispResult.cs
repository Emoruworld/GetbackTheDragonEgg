// �X�e�[�W�ɓ���ۂɕ\�������郁�b�Z�[�W�𑀍삷��X�N���v�g

// �\��+���X�ɕ������\�������+
// ���b�Z�[�W���S�ĕ\�����ꂽ��{�^���\��+
// �X�y�[�X�L�[�������ƃ��b�Z�[�W�𑦑S���\��
using System.Collections;
using UnityEngine;
using UnityEngine.UI; // ���Ƃ�
using TMPro;
using System.Threading;  // sleep�p


public class DispResult : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ResultText;
    [SerializeField] private GameObject GoHomeButton;
    [SerializeField] private GameObject GoStageButton;
    [SerializeField] private GameObject EggImage;
    [SerializeField] private GameObject DragonImage1;
    [SerializeField] private GameObject DragonImage2;
    [SerializeField] private GameObject DragonImage3;
    [SerializeField] private GameObject DragonImage4;
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
        EggImage.SetActive(false);
        DragonImage1.SetActive(false);
        DragonImage2.SetActive(false);
        DragonImage3.SetActive(false);
        DragonImage4.SetActive(false);
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

            //DialogText.text = msgText;  // �g��Ȃ��Ȃ���
            GoHomeButton.SetActive(true);  // �{�^����\��
            GoStageButton.SetActive(true);

            DragonImage1.SetActive(true);  // �h���S����\��
        }
    }

    public void DispResultFunc()
    {
        //ResultText.text = "�l�������o���l ... " + "(�l���o���l)||" + "�������h���S��|" + "(�摜)";
        //ResultText.text = "Get EXP ... " + "(GetEXP)||" + "Rescue Dragon|" + "(dragon.png)";
        //dialogText = "";  // dialogText�ϐ��ɕ�����
        ResultText.text = "";
        //dialogText = "Get EXP ... " + tempExp + "||" + "Rescue Dragon|";  //  + "(dragon.png)" dialogText�ϐ��ɕ�����
        dialogText = "//////S/t/a/g/e// C/l/e/a/r/!/!/||" + "Rescue Dragon///|";  //  + "(dragon.png)" dialogText�ϐ��ɕ�����

        GoHomeButton.SetActive(false);  // �{�^�����B��
        GoStageButton.SetActive(false);
        EggImage.SetActive(false);
        DragonImage1.SetActive(false);

        //StartCoroutine(ScaleChange());
        StartCoroutine(TypeDisplay());  // ���b�Z�[�W�\�����J�n


        //Debug.Log("Stage " + LoadingScene.stageNum + "||Ready?");
        //Debug.Log(DialogText.text);
    }

    IEnumerator ScaleChange()  // �T�C�Y�����X�ɑ傫������
    {
        // ���X�ɑ傫������
        for (int i = 0; i < 10; i++)
        {
            Panel.transform.localScale = new Vector3(i / 10f, i / 10f, 1);
            yield return new WaitForSeconds(0.06f);
        }
        // scale��1�ɂ���(�ی�)
        Panel.transform.localScale = new Vector3(1, 1, 1);
        yield return new WaitForSeconds(0.1f);

        StartCoroutine(TypeDisplay());  // ���b�Z�[�W�\�����J�n
    }

    IEnumerator TypeDisplay()  // ���b�Z�[�W��\��������@�\ IEnumerator�͔񓯊��������s�����߂ɗp����f�[�^�^�̈��
    {
        GoHomeButton.SetActive(false);  // �{�^�����B��
        GoStageButton.SetActive(false);
        EggImage.SetActive(false);
        DragonImage1.SetActive(false);

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

        if (isFirstClear)
        {
            StartCoroutine(EggAnim());  // ���\�����J�n
        }
        else
        {

        }
        
    }

    IEnumerator EggAnim()  // ������h���S���֕ς���
    {
        switch (clearStageNum)
        {
            case 1:
                DispDragonImage = DragonImage1;
                break;

            case 2:
                DispDragonImage = DragonImage2;
                break;

            case 3:
                DispDragonImage = DragonImage3;
                break;

            case 4:
                DispDragonImage = DragonImage4;
                break;

            default:
                Debug.Log("EggAnimError");
                break;
        }
        

        EggImage.SetActive(true);
        //yield return new WaitForSeconds(summonDragonFirstSpeed);


        //// ������
        //for (int i = 0; i < eggAnimNum; i++)
        //{
        //    DragonImage.SetActive(false);
        //    EggImage.SetActive(true);  // ����\��

        //    yield return new WaitForSeconds(summonDragonSpeed);

        //    EggImage.SetActive(false);  // �����B��
        //    DragonImage.SetActive(true);  // �h���S����\��

        //    yield return new WaitForSeconds(summonDragonSpeed);

        //    summonDragonSpeed *= 0.85f;
        //}


        // �V����
        //RectTransform eggRectTransform = EggImage.GetComponent<RectTransform>();
        //for (float i = eggAnimNum; i > 0; i--)
        //{
        //    Debug.Log($"{eggAnimSpeed / eggAnimNum}");
        //    // ���̑傫�������X�ɏ���������
        //    eggRectTransform.localScale = new Vector3(i / eggAnimNum, i / eggAnimNum, 0);
        //    yield return new WaitForSeconds(eggAnimSpeed / eggAnimNum);
        //}

        EggImage.SetActive(false);  // �����B��
        DispDragonImage.SetActive(true);  // �h���S����\��

        RectTransform dragonRectTransform = DispDragonImage.GetComponent<RectTransform>();
        //Transform dragonTransform = DispDragonImage.GetComponent<Transform>();
        for (float i = 0; i < eggAnimNum; i++)
        {
            Debug.Log($"{(eggAnimSpeed / eggAnimNum) * dragonScale}");
            // �h���S���̑傫�������X�ɑ傫������
            dragonRectTransform.localScale = new Vector3((i / eggAnimNum) * dragonScale, (i / eggAnimNum) * dragonScale, 0);
            //dragonTransform.localScale = new Vector3((i / eggAnimNum) * dragonScale, (i / eggAnimNum) * dragonScale, 0);
            yield return new WaitForSeconds(eggAnimSpeed / eggAnimNum);
        }
        dragonRectTransform.localScale = new Vector3(dragonScale, dragonScale, 0);
        //dragonTransform.localScale = new Vector3(dragonScale, dragonScale, 0);
        Debug.Log(dragonRectTransform.localScale);

        GoHomeButton.SetActive(true);  // �{�^����\��
        GoStageButton.SetActive(true);

        yield return 0;
    }
}