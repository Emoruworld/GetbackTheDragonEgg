using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRapidBulletController : MonoBehaviour
{
    [SerializeField] Dragon dragon;

    int i;

    private float bulletSpeed = 1f; // �e���B��������
    // Start is called before the first frame update
    void Start()
    {
        i = dragon.num_a;
        Debug.Log(i);
    }

    // Update is called once per frame
    void Update() // ���܂ꂽ��꒼���ɏc�����Ɉړ�����
    {
        transform.Translate(0f, bulletSpeed, 0f);
    }
}
