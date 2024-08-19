using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenDragonFryBulletController : EnemyBullet
{
    private const int BULLETATTACK = 4;
    private const float SPEED = 1f;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        attack = BULLETATTACK;
        speed = SPEED;
    }
}
