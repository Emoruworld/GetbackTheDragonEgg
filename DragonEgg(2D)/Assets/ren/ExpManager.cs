using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ExpManager : MonoBehaviour
{
    int maxExp;//���x���A�b�v�ɕK�v�ȗ�
    int nowExp;      //���݂̌o���l
    int addExp = 30; //������o���l
    public ChildDragonData childDragonData;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = 0;
        maxExp = 100;
        slider.maxValue = maxExp;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShowScriptableObjectData();
            nowExp += addExp;//�o���l��������
            slider.value = (float)nowExp;
        }

        if (maxExp <= nowExp)//���x���A�b�v�����Ƃ����̃��x���A�b�v�ɕK�v�ȗʂ��X�V
        {
            nowExp = nowExp - maxExp;
            slider.value = nowExp;
            maxExp += 100;
            slider.maxValue = maxExp;
        }
    }

    void ShowScriptableObjectData()
    {
        // �Q�Ƃ��Ă���EnemyData�̒��g���R���\�[���ɕ\������
        Debug.Log(childDragonData.Exp);
    }
}
