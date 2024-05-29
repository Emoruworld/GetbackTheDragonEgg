using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "ChildDragonData_Max")]
public class ChildDragonData_Max : ScriptableObject
{
    [SerializeField] public int maxHp;
    [SerializeField] public int maxAttack;

    ////���̃t�@�C������l�̎擾�͂ł��邪�ύX�͂ł��Ȃ�
    public int Hp { get => maxHp; }
    public int Attack { get => maxAttack; }
}
