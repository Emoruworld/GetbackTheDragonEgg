using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HadouBeamController : PlayerBullet
{
    private const int BEAMATTACK = 5;
    private Vector3 beamExpandSpeed = new Vector3(0, 1, 0);

    private void Awake()
    {
        baseAttack = BEAMATTACK;
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // �����������\����Ȃ��base�͎��s���ĂȂ���
    protected override void Update()
    {
        // �r�[���L�΂�
        if (transform.localScale.y < 12)
        {
            transform.localScale += beamExpandSpeed;
        }

    }
}
