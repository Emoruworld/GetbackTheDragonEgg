using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class OptionManager : MonoBehaviour
{
    private EventSystem _eventSystem;

    [SerializeField] private AudioSource _negativeSe;
    [SerializeField] private AudioSource _positiveSe;

    [SerializeField] private TextMeshProUGUI _dialogText;

    [SerializeField] private GameObject _dialogPanel;
    [SerializeField] private GameObject _seButton;
    [SerializeField] private GameObject _noButton;
    [SerializeField] private GameObject _goButton;

    [SerializeField] private FadeManager fadeManager;

    private const float kMsgSpeed = 0.09f;
    private string dialogText = "";

    // Start is called before the first frame update
    void Start()
    {
        _eventSystem = EventSystem.current;

        _eventSystem.SetSelectedGameObject(_seButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickTitleButton()
    {
        _positiveSe.Play();

        _dialogText.text = "";
        dialogText = "|Back to Title?";
        StartCoroutine(ScaleChange());
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
        _eventSystem.SetSelectedGameObject(_noButton);
    }

    public void OnclickNoButton()
    {
        _negativeSe.Play();
        _dialogPanel.SetActive(false);
        _eventSystem.SetSelectedGameObject(_seButton);
    }

    public void OnclickGoButton()
    {
        _positiveSe.Play();
        fadeManager.FadeOutSwitch(0);
    }
}
