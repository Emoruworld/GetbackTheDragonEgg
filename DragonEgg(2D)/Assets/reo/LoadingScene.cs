using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// ���[�f�B���O��ʂ��Ǘ�����X�N���v�g

public class LoadingScene : MonoBehaviour
{
    [SerializeField] private GameObject _loadingUI;
    [SerializeField] private Slider _slider;

    public static int stageNum;

    /*

    public void LoadNextScene()
    {
        //_loadingUI.SetActive(true);
        //StartCoroutine(LoadScene());
    }

    
    IEnumerator LoadScene()  // ���[�h��ʂ͎g��Ȃ��̂ō��͖��������Ă���
    {
        AsyncOperation async;

        switch (LoadingScene.stageNum)
        {
            case 1:
                async = SceneManager.LoadSceneAsync("TestStage1");
                while (!async.isDone)
                {
                    _slider.value = async.progress;
                    yield return null;
                }
                break;


            case 2:
                async = SceneManager.LoadSceneAsync("TestStage2");
                while (!async.isDone)
                {
                    _slider.value = async.progress;
                    yield return null;
                }
                break;


            case 3:
                async = SceneManager.LoadSceneAsync("TestStage3");
                while (!async.isDone)
                {
                    _slider.value = async.progress;
                    yield return null;
                }
                break;


            case 4:
                async = SceneManager.LoadSceneAsync("TestStage4");
                while (!async.isDone)
                {
                    _slider.value = async.progress;
                    yield return null;
                }
                break;


            default:
                async = SceneManager.LoadSceneAsync("TestErrorScene");
                while (!async.isDone)
                {
                    _slider.value = async.progress;
                    yield return null;
                }
                break;
        }


        //AsyncOperation async = SceneManager.LoadSceneAsync("TestStageSelectScene");
        //while (!async.isDone)
        //{
        //    _slider.value = async.progress;
        //    yield return null;
        //}
    }

    */
}
