// �X�e�[�W�ɓ���ۂɕ\�������郁�b�Z�[�W�𑀍삷��X�N���v�g

// �\��+���X�ɕ������\�������+
// ���b�Z�[�W���S�ĕ\�����ꂽ��{�^���\��+
// �X�y�[�X�L�[�������ƃ��b�Z�[�W�𑦑S���\��
using System.Collections;
using UnityEngine;
using TMPro;
using System.Threading;  // sleep�p


public class DispResult : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ResultText;
    [SerializeField] private GameObject GoHomeButton;
    [SerializeField] private GameObject GoStageButton;
    [SerializeField] private GameObject EggImage;
    [SerializeField] private GameObject DragonImage;
    [TextArea(5, 5)]
    //[SerializeField] private string msgText;  // �g��Ȃ��Ȃ���
    private float msgSpeed = 0.03f;  // �e�L�X�g�\���Ԋu
    private float msgSpeedEnter = 0.08f;  // ���s���ҋ@����
    private float summonDragonSpeed = 0.2f;  // �h���S����\������܂ł̑ҋ@����
    private float summonDragonFirstSpeed = 0.5f;  // �h���S����\������܂ł̑ҋ@����
    private int eggAnimNum = 8;  // ����ւ����
    private int tempExp = 1234567;  // exp(��)

    //int stageNum = 0;
    string dialogText = "";  // �񓯊�������foreach���̎w��ł��������̂ŕϐ�������ĉ���������

    [SerializeField] private GameObject Panel;

    int test = 0;

    void Start()
    {
        //DialogText.text = dialogText;
        GoHomeButton.SetActive(false);  // �{�^�����B��
        GoStageButton.SetActive(false);
        EggImage.SetActive(false);
        DragonImage.SetActive(false);
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
                else
                {
                    ResultText.text += item;  // 
                }
            }

            //DialogText.text = msgText;  // �g��Ȃ��Ȃ���
            GoHomeButton.SetActive(true);  // �{�^����\��
            GoStageButton.SetActive(true);

            DragonImage.SetActive(true);  // �h���S����\��
        }
    }

    public void DispResultFunc()
    {
        //ResultText.text = "�l�������o���l ... " + "(�l���o���l)||" + "�������h���S��|" + "(�摜)";
        //ResultText.text = "Get EXP ... " + "(GetEXP)||" + "Rescue Dragon|" + "(dragon.png)";
        //dialogText = "";  // dialogText�ϐ��ɕ�����
        ResultText.text = "";
        dialogText = "Get EXP ... " + tempExp + "||" + "Rescue Dragon|";  //  + "(dragon.png)" dialogText�ϐ��ɕ�����

        GoHomeButton.SetActive(false);  // �{�^�����B��
        GoStageButton.SetActive(false);
        EggImage.SetActive(false);
        DragonImage.SetActive(false);

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

    IEnumerator TypeDisplay()  // ���b�Z�[�W��\��������@�\�H IEnumerator�͔񓯊��������s�����߂ɗp����f�[�^�^�̈��
    {
        GoHomeButton.SetActive(false);  // �{�^�����B��
        GoStageButton.SetActive(false);
        EggImage.SetActive(false);
        DragonImage.SetActive(false);

        foreach (char item in dialogText)
        {
            if (item == '|')
            {
                // <br>��DialogText.text�ɑ������
                ResultText.text += "<br>";
                yield return new WaitForSeconds(msgSpeedEnter);
            }
            else if (item == '.')
            {
                ResultText.text += item;
                yield return new WaitForSeconds(msgSpeedEnter);
            }
            else
            {
                ResultText.text += item;  // 
            }


            yield return new WaitForSeconds(msgSpeed);  // ���b�Z�[�W��msgSpeed���ɕ\���H
        }
        

        StartCoroutine(EggAnim());  // ���\�����J�n
    }

    IEnumerator EggAnim()  // ������h���S���֕ς���
    {
        EggImage.SetActive(true);
        yield return new WaitForSeconds(summonDragonFirstSpeed);

        for (int i = 0; i < eggAnimNum; i++)
        {
            DragonImage.SetActive(false);
            EggImage.SetActive(true);  // ����\��

            yield return new WaitForSeconds(summonDragonSpeed);

            EggImage.SetActive(false);  // �����B��
            DragonImage.SetActive(true);  // �h���S����\��

            yield return new WaitForSeconds(summonDragonSpeed);

            summonDragonSpeed *= 0.85f;
        }

        
        GoHomeButton.SetActive(true);  // �{�^����\��
        GoStageButton.SetActive(true);

        yield return 0;
    }
}