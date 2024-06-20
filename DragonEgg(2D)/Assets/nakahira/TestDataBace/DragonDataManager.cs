using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �h���S��Box�̏����̒��ŌĂяo���Ă�
public class DragonDataManager
{
    // �L�^�ł���f�[�^�̐�
    private const int DATANUMBER = 10;
    // �L�[�̌Œ�̕���
    private const string KEYBASE = "Dragon_";

    // �h���S���̃f�[�^���������^�̔z������
    // �f�[�^��0�Ԗڂ͐e�h���S���ɂ��悤
    // �ł�����Q�[���������Ƒ��݂���͖̂��ʂ�����Ȃ��B�ׂɂ��������B
    // 6/18�@Static�N���X�łȂ�������j�ɂ��܂���
    private TestDragonStatus[] dragonData = new TestDragonStatus[DATANUMBER];

    // �����o�֐�
    public void LoadAllDragonData() // PlayerPlefs����S�f�[�^���擾
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

    public TestDragonStatus GetDragonData(int index)
    {
        return dragonData[index];
    }
}
