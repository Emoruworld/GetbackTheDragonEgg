using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtunScript : MonoBehaviour
{
    public GameObject camera;

    // �{�^���������ꂽ�ꍇ�A����Ăяo�����֐�
   
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("CameraController");
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClick()
    {
        Debug.Log("�����ꂽ!");  // ���O���o��
        BootsupandsquadManager.CameraMove1();
    }
}
