using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StageSelect : MonoBehaviour
{
    FadeManager FadeManager;

    EventSystem _eventSystem;

    //[SerializeField] private GameObject _stageUI;
    [SerializeField] private GameObject _selectUI;
    [SerializeField] private GameObject _shadePanel;//UIをアタッチ
    //[SerializeField] private GameObject _stageButton;//ボタンをアタッチ

    [SerializeField] private GameObject _noButton;
    [SerializeField] private GameObject _stageButton1;

    public bool isSelectUiActive = false;

    void Start()
    {
        _eventSystem = EventSystem.current;

        

        //
    }

    void Update()
    {

    }

    public bool OnSelectPressed(int number)
    {
        if (!isSelectUiActive)  // selectUIが出ていないなら
        {
            Debug.Log("StageSelect");
            _selectUI.SetActive(true);
            _shadePanel.SetActive(true);
            _eventSystem.SetSelectedGameObject(_noButton);

            return true;
        }
        else
        {
            Debug.Log("StageSelectFailed");

            return false;
        }
    }

    public void OnNoButtonPressed()
    {
        _selectUI.SetActive(false);
        _shadePanel.SetActive(false);
        _eventSystem.SetSelectedGameObject(_stageButton1);
    }

    public void SummonStageSelect()
    {
        Debug.Log("NoButton");
        //_stageUI.SetActive(true);
    }


}