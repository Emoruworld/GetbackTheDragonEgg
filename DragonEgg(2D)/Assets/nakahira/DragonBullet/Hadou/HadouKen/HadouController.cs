using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HadouController : PlayerBullet
{
    private const int HADOUKENATTACK = 2;
    private void Awake()
    {
        baseAttack = HADOUKENATTACK;
    }
    protected override void Start()
    {
        base.Start();
        GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.2f);
    }
}
