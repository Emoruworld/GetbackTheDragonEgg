using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticDataManager
{
    // �L�^�ł���f�[�^�̐�
    private const int DATANUMBER = 10;
    // �L�[�̌Œ�̕���
    private const string KEYBASE = "Dragon_";

    // �R�h���h���S���̃f�[�^���𕶎���ł���[���ƋL������c�H
    // �f�[�^��0�Ԗڂ͐e�h���S���ɂ��悤
    static string[] dragonData = new string[DATANUMBER];

    // �����o�֐�
    public static void LoadAllSaveData() // PlayerPlefs����S�f�[�^���擾
    {
        for (int i = 0; i < DATANUMBER; i++)
        {
            // KEYBASE�Z�Z�̌`�ŃL�[�����
            string key = KEYBASE + i.ToString();

            // TestDragonStatus�^�Ɋi�[
            TestDragonStatus data = new TestDragonStatus(PlayerPrefs.GetString(key));
        }
    }
}
