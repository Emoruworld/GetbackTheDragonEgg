using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;  // UI�R���|�[�l���g�̎g�p
public class test : MonoBehaviour
{
    [SerializeField] Button focusButton;
    // Start is called before the first frame update
    void Start()
    {
        // �{�^���R���|�[�l���g�̎擾
        focusButton = focusButton.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        //�S�Ẵt�H�[�J�X����������
        EventSystem.current.SetSelectedGameObject(null);
        //focusButton�Ƀt�H�[�J�X����
        focusButton.Select();
        //Canvas�R���|�[�l���g�𖳌��ɂ���BButton�R���|�[�l���g�Őݒ�B
    }
}
