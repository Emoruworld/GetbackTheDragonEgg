// �\��+���X�ɕ������\�������+
// ���b�Z�[�W���S�ĕ\�����ꂽ��{�^���\��+
// �X�y�[�X�L�[�������ƃ��b�Z�[�W�𑦑S���\��
using System.Collections;
using UnityEngine;
using TMPro;
public class DialogBuild : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI DialogText;
    [SerializeField] private GameObject _noButton;
    [SerializeField] private GameObject _goButton;
    [TextArea(5, 5)]
    //[SerializeField] private string msgText;  // �g��Ȃ��Ȃ���
    private float msgSpeed = 0.07f;  // �e�L�X�g�\���Ԋu

    //int stageNum = 0;
    string dialogText = "";  // �񓯊�������foreach���̎w��ł��������̂ŕϐ�������ĉ���������

    void Start()
    {
        //DialogText.text = dialogText;
        _noButton.SetActive(false);  // �{�^�����B��
        _goButton.SetActive(false);
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
            _noButton.SetActive(true);  // �{�^����\��
            _goButton.SetActive(true);
        }
    }

    public void Push_Button(int number)
    {
        // �N���X��.�ϐ���
        LoadingScene.stageNum = number;  // �{�^��������X�e�[�W�����擾
        DialogText.text = "";
        dialogText = "Stage " + LoadingScene.stageNum + "||Ready?";  // dialogText�ϐ��ɕ�����
        StartCoroutine(TypeDisplay());  // ���b�Z�[�W�\�����J�n
        
        Debug.Log("Stage " + LoadingScene.stageNum + "||Ready?");
        Debug.Log(DialogText.text);
    }

    IEnumerator TypeDisplay()  // ���b�Z�[�W��\��������@�\�H IEnumerator�͔񓯊��������s�����߂ɗp����f�[�^�^�̈��
    {
        foreach (char item in dialogText)
        {
            if(item == '|')
            {
                // <br>��DialogText.text�ɑ������
                DialogText.text += "<br>";
            }
            else
            {
                DialogText.text += item;  // 
            }

            
            yield return new WaitForSeconds(msgSpeed);  // ���b�Z�[�W��msgSpeed���ɕ\���H
        }
        _noButton.SetActive(true);  // �{�^����\��
        _goButton.SetActive(true);
    }
}