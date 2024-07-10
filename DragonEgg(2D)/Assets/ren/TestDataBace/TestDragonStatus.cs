using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

public class TestDragonStatus
{
    // ���݂̃X�e�[�^�X�̎�ނ�ELEMENTS��ށB
    private const int ELEMENTS = 7;
    // ��؂�Ɏg�p����镶��
    private const char INDEXWORD = ',';

    public TestDragonStatus()
    {

    }
    public TestDragonStatus(string data)
    {
        //�f�[�^���ׂ�
        if(data == "")
        {
            raceNum = (int)races.none;
            Debug.Log($"NULL{raceNum}");
        }
        else
        {
            // �v�f��(��؂蕶���̐�)���`�F�b�N
            CheckElements(data);
            // ���ꂼ��̕ϐ��ɒl����
            AssignmentStatus(data);
            // �����͈�ɂ܂Ƃ߂��邩��
            // �m�F
            Debug.Log($"{raceNum}, {hp}, {attack}, {speed}, {level}, {nowExp}, {name}");
        }
    }

    // �����o�ϐ�

    // �񋓂��Ƃ�
    enum races
    {
        player,
        fire,
        ice,
        wind,
        thunder,
        none
    }

    enum status
    {
        raceNum,
        hp,
        attack,
        speed,
        level,
        nowExp,
        name, // ��������string�Ȃ̂�
    }

    // �������ǂ̎�ނ̃h���S���Ȃ̂�
    public int raceNum;

    // �̗́B�v���C���[�ɉ��Z����\��
    public int hp;

    // �U���́B�����e�̊�b�l�Ɋ|���Z�������
    public int attack;

    // �ړ��X�s�[�h
    public float speed;

    // ���O�B�ł�����
    public string name;

    // ���݃��x��
    public int level;

    // ���݂̌o���l
    public int nowExp;

    // ���݂̃f�[�^��string��s�ŕԂ��������v���p�e�B�Ŏ���
    public string dataString
    {
        get
        {
            // ����N�\�R�[�h�����
            // �Ԃ��l
            StringBuilder value = new StringBuilder();
            value.Append(raceNum.ToString());
            value.Append(INDEXWORD);
            value.Append(hp.ToString());
            value.Append(INDEXWORD);
            value.Append(attack.ToString());
            value.Append(INDEXWORD);
            value.Append(speed.ToString());
            value.Append(INDEXWORD);
            value.Append(level.ToString());
            value.Append(INDEXWORD);
            value.Append(nowExp.ToString());
            value.Append(INDEXWORD);
            value.Append(name); // name��string�ł���
            return value.ToString(); // �����^����������StringBuilder�ɂ����ق����������Ȃ�
                                     // �Ƃ��v��������PlayerPlefs��string�����󂯕t���Ȃ���
        }
    }

    // �����o�֐�

    // �����̂ŃR���X�g���N�^����ޔ�
    private void CheckElements(string data)
    {
        // �Ƃ肠�����^����ꂽ�f�[�^�̗v�f�����z��ǂ���Ȃ̂��m�F
        int elementCount = 1;
        // ������̒��Ŋ���̋�؂蕶����T��
        foreach (char c in data)
        {
            // ��������
            if (c == INDEXWORD)
            {
                elementCount++;
            }
        }
        if (elementCount != ELEMENTS) // �������v�f���łȂ����
        {
            throw new Exception("�v�f�����������Ȃ��H");
        }
        else
        {
            Debug.Log("�v�f���������[");
        }
    }

    // �����̂őޔ�����2
    private void AssignmentStatus(string data)
    {
        // �����̔Ԓn(1~7)
        status elementNumber = status.raceNum;
        // ���o�����l���ꎞ�ۑ�
        string value = "";
        // �f�[�^�̎��o��
        foreach (char c in data)
        {
            // �ǂ񂾕�������؂蕶���łȂ��Ȃ�
            if (c != INDEXWORD)
            {
                // �ǂݍ���ł�����
                value = value + c;
            }
            // �łȂ����
            else
            {
                Debug.Log(value);
                Debug.Log(elementNumber);
                // ������Ă���X�e�[�^�X�ɑ��(�l�X�g������)
                // �e�X�e�[�^�X���N���X�����ăC���^�[�t�F�[�X�Ƃ���
                // �Ȃ���˂�����
                // �X�e�[�^�X��z��ɂ��������������������
                // ����܂菇�Ԃ�ݒ肵�����Ȃ��i�񋓂��Ă邯�ǁj
                // �ł����Ԃ�ݒ肵�Ȃ��ƌJ��Ԃ������Ŏ����ł��Ȃ��񂾂�Ȃ��@
                switch (elementNumber)
                {
                    // �L���X�g�o�O�����珟��ɃG���[�f���ł��傤
                    case status.raceNum:
                        raceNum = int.Parse(value);
                        break;
                    case status.hp:
                        hp = int.Parse(value);
                        break;
                    case status.attack:
                        attack = int.Parse(value);
                        break;
                    case status.speed:
                        speed = int.Parse(value);
                        break;
                    case status.level:
                        level = int.Parse(value);
                        break;
                    case status.nowExp:
                        nowExp = int.Parse(value);
                        break;
                    case status.name:
                        name = value;
                        break;
                    default:
                        throw new Exception("���������AelementNumber������������");
                }
                // ���̃X�e�[�^�X��
                elementNumber++;
                // �l�����Z�b�g
                value = "";
            }
        }
    }
}
