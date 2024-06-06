using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticDataManager
{
    // �L�^�ł���f�[�^�̐�
    private const int DATANUMBER = 10;
    // �X�e�[�^�X�̎��
    private const int STATUSNUMBER = 2;
    // �L�[�̌Œ�̕���
    private const string KEYBASE = "Child_";

    // �R�h���h���S���̃f�[�^���𕶎���ł���[���ƋL������c�H
    // �f�[�^��0�Ԗڂ͐e�h���S���ɂ��悤
    static string[,] dragonData = new string[DATANUMBER, STATUSNUMBER];

    // �����o�֐�
    public static void LoadAllSaveData() // PlayerPlefs����S�f�[�^���擾
    {
        for (int i = 0; i < DATANUMBER; i++)
        {
            // Child_�Z�Z�̌`�ŃL�[�����
            string key = KEYBASE + i.ToString();

            string data = PlayerPrefs.GetString(key);

            for (int j = 0; j < STATUSNUMBER; j++)
            {
                
            }
        }
    }
}
