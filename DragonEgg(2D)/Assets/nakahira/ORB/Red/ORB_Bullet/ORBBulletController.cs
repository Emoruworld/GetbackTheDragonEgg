using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ORBBulletController : EnemyBullet
{
    private const int ORBBULLETATTACK1 = 1;
    private const int ORBBULLETATTACK2 = 2;
    private const int ORBBULLETATTACK3 = 4;
    private const int ORBBULLETATTACK4 = 7;
    private const float SPEED1 = 1;
    private const float SPEED2 = 1.3f;
    private const float SPEED3 = 1.6f;
    private const float SPEED4 = 2f;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        string sceneName = SceneManager.GetActiveScene().name;
        switch (sceneName)
        {
            case "Battle1":
                attack = ORBBULLETATTACK1;
                speed = SPEED1;
                break;
            case "Battle2":
                attack = ORBBULLETATTACK2;
                speed = SPEED2;
                break;
            case "Battle3":
                attack = ORBBULLETATTACK3;
                speed = SPEED3;
                break;
            case "Battle4":
                attack = ORBBULLETATTACK4;
                speed = SPEED4;
                break;

        }

    }
}
