using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shooter : MonoBehaviour/*, IEnumerable*/
{
    protected bool canShoot = true; // �e���Ă邩�ǂ���

    public void SetCanShoot(bool value)
    {
        canShoot = value;
    }
}
