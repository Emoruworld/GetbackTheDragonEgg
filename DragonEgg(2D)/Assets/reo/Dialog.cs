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
    [SerializeField] private string msgText;
    private float msgSpeed = 0.03f;  // �e�L�X�g�\���Ԋu
    void Start()
    {
        DialogText.text = "";
        _noButton.SetActive(false);  // �{�^�����B��
        _goButton.SetActive(false);
        StartCoroutine(TypeDisplay());
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) // �X�y�[�X�L�[�������ꂽ��
        {
            StopAllCoroutines();
            DialogText.text = msgText;
            _noButton.SetActive(true);  // �{�^����\��
            _goButton.SetActive(true);
        }
    }
    IEnumerator TypeDisplay()  // ���b�Z�[�W��\��������@�\�H IEnumerator�͔񓯊��������s�����߂ɗp����f�[�^�^�̈��
    {
        foreach (char item in msgText.ToCharArray())
        {
            DialogText.text += item;
            yield return new WaitForSeconds(msgSpeed);  // ���b�Z�[�W��msgSpeed���ɕ\���H
        }
        _noButton.SetActive(true);  // �{�^����\��
        _goButton.SetActive(true);
    }
}