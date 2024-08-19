// �X�e�[�W�ɓ���ۂɕ\�������郁�b�Z�[�W�𑀍삷��X�N���v�g

// �\��+���X�ɕ������\�������+
// ���b�Z�[�W���S�ĕ\�����ꂽ��{�^���\��+
// �X�y�[�X�L�[�������ƃ��b�Z�[�W�𑦑S���\��
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;  // sleep�p
using UnityEngine.EventSystems;


public class DialogBuild : MonoBehaviour
{
    [SerializeField] private StageSelect _stageSelect;

    [SerializeField] private AudioSource _negativeSe;
    [SerializeField] private AudioSource _positiveSe;

    [SerializeField] private Image _button1Image;
    [SerializeField] private Image _button2Image;
    [SerializeField] private Image _button3Image;
    [SerializeField] private Image _button4Image;

    [SerializeField] private TextMeshProUGUI DialogText;
    [SerializeField] private GameObject NoButton;
    [SerializeField] private GameObject GoButton;

    [SerializeField] private Image _selectPanelImage;

    [SerializeField] private Sprite _selectPanelSprite1;
    [SerializeField] private Sprite _selectPanelSprite2;
    [SerializeField] private Sprite _selectPanelSprite3;
    [SerializeField] private Sprite _selectPanelSprite4;
    [TextArea(5, 5)]

    private const string kPlayerPrefsKey = "Progress";

    private float red1, green1, blue1, alpha1;
    private float red2, green2, blue2, alpha2;
    private float red3, green3, blue3, alpha3;
    private float red4, green4, blue4, alpha4;
    
    private bool isStage1 = false;
    private bool isStage2 = false;
    private bool isStage3 = false;
    private bool isStage4 = false;

    private const float kStopColor = 0.6f;
    private const float kDefaultColor = 1.0f;

    //[SerializeField] private string msgText;  // �g��Ȃ��Ȃ���
    private float msgSpeed = 0.03f;  // �e�L�X�g�\���Ԋu
    private float msgSpeedEnter = 0.08f;  // ���s���ҋ@����

    //int stageNum = 0;
    string dialogText = "";  // �񓯊�������foreach���̎w��ł��������̂ŕϐ�������ĉ���������

    [SerializeField] private GameObject Panel;

    void Start()
    {
        // �{�^���̐F�A�s�����x���
        //_button1Image = GetComponent<Image>();
        //_button2Image = GetComponent<Image>();
        //_button3Image = GetComponent<Image>();
        //_button4Image = GetComponent<Image>();

        red1 = _button1Image.color.r;
        green1 = _button1Image.color.g;
        blue1 = _button1Image.color.b;
        alpha1 = _button1Image.color.a;

        red2 = _button2Image.color.r;
        green2 = _button2Image.color.g;
        blue2 = _button2Image.color.b;
        alpha2 = _button2Image.color.a;

        red3 = _button3Image.color.r;
        green3 = _button3Image.color.g;
        blue3 = _button3Image.color.b;
        alpha3 = _button3Image.color.a;

        red4 = _button4Image.color.r;
        green4 = _button4Image.color.g;
        blue4 = _button4Image.color.b;
        alpha4 = _button4Image.color.a;

        // value�͍��܂łŃN���A�����X�e�[�W�̍ō��l
        int value = PlayerPrefs.GetInt(kPlayerPrefsKey);

        Debug.Log($"{red1}{green1}{blue1}");

        switch (value)
        {
            case 0: // �N���A�Ȃ�
                // 2,3,4����
                isStage1 = true;
                isStage2 = false;
                isStage3 = false;
                isStage4 = false;
                break;

            case 1:
                // 3,4
                isStage1 = true;
                isStage2 = true;
                isStage3 = false;
                isStage4 = false;
                break;

            case 2:
                // 4�̂�
                isStage1 = true;
                isStage2 = true;
                isStage3 = true;
                isStage4 = false;
                break;

            case 3:
            case 4:
            default:
                // �S�X�e�[�W�����
                isStage1 = true;
                isStage2 = true;
                isStage3 = true;
                isStage4 = true;
                break;
        }

        StageButtonChangeColor(1, isStage1);
        StageButtonChangeColor(2, isStage2);
        StageButtonChangeColor(3, isStage3);
        StageButtonChangeColor(4, isStage4);

        _button1Image.color = new Color(red1, green1, blue1, alpha1);
        _button2Image.color = new Color(red2, green2, blue2, alpha2);
        _button3Image.color = new Color(red3, green3, blue3, alpha3);
        _button4Image.color = new Color(red4, green4, blue4, alpha4);

        //DialogText.text = dialogText;
        NoButton.SetActive(false);  // �{�^�����B��
        GoButton.SetActive(false);
        //StartCoroutine(TypeDisplay());
    }
    void Update()
    {
        // SelectPanel���o�Ă��Ȃ��Ă��g����̂Ŕp�~
        //if (Input.GetKey(KeyCode.Space)) // �X�y�[�X�L�[�������ꂽ��
        //{
        //    StopAllCoroutines();
        //    //DialogText.text = dialogText;  // DialogText.text�֐���dialogText�ϐ��̒��g����
        //    DialogText.text = "";
        //    foreach (char item in dialogText)
        //    {
        //        if (item == '|')
        //        {
        //            // <br>��DialogText.text�ɑ������
        //            DialogText.text += "<br>";
        //        }
        //        else
        //        {
        //            DialogText.text += item;  // 
        //        }
        //    }
        //    NoButton.SetActive(true);  // �{�^����\��
        //    GoButton.SetActive(true);
        //}
    }

