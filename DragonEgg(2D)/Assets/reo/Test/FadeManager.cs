using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // scene切り替えを行うため
using UnityEngine.EventSystems;

// フェードイン、フェードアウト管理スクリプト

public class FadeManager : MonoBehaviour
{
    float time = 0.0f;
    float fadeSpeed = 1.0f;        //フェードする速度 秒
    float red, green, blue, alpha;  //alfaくらいしか使わない
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
        alpha = fadeImage.color.a;

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
        // コントローラー対応
        if (0 < Input.GetAxisRaw("Vertical"))
        {
            // 選択中のオブジェクト取得
            GameObject nowObj = EventSystem.current.currentSelectedGameObject;
        }

        if (number != 0)
        {
            LoadingScene.stageNum = number;
        }

        switch (LoadingScene.stageNum)  // シーン切り替え
        {
            //case 100:
            //    loadScene = "TestStageSelectScene";
            //    break;
            case 100:
                loadScene = "StageSelectScene";
                break;
            case 101:
                loadScene = "HomeScene";
                break;

            case 102:
                loadScene = "ReinforcementScene";  // "ren"
                break;
            case 103:
                loadScene = "OptionScene";
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
        alpha = 0;
        Out = true;
    }

    private void FadeIn()    // フェードイン処理
    {
        // 不透明度をfadeSpeedずつ減らす
        //alpha -= fadeSpeed;
        time += Time.deltaTime;
        alpha = 1.0f - time / fadeSpeed;
        //alpha -= fadeSpeed * Time.deltaTime;
        ChangeColor();
        if (alpha <= 0)
        {
            In = false;
            fadeImage.enabled = false;
        }
    }

    private void FadeOut()    // フェードアウト処理
    {
        fadeImage.enabled = true;
        // 不透明度をfadeSpeedずつ増やす
        //alpha += fadeSpeed;
        time += Time.deltaTime;
        alpha = 1.0f - time / fadeSpeed;
        //alpha += fadeSpeed * Time.deltaTime;
        ChangeColor();

        // 完全に不透明になったらシーン移行
        if (alpha >= 1)
        {
            Out = false;
            SceneManager.LoadSceneAsync(loadScene);
        }
    }

    // 増減処理を反映
    private void ChangeColor()
    {
        fadeImage.color = new Color(red, green, blue, alpha);
    }
}
