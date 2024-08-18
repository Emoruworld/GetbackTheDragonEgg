using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudio : MonoBehaviour
{
    private static GameObject SE;

    private void Start()
    {
        SE = (GameObject)Resources.Load("SE");
    }

    // AudioSource.PlayClipAtPoint����@�\�Ȃ̂Ŏ����ō��
    public static void InstantiateSE(
        AudioClip clip
        )
    {
        // �������ĉ���t����
        GameObject source = Instantiate(SE);
        source.GetComponent<AudioSource>().clip = clip;
    }
}
