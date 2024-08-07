using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;


public class ExpManager : MonoBehaviour
{
    //ドラゴンのデータを取得するための変数(今後変更する可能性大)
    GameObject childDragon;
    public TestDragonStatus childDragonData;
    //プレイヤーが使うEXP
    int useExp;
    // 経験値必要量の基礎地
    const int EXPBASE = 10;
    //強化画面で変化するUI(値とか)
    public Slider slider;
    public GameObject textExp;
    public GameObject addExpPoint;
    public GameObject hpPointText;
    public GameObject atkPointText;
    public GameObject levelPointText;
    // Start is called before the first frame update
    void Start()//逆だとバグる
    {
        //使用するEXPを選択するときのスピードを60フレームにして抑えてる
        Application.targetFrameRate = 60;
        //UI取得
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
        //UIの数字を変更　(予定)関数で作って変更するときだけ呼び出される形にしたい
        textExp.GetComponent<TextMeshProUGUI>().text = "EXP  " + childDragonData.nowExp.ToString() + '/' + childDragonData.nextExp.ToString();//テキスト
        addExpPoint.GetComponent<TextMeshProUGUI>().text = "ADD EXP? " + '+' + useExp.ToString();
        hpPointText.GetComponent<TextMeshProUGUI>().text = childDragonData.hp.ToString();
        atkPointText .GetComponent<TextMeshProUGUI>().text = childDragonData.attack.ToString();
        levelPointText .GetComponent<TextMeshProUGUI>().text = childDragonData.level.ToString();
        
        //使うEXPの量を決める　(予定)今のままだとレベルを一気に上げたいときに不便なので改良したい
        if (Input.GetKey(KeyCode.RightArrow) && childDragonData.level != 100)
        {
            useExp = useExp + 10;
            Debug.Log(useExp);
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && childDragonData.level != 100)
        {
            useExp = useExp - 10;
            Debug.Log(useExp);
            if (useExp <= 0)
            {
                useExp = 0;
            }
        }
        //使うEXPの量を確定する
        if (Input.GetKeyDown(KeyCode.Space) && childDragonData.level != 100)
        {
            expManager(useExp);
            useExp = 0;
        }
        //slinderのmaxValueとvalueの値を変更してEXPバーの表記を変更
        slider.maxValue = childDragonData.nextExp;//maxExp;
        slider.value = childDragonData.nowExp;
        if(childDragonData.level >= 100)
        {
            slider.maxValue = childDragonData.nextExp;//maxExp;
            slider.value = childDragonData.nextExp;
        }
    }
    //使うEXPを自分のEXPに加えてレベルが上がる場合はそれに応じた処理をする
    (int, int) expManager(int getExp) //タプル
    {
        //自分のEXPに使うEXPを加える
        childDragonData.nowExp += getExp;
        //もしもレベルが上がるなら
        while(childDragonData.nowExp > childDragonData.nextExp)
        {
            //次のレベルアップに必要なEXPを超えた時の処理
            if (childDragonData.nextExp <= childDragonData.nowExp && childDragonData.level != 100)
            {
                childDragonData.nowExp -= childDragonData.nextExp;
                // for分でlevel乗の計算をする
                childDragonData.level++;
                childDragonData.attack = Attack();
                childDragonData.hp = Hp();
            }
            //レベルが100になったらこれ以上ステータスが上がらないようにする
            else if (childDragonData.level >= 100)
            {
                childDragonData.nowExp = childDragonData.nextExp;
                childDragonData.level = 100;
                childDragonData.attack = Attack();
                childDragonData.hp = Hp();
            }
        }
        return (childDragonData.nowExp, childDragonData.nextExp);
    }
    //レベルが上がった時の攻撃力の上昇値
    int Attack()
    {
        childDragonData.attack += Random.Range(1, 5);
        //保存
        PlayerPrefs.SetFloat("Hp", childDragonData.hp);
        return childDragonData.attack;
    }
    //レベルが上がった時のHPの上昇値
    int Hp()
    {
        childDragonData.hp += Random.Range(1, 5);
        //保存
        PlayerPrefs.SetInt("Attack", childDragonData.attack);
        return childDragonData.hp;
    }
}
