using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageSelect : MonoBehaviour
{
    [SerializeField] private GameObject _stageUI;
    [SerializeField] private GameObject _selectUI;//UI���A�^�b�`
    [SerializeField] private GameObject _stageButton;//�{�^�����A�^�b�`

    void Start()
    {
    }

    void Update()
    {

    }

    public void OnPressed()
    {
        Debug.Log("test");
        _selectUI.SetActive(true);
    }
    public void SummonStageSelect()
    {
        Debug.Log("test");
        _stageUI.SetActive(true);
    }
}