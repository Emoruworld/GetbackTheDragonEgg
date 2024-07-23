using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDragonManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fireDragon;
    public GameObject iceDragon;
    public GameObject windDragon;
    public GameObject thunderDragon;
    public static int selectDragonNum;
    //public static int selectDragonNum;
    void Start()
    {
        selectDragonNum = 0;//�ŏ��͉����\���������Ȃ��̂ŁA���蓖�Ă����Ă��Ȃ��ԍ��������܂�
    }

    public static int DragonNumber()
    {
        return selectDragonNum;
    }

    public void FireDragon()
    {
        selectDragonNum = 0;
        fireDragon.SetActive(true);
        iceDragon.SetActive(false);
        windDragon.SetActive(false);
        thunderDragon.SetActive(false);
    }

    public void IceDragon()
    {
        selectDragonNum = 1;
        iceDragon.SetActive(true);
        fireDragon.SetActive(false);
        windDragon.SetActive(false);
        thunderDragon.SetActive(false);
    }

    public void WindDragon()
    {
        selectDragonNum = 2;
        windDragon.SetActive(true);
        fireDragon.SetActive(false);
        iceDragon.SetActive(false);
        thunderDragon.SetActive(false);
    }
    public void ThunderDragon()
    {
        selectDragonNum = 3;
        thunderDragon.SetActive(true);
        fireDragon.SetActive(false);
        iceDragon.SetActive(false);
        windDragon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        

        switch (selectDragonNum)
        {
            case 0:
                FireDragon();
                break;
            case 1:
                IceDragon();
                break;
            case 2:
                WindDragon();
                break;
            case 3:
                ThunderDragon();
                break;
            default:
                Debug.Log("�o�O���Ă�");
                break;

        }
    }
}