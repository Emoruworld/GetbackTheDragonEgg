using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ExpManager : MonoBehaviour
{
    // �G�f�B�^�ŃA�^�b�`
    [SerializeField] public ChildDragonData childDragonData;

    
    int maxExp;//���x���A�b�v�ɕK�v�ȗ�
    int nowExp;
    int addExp = 30; //������o���l
    
    public Slider slider;
    // Start is called before the first frame update
    void Start()//�t���ƃo�O��
    {
        maxExp = 100;
        slider.maxValue = maxExp;
        nowExp = childDragonData.exp; //���݂̌o���l
        slider.value = nowExp;
        
    }

    //Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

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


}
