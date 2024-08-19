using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // scene�؂�ւ����s������
using UnityEngine.EventSystems;

// �t�F�[�h�C���A�t�F�[�h�A�E�g�Ǘ��X�N���v�g

public class FadeManager : MonoBehaviour
{
    float time = 0.0f;
    float fadeSpeed = 1.0f;        //�t�F�[�h���鑬�x �b
    float red, green, blue, alpha;  //alfa���炢�����g��Ȃ�
    string loadScene = "TestErrorScene";  // ���[�h����V�[���̖��O
    

    // �t�F�[�h�C���A�t�F�[�h�A�E�g���Ǘ�����X�C�b�`
    public bool Out = false;
    public bool In = false;

    // �t�F�[�h�����ۂ�
    public bool isFade = false;

    Image fadeImage;    //�p�l��

    // ���̃X�N���v�g���g���ۂ�
    // �E�p�l����Image�̃`�F�b�N�{�b�N�X��؂�
    // �E�p�l����alfa��255�ɐݒ�
    // �E�V�[���ڍs����{�^������ FadeOutSwitch(int number) �𑗂�悤�ɐݒ肷��

    void Start()
    {
       
        // �p�l���̐F�A�s�����x���
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alpha = fadeImage.color.a;

        // �V�[�����ǂݍ��܂ꂽ�Ƃ��Ƀt�F�[�h�C������
        FadeInSwitch();
    }

    void Update()
    {
        //Debug.Log(StageLoadSceneData.stageLoadScene);
        // �X�C�b�`���I���ɂȂ��Ă���Ȃ炻�ꂼ��̏���
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
        time = 0;
        fadeImage.enabled = true;
        In = true;
        isFade = true;
    }

    public void FadeOutSwitch(int number)  // �{�^������󂯎�����������Ƃ炵���킹��
    {
        if (number != 0)
        {
            LoadingScene.stageNum = number;

            Debug.Log($"Fade:{number}");
        }

        //// �R���g���[���[�Ή�
        //if (0 < Input.GetAxisRaw("Vertical"))
        //{
        //    // �I�𒆂̃I�u�W�F�N�g�擾
        //    GameObject nowObj = EventSystem.current.currentSelectedGameObject;
        //}

        switch (LoadingScene.stageNum)  // �V�[���؂�ւ�
        {
            //case 100:
            //    loadScene = "TestStageSelectScene";
            //    break;
            case 99:
                loadScene = "TitleScene";
                break;
            case 100:
                loadScene = "StageSelectScene";
                break;
            case 101:
                loadScene = "HomeScene";
                break;

            //case 102:
            //    loadScene = "ReinforcementScene";  // "ren"
            //    break;
            case 103:
                loadScene = "OptionScene";
                break;
            case 104:
                loadScene = "CreditScene";
                break;


            //case 1:
            //    loadScene = "TestStage1";
            case 1:
                loadScene = "PartySelectScene";
                //StageLoadSceneData.stageLoadScene = "Battle";
                StageLoadSceneData.stageLoadScene = "Battle1";
                break;
            case 2:
                loadScene = "PartySelectScene";
                //StageLoadSceneData.stageLoadScene = "TestStage2";
                StageLoadSceneData.stageLoadScene = "Battle2";
                break;
            case 3:
                loadScene = "PartySelectScene";
                StageLoadSceneData.stageLoadScene = "Battle3";
                break;
            case 4:
                loadScene = "PartySelectScene";
                StageLoadSceneData.stageLoadScene = "Battle4";
                break;

            //case 11:
            //    loadScene = "TestFade1";
            //    break;
            //case 12:
            //    loadScene = "TestFade2";
            //    break;

            case 10:
                loadScene = "FailScene";
                break;

            case 11:
                loadScene = "ClearScene1";
                break;
            case 12:
                loadScene = "ClearScene2";
                break;
            case 13:
                loadScene = "ClearScene3";
                break;
            case 14:
                loadScene = "ClearScene4";
                break;
            

            default:
                loadScene = "TestErrorScene";
                break;


        }

        // �s�����x��0(����)�ɂ��A�t�F�[�h�A�E�g�����J�n
        alpha = 0;
        time = 0;
        Out = true;
        isFade = true;
    }

    private void FadeIn()    // �t�F�[�h�C������
    {
        // �s�����x��fadeSpeed�����炷
        //alpha -= fadeSpeed;
        time += Time.deltaTime;
        alpha = 1.0f - time / fadeSpeed;
        //alpha -= fadeSpeed * Time.deltaTime;
        ChangeColor();
        if (alpha <= 0)
        {
            In = false;
            fadeImage.enabled = false;
            isFade = false;
        }
    }

    private void FadeOut()    // �t�F�[�h�A�E�g����
    {
        fadeImage.enabled = true;
        // �s�����x��fadeSpeed�����₷
        //alpha += fadeSpeed;
        time += Time.deltaTime;
        alpha = time / fadeSpeed;
        //alpha += fadeSpeed * Time.deltaTime;
        ChangeColor();

        // ���S�ɕs�����ɂȂ�����V�[���ڍs
        if (alpha >= 1)
        {
            Out = false;
            isFade = false;
            SceneManager.LoadScene(loadScene);
        }
    }

    // ���������𔽉f
    private void ChangeColor()
    {
        fadeImage.color = new Color(red, green, blue, alpha);
    }

    public string GetStageLoadScene()
    {
        return StageLoadSceneData.stageLoadScene;
    }
}
