using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticDataManager
{
    // �L�^�ł���f�[�^�̐�
    private const int DATANUMBER = 10;
    // �L�[�̌Œ�̕���
    private const string KEYBASE = "Dragon_";

    // �h���S���̃f�[�^���������^�̔z������
    // �f�[�^��0�Ԗڂ͐e�h���S���ɂ��悤
    // �ł�����Q�[���������Ƒ��݂���͖̂��ʂ�����Ȃ��B�ׂɂ��������B
    static TestDragonStatus[] dragonData = new TestDragonStatus[DATANUMBER];

    // �����o�֐�
    public static void LoadAllSaveData() // PlayerPlefs����S�f�[�^���擾
    {
        for (int i = 0; i < DATANUMBER; i++)
        {
            // KEYBASE�Z�Z�̌`�ŃL�[�����
            string key = KEYBASE + i.ToString();

            // TestDragonStatus�^�Ɋi�[
            TestDragonStatus data = new TestDragonStatus(PlayerPrefs.GetString(key));
            // �z��ɕۑ�
            dragonData[i] = data;
        }
    }
}
