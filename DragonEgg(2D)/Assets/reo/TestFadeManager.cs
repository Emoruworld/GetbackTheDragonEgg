using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // scene�؂�ւ����s������

public class FadeManager : MonoBehaviour
{
    float Speed = 0.001f;        //�t�F�[�h����X�s�[�h�A�����Ƒ����t�F�[�h����
    float red, green, blue, alfa;

    public bool Out = false;
    public bool In = false;

    Image fadeImage;                //�p�l��

    void Start()
    {
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;
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

    public void FadeSwitch()
    {
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
            SceneManager.LoadSceneAsync("TestFade2");
        }
    }

    void Alpha()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
}
