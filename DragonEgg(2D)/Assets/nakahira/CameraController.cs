using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float cameraSpeedy = 0.03f; // �J�����̏c�̈ړ��X�s�[�h
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, cameraSpeedy, 0f);
    }
}
