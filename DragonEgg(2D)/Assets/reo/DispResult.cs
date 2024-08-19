// �X�e�[�W�ɓ���ۂɕ\�������郁�b�Z�[�W�𑀍삷��X�N���v�g

// �\��+���X�ɕ������\�������+
// ���b�Z�[�W���S�ĕ\�����ꂽ��{�^���\��+
// �X�y�[�X�L�[�������ƃ��b�Z�[�W�𑦑S���\��
using System.Collections;
using UnityEngine;
using UnityEngine.UI; // ���Ƃ�
using UnityEngine.SceneManagement;
using TMPro;
using System.Threading;  // sleep�p



public class DispResult : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _resultText;
    [SerializeField] private GameObject _goHomeButton;
    [SerializeField] private GameObject _goStageButton;
    [SerializeField] private GameObject _dragonImage1;
    [SerializeField] private GameObject _dragonImage2;
    [SerializeField] private GameObject _dragonImage3;
    [SerializeField] private GameObject _dragonImage4;
    [TextArea(5, 5)]
    //
    private GameObject _dispDragonImage;

    private const string kSceneName = "ClearScene";
    private const string kPlayerPrefsKey = "Progress";

    private float msgSpeed = 0.03f;  // �e�L�X�g�\���Ԋu
    private float msgLineSpeedEnter = 0.08f;  // ���s���ҋ@����
    private float msgSpeedEnter = 0.01f;  // ���ҋ@����
    private int dragonAnimNum = 10;  // �A�j���[�V�����̊��鐔
    private float dragonAnimSpeed = 0.6f;  // �A�j���[�V�����̑��x

    private float dragonScale = 3.5f;

    //int stageNum = 0;
    string dialogText = "";  // �񓯊�������foreach���̎w��ł��������̂ŕϐ�������ĉ���������

    [SerializeField] private GameObject Panel;

    // ���O�ɃN���A���Ă����X�e�[�W
    int clearStageNum = 0;
    // true�ɂȂ��dragon�\��
    bool isFirstClear = false;
    

    void Start()
    {
        _goHomeButton.SetActive(false);  // �{�^�����B��
        _goStageButton.SetActive(false);
        _dragonImage1.SetActive(false);
        _dragonImage2.SetActive(false);
        _dragonImage3.SetActive(false);
        _dragonImage4.SetActive(false);
        //StartCoroutine(TypeDisplay());

        DispResultFunc();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha0))
        {
            Debug.Log($"{kPlayerPrefsKey}.Change:0");
            PlayerPrefs.SetInt(kPlayerPrefsKey, 0);
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Debug.Log($"{kPlayerPrefsKey}.Change:1");
            PlayerPrefs.SetInt(kPlayerPrefsKey, 1);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            Debug.Log($"{kPlayerPrefsKey}.Change:2");
            PlayerPrefs.SetInt(kPlayerPrefsKey, 2);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            Debug.Log($"{kPlayerPrefsKey}.Change:3");
            PlayerPrefs.SetInt(kPlayerPrefsKey, 3);
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            Debug.Log($"{kPlayerPrefsKey}.Change:4");
            PlayerPrefs.SetInt(kPlayerPrefsKey, 4);
        }

        // �o�O�肻���Ȃ̂Ŕp�~
        //if (Input.GetKey(KeyCode.Space)) // �X�y�[�X�L�[�������ꂽ��
        //{
        //    StopAllCoroutines();

            //    //DialogText.text = dialogText;  // DialogText.text�֐���dialogText�ϐ��̒��g����
            //    _resultText.text = "";
            //    foreach (char item in dialogText)
            //    {
            //        if (item == '|')
            //        {
            //            // <br>��DialogText.text�ɑ������
            //            _resultText.text += "<br>";
            //        }
            //        else if (item == '/')
            //        {
            //            // �������Ȃ�
            //        }
            //        else
            //        {
            //            _resultText.text += item;  // 
            //        }
            //    }

            //    _dispDragonImage = GetDispDragonImage();

            //    // ���N���A�Ȃ�h���S����\��
            //    if (isFirstClear) _dispDragonImage.SetActive(true);

            //    _goHomeButton.SetActive(true);  // �{�^����\��
            //    _goStageButton.SetActive(true);
            //}
    }

    public void DispResultFunc()
    {
        // 0~4
        //int debug = 0;
        //PlayerPrefs.SetInt(kPlayerPrefsKey, debug);

        //Debug.Log($"DispResultFunc.Debug PlayerPrefs.{kPlayerPrefsKey} = {debug}");

        clearStageNum = GetClearStageNum();

        // debug
        //isFirstClear = true;
        //clearStageNum = 4;

        Debug.Log($"DispResultFunc.Debug isFirstClear = {isFirstClear}");



        _resultText.text = "";
        dialogText = "//////S/t/a/g/e// C/l/e/a/r/!/!/||";  // dialogText�ϐ��ɕ�����

        if (isFirstClear)
        {
            // ���N���A�Ȃ�
            dialogText += "Rescue Dragon///|";
        }

        _goHomeButton.SetActive(false);  // �{�^�����B��
        _goStageButton.SetActive(false);

        StartCoroutine(TypeDisplay());  // ���b�Z�[�W�\�����J�n
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
        _goHomeButton.SetActive(false);  // �{�^�����B��
        _goStageButton.SetActive(false);
        //_dragonImage1.SetActive(false);

        foreach (char item in dialogText)
        {
            if (item == '|')
            {
                // <br>��DialogText.text�ɑ������
                _resultText.text += "<br>";
                yield return new WaitForSeconds(msgLineSpeedEnter);
            }
            else if (item == '.')
            {
                _resultText.text += item;
                yield return new WaitForSeconds(msgSpeedEnter);
            }
            else if (item == '/')
            {
                // �\�������҂���
                yield return new WaitForSeconds(msgSpeedEnter);
            }
            else
            {
                _resultText.text += item;  // 
            }


            yield return new WaitForSeconds(msgSpeed);  // ���b�Z�[�W��msgSpeed���ɕ\���H
        }

        if (isFirstClear)
        {
            StartCoroutine(EggAnim());  // ���\�����J�n
        }
        else
        {
            _goHomeButton.SetActive(true);  // �{�^����\��
            _goStageButton.SetActive(true);
        }
        
    }

    IEnumerator EggAnim()  // ������h���S���֕ς���
    {
        _dispDragonImage = GetDispDragonImage();


        _dispDragonImage.SetActive(true);  // �h���S����\��

        RectTransform dragonRectTransform = _dispDragonImage.GetComponent<RectTransform>();
        //Transform dragonTransform = DispDragonImage.GetComponent<Transform>();
        for (float i = 0; i < dragonAnimNum; i++)
        {
            //Debug.Log($"{(dragonAnimSpeed / dragonAnimNum) * dragonScale}");
            // �h���S���̑傫�������X�ɑ傫������
            dragonRectTransform.localScale = new Vector3((i / dragonAnimNum) * dragonScale, (i / dragonAnimNum) * dragonScale, 0);
            //dragonTransform.localScale = new Vector3((i / dragonAnimNum) * dragonScale, (i / dragonAnimNum) * dragonScale, 0);
            yield return new WaitForSeconds(dragonAnimSpeed / dragonAnimNum);
        }
        dragonRectTransform.localScale = new Vector3(dragonScale, dragonScale, 0);
        //dragonTransform.localScale = new Vector3(dragonScale, dragonScale, 0);
        Debug.Log(dragonRectTransform.localScale);

        _goHomeButton.SetActive(true);  // �{�^����\��
        _goStageButton.SetActive(true);

        yield return 0;
    }

    private GameObject GetDispDragonImage()
    {
        GameObject GameObject = _dragonImage1;

        switch (clearStageNum)
        {
            case 1:
                GameObject = _dragonImage1;
                break;

            case 2:
                GameObject = _dragonImage2;
                break;

            case 3:
                GameObject = _dragonImage3;
                break;

            case 4:
                GameObject = _dragonImage4;
                break;

            default:
                Debug.Log("EggAnimError");
                break;
        }

        return GameObject;
    }

    private int GetClearStageNum()
    {
        // ���O�ɃN���A�����X�e�[�W�����̃V�[���̖��O���狁�߂�
        string s = SceneManager.GetActiveScene().name;


        Debug.Log(s);

        for (int i = 1; i < 5; i++)
        {
            Debug.Log(kSceneName + i);
            // ��������������break
            if (s == kSceneName + i) { clearStageNum = i; break; }
        }

        // �G���[����
        if (clearStageNum == 0) { Debug.Log("SceneNumError"); return 0; }

        // value�͍��܂łŃN���A�����X�e�[�W�̍ō��l
        int value = PlayerPrefs.GetInt(kPlayerPrefsKey);

        Debug.Log($"v = {value}, num = {clearStageNum}");

        // value��1����(value���A�ł���������)�X�V������
        if (value == clearStageNum - 1)
        {
            PlayerPrefs.SetInt(kPlayerPrefsKey, clearStageNum);
            isFirstClear = true;
        }

        return clearStageNum;
    }
}