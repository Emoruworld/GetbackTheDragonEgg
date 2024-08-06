using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControllerButtonOn : MonoBehaviour
{
    public Button focusButton;

    void Start()
    {
        // �{�^���R���|�[�l���g�̎擾
        focusButton = focusButton.GetComponent<Button>();
    }

    public void OnClick()
    {
        //�S�Ẵt�H�[�J�X����������
        EventSystem.current.SetSelectedGameObject(null);
        //focusButton�Ƀt�H�[�J�X����
        focusButton.Select();
        //Canvas�R���|�[�l���g�𖳌��ɂ���BButton�R���|�[�l���g�Őݒ�B
    }
}