using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRapidBulletController : MonoBehaviour
{
    private float bulletSpeed = 1f; // �e���B��������
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() // ���܂ꂽ��꒼���ɏc�����Ɉړ�����
    {
        transform.Translate(0f, bulletSpeed, 0f);
    }
}
