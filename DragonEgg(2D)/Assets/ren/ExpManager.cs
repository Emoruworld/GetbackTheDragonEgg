using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;


public class ExpManager : MonoBehaviour
{
    //�h���S���̃f�[�^���擾���邽�߂̕ϐ�(����ύX����\����)
    GameObject childDragon;
    public ChildDragonData childDragonData;
    //�v���C���[���g��EXP
    int useExp;
    //������ʂŕω�����UI(�l�Ƃ�)
    public Slider slider;
    public GameObject textExp;
    public GameObject addExpPoint;
    public GameObject hpPointText;
    public GameObject atkPointText;
    public GameObject levelPointText;
    // Start is called before the first frame update
    void Start()//�t���ƃo�O��
    {
        //�g�p����EXP��I������Ƃ��̃X�s�[�h��60�t���[���ɂ��ė}���Ă�
        Application.targetFrameRate = 60;
        //UI�擾
        childDragon = GameObject.Find("ChildDragon");
        textExp = GameObject.Find("ExpText");
        addExpPoint = GameObject.Find("AddExpPoint");
        hpPointText  = GameObject.Find("HpPoint");
        atkPointText = GameObject.Find("AtkPoint");
        levelPointText = GameObject.Find("LevelPoint");
    }

    //Update is called once per frame
    void Update()
    {
        //UI�̐�����ύX�@(�\��)�֐��ō���ĕύX����Ƃ������Ăяo�����`�ɂ�����
        textExp.GetComponent<TextMeshProUGUI>().text = "EXP  " + childDragonData.exp.ToString() + '/' + childDragonData.nextNeedExp.ToString();//�e�L�X�g
        addExpPoint.GetComponent<TextMeshProUGUI>().text = "ADD EXP? " + '+' + useExp.ToString();
        hpPointText.GetComponent<TextMeshProUGUI>().text = childDragonData.hp.ToString();
        atkPointText .GetComponent<TextMeshProUGUI>().text = childDragonData.attack.ToString();
        levelPointText .GetComponent<TextMeshProUGUI>().text = childDragonData.Level.ToString();
        
        //�g��EXP�̗ʂ����߂�@(�\��)���̂܂܂��ƃ��x������C�ɏグ�����Ƃ��ɕs�ւȂ̂ŉ��ǂ�����
        if (Input.GetKey(KeyCode.RightArrow) && childDragonData.Level != 100)
        {
            useExp = useExp + 10;
            Debug.Log(useExp);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && childDragonData.Level != 100)
        {
            useExp = useExp - 10;
            Debug.Log(useExp);
            if (useExp <= 0)
            {
                useExp = 0;
            }
        }
        //�g��EXP�̗ʂ��m�肷��
        if (Input.GetKeyDown(KeyCode.Space) && childDragonData.Level != 100)
        {
            expManager(useExp);
            useExp = 0;
        }
        //slinder��maxValue��value�̒l��ύX����EXP�o�[�̕\�L��ύX
        slider.maxValue = childDragonData.nextNeedExp;//maxExp;
        slider.value = childDragonData.exp;
        if(childDragonData.Level >= 100)
        {
            slider.maxValue = childDragonData.nextNeedExp;//maxExp;
            slider.value = childDragonData.nextNeedExp;
        }
    }
    //�g��EXP��������EXP�ɉ����ă��x�����オ��ꍇ�͂���ɉ���������������
    (int, int) expManager(int getExp) //�^�v��
    {
        //������EXP�Ɏg��EXP��������
        childDragonData.exp += getExp;
        //���������x�����オ��Ȃ�
        while(childDragonData.exp > childDragonData.nextNeedExp)
        {
            //���̃��x���A�b�v�ɕK�v��EXP�𒴂������̏���
            if (childDragonData.nextNeedExp <= childDragonData.exp && childDragonData.Level != 100)
            {
                childDragonData.exp -= childDragonData.nextNeedExp;
                childDragonData.nextNeedExp = (int)(childDragonData.nextNeedExp * 1.1f);
                childDragonData.Level++;
                childDragonData.attack = Attack();
                childDragonData.hp = Hp();
            }
            //���x����100�ɂȂ����炱��ȏ�X�e�[�^�X���オ��Ȃ��悤�ɂ���
            else if (childDragonData.Level >= 100)
            {
                childDragonData.nextNeedExp = (int)(childDragonData.nextNeedExp * 1.1f);
                childDragonData.exp = childDragonData.nextNeedExp;
                childDragonData.Level = 100;
                childDragonData.attack = Attack();
                childDragonData.hp = Hp();
            }
        }
        return (childDragonData.exp, childDragonData.nextNeedExp);
    }
    //���x�����オ�������̍U���͂̏㏸�l
    int Attack()
    {
        childDragonData.attack += Random.Range(1, 5);
        //�ۑ�
        PlayerPrefs.SetFloat("Hp", childDragonData.hp);
        return childDragonData.attack;
    }
    //���x�����オ��������HP�̏㏸�l
    int Hp()
    {
        childDragonData.hp += Random.Range(1, 5);
        //�ۑ�
        PlayerPrefs.SetInt("Attack", childDragonData.attack);
        return childDragonData.hp;
    }
}
