using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ドラゴンBoxの処理の中で呼び出してね
public class DragonData
{
    // 記録できるデータの数
    private const int DATANUMBER = 10;
    // キーの固定の文字
    private const string KEYBASE = "Dragon_";

    // ドラゴンのデータが入った型の配列を作る
    // データの0番目は親ドラゴンにしよう
    // でもこれゲーム中ずっと存在するのは無駄があるなあ。べつにいいかあ。
    // 6/18　Staticクラスでなくする方針にしました
    public TestDragonStatus[] dragonData = new TestDragonStatus[DATANUMBER];

    // メンバ関数
    public void LoadAllDragonData() // PlayerPlefsから全データを取得
    {
        for (int i = 0; i < DATANUMBER; i++)
        {
            // KEYBASE〇〇の形でキーを作る
            string key = KEYBASE + i.ToString();

            // TestDragonStatus型に格納
            TestDragonStatus data = new TestDragonStatus(PlayerPrefs.GetString(key));
            // 配列に保存
            dragonData[i] = data;
        }
    }

    public TestDragonStatus GetDragonData(int index)
    {
        return dragonData[index];
    }

    // 配列のデータを全部PlayerPrefsに保存
    public void SaveAllData()
    {
        // for ぶんぶんまわす
        for (int i = 0; i < DATANUMBER; i++)
        {
            SaveData(i);
        }
    }

    // 一つのデータだけセーブ
    // 引数の番地のデータを保存
    public void SaveData(int index)
    {
        // playerprefsに捧げるstring
        string keyString = KEYBASE + index.ToString();
        // 取り出す
        TestDragonStatus temp = dragonData[index];
        // セーブ
        PlayerPrefs.SetString(keyString, temp.dataString);
    }
}
//今後セーブを追加