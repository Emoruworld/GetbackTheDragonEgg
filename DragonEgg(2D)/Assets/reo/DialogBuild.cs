// �X�e�[�W�ɓ���ۂɕ\�������郁�b�Z�[�W�𑀍삷��X�N���v�g

// �\��+���X�ɕ������\�������+
// ���b�Z�[�W���S�ĕ\�����ꂽ��{�^���\��+
// �X�y�[�X�L�[�������ƃ��b�Z�[�W�𑦑S���\��
using System.Collections;
using UnityEngine;
using TMPro;
using System.Threading;  // sleep�p
using UnityEngine.EventSystems;


public class DialogBuild : MonoBehaviour
{
    [SerializeField] private StageSelect _stageSelect;

    [SerializeField] private TextMeshProUGUI DialogText;
    [SerializeField] private GameObject NoButton;
    [SerializeField] private GameObject GoButton;
    [TextArea(5, 5)]
    //[SerializeField] private string msgText;  // �g��Ȃ��Ȃ���
    private float msgSpeed = 0.03f;  // �e�L�X�g�\���Ԋu
    private float msgSpeedEnter = 0.08f;  // ���s���ҋ@����

    //int stageNum = 0;
    string dialogText = "";  // �񓯊�������foreach���̎w��ł��������̂ŕϐ�������ĉ���������

    [SerializeField] private GameObject Panel;

    void Start()
    {
        //DialogText.text = dialogText;
        NoButton.SetActive(false);  // �{�^�����B��
        GoButton.SetActive(false);
        //StartCoroutine(TypeDisplay());
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) // �X�y�[�X�L�[�������ꂽ��
        {
            StopAllCoroutines();
            //DialogText.text = dialogText;  // DialogText.text�֐���dialogText�ϐ��̒��g����
            DialogText.text = "";
            foreach (char item in dialogText)
            {
                if (item == '|')
                {
                    // <br>��DialogText.text�ɑ������
                    DialogText.text += "<br>";
                }
                else
                {
                    DialogText.text += item;  // 
                }
            }

            //DialogText.text = msgText;  // �g��Ȃ��Ȃ���
            NoButton.SetActive(true);  // �{�^����\��
            GoButton.SetActive(true);
        }
    }

    public void PushButton(int number)
    {
        // �N���X��.�ϐ���
        LoadingScene.stageNum = number;  // �{�^��������X�e�[�W�����擾

        // OnSelectPressed()�����s���������Ȃ�������return
        if (!(_stageSelect.OnSelectPressed(number))) return;

        DialogText.text = "";
        dialogText = "Stage " + LoadingScene.stageNum + "||Ready?";  // dialogText�ϐ��ɕ�����

        NoButton.SetActive(false);  // �{�^�����B��
        GoButton.SetActive(false);

        StartCoroutine(ScaleChange());
        
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
        NoButton.SetActive(false);  // �{�^�����B��
        GoButton.SetActive(false);

        foreach (char item in dialogText)
        {
            if(item == '|')
            {
                // <br>��DialogText.text�ɑ������
                DialogText.text += "<br>";
                yield return new WaitForSeconds(msgSpeedEnter);
            }
            else
            {
                DialogText.text += item;  // 
            }

            
            yield return new WaitForSeconds(msgSpeed);  // ���b�Z�[�W��msgSpeed���ɕ\���H
        }
        NoButton.SetActive(true);  // �{�^����\��
        GoButton.SetActive(true);
    }
}