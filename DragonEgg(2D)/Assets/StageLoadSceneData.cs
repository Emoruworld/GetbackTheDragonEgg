using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StageLoadSceneData : MonoBehaviour
{
    public static string stageLoadScene = "TestErrorScene";  // �X�e�[�W�̃��[�h����V�[���̖��O
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

}