    public void PushButton(int number)
    {
        // value�͍��܂łŃN���A�����X�e�[�W�̍ō��l
        int value = PlayerPrefs.GetInt(kPlayerPrefsKey);

        // num��val���ׂčs���Ȃ��Ȃ�return �ǂ����Ƀ{�^���̐F�ς��鏈������肽��
        // GameObject�����
        bool isPossible = true;
        switch (number)
        {
            case 1:
                _selectPanelImage.sprite = _selectPanelSprite1;
                // false�Ȃ�
                if (!isStage1) isPossible = false;
                break;

            case 2:
                _selectPanelImage.sprite = _selectPanelSprite2;
                if (!isStage2) isPossible = false;
                break;

            case 3:
                _selectPanelImage.sprite = _selectPanelSprite3;
                if (!isStage3) isPossible = false;
                break;

            case 4:
                _selectPanelImage.sprite = _selectPanelSprite4;
                if (!isStage4) isPossible = false;
                break;
        }

        if (isPossible)
        {
            _positiveSe.Play();
        }
        else
        {
            _negativeSe.Play();
            return;
        }

        // �N���X��.�ϐ��� ���ڑ����������Ă�
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

    private void StageButtonChangeColor(int stage, bool isChange)
    {
        Debug.Log($"s{stage},{isChange}");
        switch (stage)
        {
            case 1:
                if (isChange)
                {
                    // �s�����Ƃ��\�Ȃ�
                    // �ύX���Ȃ�
                    red1 = kDefaultColor;
                    green1 = kDefaultColor;
                    blue1 = kDefaultColor;
                }
                else
                {
                    // �s�����Ƃ��\�łȂ��Ȃ�
                    // �ύX����
                    red1 = kStopColor;
                    green1 = kStopColor;
                    blue1 = kStopColor;
                }
                break;

            case 2:
                if (isChange)
                {
                    // �ύX���Ȃ�
                    red2 = kDefaultColor;
                    green2 = kDefaultColor;
                    blue2 = kDefaultColor;
                }
                else
                {
                    // �ύX����
                    red2 = kStopColor;
                    green2 = kStopColor;
                    blue2 = kStopColor;
                }
                break;

            case 3:
                if (isChange)
                {
                    // �ύX���Ȃ�
                    red3 = kDefaultColor;
                    green3 = kDefaultColor;
                    blue3 = kDefaultColor;
                }
                else
                {
                    // �ύX����
                    red3 = kStopColor;
                    green3 = kStopColor;
                    blue3 = kStopColor;
                }
                break;

            case 4:
                if (isChange)
                {
                    // �ύX���Ȃ�
                    red4 = kDefaultColor;
                    green4 = kDefaultColor;
                    blue4 = kDefaultColor;
                }
                else
                {
                    // �ύX����
                    red4 = kStopColor;
                    green4 = kStopColor;
                    blue4 = kStopColor;
                }
                break;
        }
        
    }
}