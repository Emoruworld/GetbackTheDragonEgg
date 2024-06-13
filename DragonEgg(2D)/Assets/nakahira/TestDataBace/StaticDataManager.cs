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
    private static TestDragonStatus[] s_dragonData = new TestDragonStatus[DATANUMBER];

    public static TestDragonStatus sParentDragonData;
    public static TestDragonStatus sChildDragonDataRight;
    public static TestDragonStatus sChildDragonDataLeft;

    // �����o�֐�
    public static void LoadAllDragonData() // PlayerPlefs����S�f�[�^���擾
    {
        for (int i = 0; i < DATANUMBER; i++)
        {
            // KEYBASE�Z�Z�̌`�ŃL�[�����
            string key = KEYBASE + i.ToString();

            // TestDragonStatus�^�Ɋi�[
            TestDragonStatus data = new TestDragonStatus(PlayerPrefs.GetString(key));
            // �z��ɕۑ�
            s_dragonData[i] = data;
        }
    }

    public static TestDragonStatus GetDragonData(int index)
    {
        return s_dragonData[index];
    }
}
