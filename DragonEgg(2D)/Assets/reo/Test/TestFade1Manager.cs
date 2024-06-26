using UnityEngine;
using UnityEngine.SceneManagement;  // scene切り替えを行うため
using UnityEngine.UI;

// フェードイン、フェードアウト管理スクリプト

public class TestFade1Manager : MonoBehaviour
{
    float speed = 0.001f;        //フェードするスピード、多いと早くフェードする
    float red, green, blue, alfa;
    string loadScene = "TestErrorScene";  // ロードするシーンの名前

    // フェードイン、フェードアウトを管理するスイッチ
    public bool Out = false;
    public bool In = false;

    Image fadeImage;    //パネル

    // このスクリプトを使う際は
    // ・パネルのImageのチェックボックスを切る
    // ・パネルのalfaを255に設定
    // ・シーン移行するボタンから FadeOutSwitch(int number) を送るように設定する

    void Start()
    {
        // パネルの色、不透明度情報
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;

        // シーンが読み込まれたときにフェードイン処理
        FadeInSwitch();
    }

    void Update()
    {
        
        // スイッチがオンになっているならそれぞれの処理
        if (In)
        {
            FadeIn();
        }

        if (Out)
        {
            FadeOut();
        }

    }

    public void FadeInSwitch()
    {
        fadeImage.enabled = true;
        In = true;
    }

    public void FadeOutSwitch(int number)  // ボタンから受け取った数字を照らし合わせる
    {
        if (number != 0)
        {
            LoadingScene.stageNum = number;
        }

        switch (LoadingScene.stageNum)  // シーン切り替え
        {
            case 100:
                loadScene = "TestStageSelectScene";
                break;

            //case 1:
            //    loadScene = "TestStage1";
            case 1:
                loadScene = "Battle";
                break;
            case 2:
                loadScene = "TestStage2";
                break;
            case 3:
                loadScene = "TestStage3";
                break;
            case 4:
                loadScene = "TestStage4";
                break;

            case 11:
                loadScene = "TestFade1";
                break;
            case 12:
                loadScene = "TestFade2";
                break;

            default:
                loadScene = "TestErrorScene";
                break;


        }

        // 不透明度を0(透明)にし、フェードアウト処理開始
        alfa = 0;
        Out = true;
    }

    void FadeIn()    // フェードイン処理
    {
        // 不透明度をspeedずつ減らす
        alfa -= speed;
        Alpha();
        if (alfa <= 0)
        {
            In = false;
            fadeImage.enabled = false;
        }
    }

    void FadeOut()    // フェードアウト処理
    {
        fadeImage.enabled = true;
        // 不透明度をspeedずつ増やす
        alfa += speed;
        Alpha();

        // 完全に不透明になったらシーン移行
        if (alfa >= 1)
        {
            Out = false;
            SceneManager.LoadSceneAsync(loadScene);
        }
    }

    // 増減処理を反映
    void Alpha()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
}
