using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class ExpManager : MonoBehaviour
{
    // �G�f�B�^�ŃA�^�b�`
    //[SerializeField] public ChildDragonData childDragonData;
    GameObject FireDragon;

    int maxExpBar;//���x���A�b�v�ɕK�v�ȗ�
    int nowExpBar;
    //int addExp = 30; //������o���l

    public Slider slider;
    // Start is called before the first frame update
    void Start()//�t���ƃo�O��
    {
        FireDragon = GameObject.Find("FireDragon");
    }

    //Update is called once per frame
    void Update()
    {

        slider.maxValue = FireDragon.GetComponent<childDragonStats>().maxExp;//maxExp;
        slider.value = FireDragon.GetComponent<childDragonStats>().exp;
    }

}
