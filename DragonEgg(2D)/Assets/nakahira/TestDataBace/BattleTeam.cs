using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BattleTeam", menuName = "ScriptableObjects/CreateBattleTeam")]
public class BattleTeam : ScriptableObject
{
    // �o�g���ɏo��e�ƍ��E�̃h���S���̃f�[�^��ێ�
    public TestDragonStatus ParentDragon;
    public TestDragonStatus DhildDragonRight;
    public TestDragonStatus DhildDragonLeft;
}
