using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // scene�؂�ւ����s������

// �t�F�[�h�C���A�t�F�[�h�A�E�g�Ǘ��X�N���v�g

public class FadeManager : MonoBehaviour
{
    float speed = 0.001f;        //�t�F�[�h����X�s�[�h�A�����Ƒ����t�F�[�h����
    float red, green, blue, alfa;
    string loadScene = "TestErrorScene";  // ���[�h����V�[���̖��O

    // �t�F�[�h�C���A�t�F�[�h�A�E�g���Ǘ�����X�C�b�`
    public bool Out = false;
    public bool In = false;

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
        alfa = fadeImage.color.a;

        // �V�[�����ǂݍ��܂ꂽ�Ƃ��Ƀt�F�[�h�C������
        FadeInSwitch();
    }

    void Update()
    {

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
        fadeImage.enabled = true;
        In = true;
    }

    public void FadeOutSwitch(int number)  // �{�^������󂯎�����������Ƃ炵���킹��
    {
        if (number != 0)
        {
            LoadingScene.stageNum = number;
        }

        switch (LoadingScene.stageNum)  // �V�[���؂�ւ�
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

        // �s�����x��0(����)�ɂ��A�t�F�[�h�A�E�g�����J�n
        alfa = 0;
        Out = true;
    }

    void FadeIn()    // �t�F�[�h�C������
    {
        // �s�����x��speed�����炷
        alfa -= speed;
        Alpha();
        if (alfa <= 0)
        {
            In = false;
            fadeImage.enabled = false;
        }
    }

    void FadeOut()    // �t�F�[�h�A�E�g����
    {
        fadeImage.enabled = true;
        // �s�����x��speed�����₷
        alfa += speed;
        Alpha();

        // ���S�ɕs�����ɂȂ�����V�[���ڍs
        if (alfa >= 1)
        {
            Out = false;
            SceneManager.LoadSceneAsync(loadScene);
        }
    }

    // ���������𔽉f
    void Alpha()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
}