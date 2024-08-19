using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TitleManager : MonoBehaviour
{
    EventSystem _eventSystem;

    [SerializeField] private AudioSource _negativeSe;
    [SerializeField] private AudioSource _positiveSe;

    [SerializeField] private TextMeshProUGUI _dialogText;

    [SerializeField] private Image _continueButtonImage;

    [SerializeField] private GameObject _dialogPanel;
    [SerializeField] private GameObject _newgameButton;
    [SerializeField] private GameObject _noButton;
    [SerializeField] private GameObject _goButton;

    [SerializeField] private FadeManager fadeManager;

    private const string kPlayerPrefsKey = "Progress";
    private const float kStopColor = 0.6f;

    private float red, green, blue, alpha;
    private int value;
    private const float kMsgSpeed = 0.09f;
    private string dialogText = "";

    // Start is called before the first frame update
    void Start()
    {
        _eventSystem = EventSystem.current;

        //Debug.Log($"{kPlayerPrefsKey} Change");
        //PlayerPrefs.SetInt(kPlayerPrefsKey, 0);
        
        value = PlayerPrefs.GetInt(kPlayerPrefsKey);

        red = _continueButtonImage.color.r;
        green = _continueButtonImage.color.g;
        blue = _continueButtonImage.color.b;
        alpha = _continueButtonImage.color.a;

        if (value == 0)
        {
            red = kStopColor;
            green = kStopColor;
            blue = kStopColor;
        }

        _continueButtonImage.color = new Color(red, green, blue, alpha);

        _eventSystem.SetSelectedGameObject(_newgameButton);
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void OnClickNewGame()
    {
        _positiveSe.Play();

        value = PlayerPrefs.GetInt(kPlayerPrefsKey);

        if (value != 0)
        {
            // �v���C�ς̏ꍇ
            _dialogText.text = "";
            dialogText = "|Start New Game?";
            StartCoroutine(ScaleChange());
        }
        else
        {
            fadeManager.FadeOutSwitch(101);
        }
    }

    public void OnClickContinue()
    {
        value = PlayerPrefs.GetInt(kPlayerPrefsKey);

        // �Z�[�u�f�[�^���Ȃ�������(0�̏ꍇ)�����Ȃ�
        if (value == 0)
        {
            _negativeSe.Play();
            return;
        }
        else
        {
            _positiveSe.Play();
            fadeManager.FadeOutSwitch(101);
        }
    }

    IEnumerator ScaleChange()
    {
        _noButton.SetActive(false);
        _goButton.SetActive(false);
        _dialogPanel.SetActive(true);

        // ���X�ɑ傫������
        for (int i = 0; i < 10; i++)
        {
            _dialogPanel.transform.localScale = new Vector3(i / 10f, i / 10f, 1);
            yield return new WaitForSeconds(0.06f);
        }
        // scale��1�ɂ���(�ی�)
        _dialogPanel.transform.localScale = new Vector3(1, 1, 1);
        yield return new WaitForSeconds(0.1f);

        StartCoroutine(TypeDisplay());  // ���b�Z�[�W�\�����J�n
    }

    IEnumerator TypeDisplay()
    {
        _noButton.SetActive(false);
        _goButton.SetActive(false);

        foreach (char item in dialogText)
        {
            if (item == '|')
            {
                // <br>��DialogText.text�ɑ������
                _dialogText.text += "<br>";
                yield return 0;
            }
            else
            {
                _dialogText.text += item;
            }

            // ������kMsgSpeed���ɕ\��
            yield return new WaitForSeconds(kMsgSpeed);  
        }
        _noButton.SetActive(true);
        _goButton.SetActive(true);
        _eventSystem.SetSelectedGameObject(_newgameButton);
    }

    public void OnclickNoButton()
    {
        _negativeSe.Play();
        _dialogPanel.SetActive(false);
        _eventSystem.SetSelectedGameObject(_newgameButton);
    }

    public void OnclickGoButton()
    {
        PlayerPrefs.SetInt(kPlayerPrefsKey, 0);
        _positiveSe.Play();
        fadeManager.FadeOutSwitch(101);
    }

    public void OnclickQuitButton()
    {
        _positiveSe.Play();
        Application.Quit();
        //// editor��ŏI�������鏈��
        //UnityEditor.EditorApplication.isPlaying = false;
    }
}
