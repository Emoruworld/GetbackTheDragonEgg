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
    private ChildDragonStats childDragonStats;

    int maxExpBar;//���x���A�b�v�ɕK�v�ȗ�
    int nowExpBar;
    //int addExp = 30; //������o���l

    public Slider slider;
    // Start is called before the first frame update
    void Start()//�t���ƃo�O��
    {
        FireDragon = GameObject.Find("FireDragon");
        childDragonStats = FireDragon.GetComponent<ChildDragonStats>();
    }

    //Update is called once per frame
    void Update()
    {

        slider.maxValue = childDragonStats.maxExp;//maxExp;
        slider.value = childDragonStats.exp;
        if(childDragonStats.Level >= 100)
        {
            slider.maxValue = childDragonStats.maxExp;//maxExp;
            slider.value = childDragonStats.maxExp;
        }
    }

}
