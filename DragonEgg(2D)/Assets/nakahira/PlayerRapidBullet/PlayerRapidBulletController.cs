using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRapidBulletController : PlayerBullet
{
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        bulletSpeedy = 10f; // �e���B��������
        bulletSpeedx = 0;
        //if (Random.Range(0,1) == 0)
        //{
        //}
    }

    // Update is called once per frame
    protected override void Update() // ���܂ꂽ��꒼���ɏc�����Ɉړ�����
    {
        base .Update();
    }
}
