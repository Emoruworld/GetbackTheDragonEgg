using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // scene�؂�ւ����s������

public class TestFade1Manager : MonoBehaviour
{
    float Speed = 0.001f;        //�t�F�[�h����X�s�[�h�A�����Ƒ����t�F�[�h����
    float red, green, blue, alfa;
    string loadScene = "TestErrorScene";

    public bool Out = false;
    public bool In = false;

    Image fadeImage;                //�p�l��

    // ���̃X�N���v�g���g���ۂ�
    // �E�p�l����Image�̃`�F�b�N�{�b�N�X��؂�
    // �E�p�l����alfa��255�ɐݒ�
    // �E�V�[���ڍs����{�^������ FadeOutSwitch(int number) �𑗂�悤�ɐݒ肷��;

    void Start()
    {
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;

        FadeInSwitch();
    }

    void Update()
    {
        

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
        switch (number)  // �V�[���؂�ւ�
        {
            case 1:
                loadScene = "TestFade1";
                break;
            case 2:
                loadScene = "TestFade2";
                break;
            case 3:
                loadScene = "TestStageSelectScene";
                break;


        }

        alfa = 0;
        //fadeImage.enabled = true;
        Out = true;
    }

    void FadeIn()
    {
        alfa -= Speed;
        Alpha();
        if (alfa <= 0)
        {
            In = false;
            fadeImage.enabled = false;
        }
    }

    void FadeOut()
    {
        fadeImage.enabled = true;
        alfa += Speed;
        Alpha();
        if (alfa >= 1)
        {
            Out = false;
            SceneManager.LoadSceneAsync(loadScene);
        }
    }

    void Alpha()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
}
