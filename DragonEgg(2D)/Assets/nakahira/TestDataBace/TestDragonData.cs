//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System;

//public struct TestDragonStatus
//{
//    // ���݂̃X�e�[�^�X�̎�ނ�ELEMENTS��ށB
//    private const int ELEMENTS = 7;
//    // ��؂�Ɏg�p����镶��
//    private const char INDEXWORD = ',';

//    public TestDragonStatus(string data)
//    {
//        // �v�f��(��؂蕶���̐�)���`�F�b�N
//        CheckElements(data);
//        // ���ꂼ��̕ϐ��ɒl����
//        AssignmentStatus(data);
//        // �����͈�ɂ܂Ƃ߂��邩��
//    }

//    private const int PLAYER = 0;
//    private const int FIRE = 1;
//    private const int ICE = 2;
//    private const int WIND = 3;
//    private const int THUNDER = 4;

//    // �����o�ϐ�

//    // �񋓂��Ƃ�
//    enum status
//    {
//        raceNum,
//        hp,
//        attack,
//        speed,
//        level,
//        nowExp,
//        name, // ��������string�Ȃ̂�
//    }

//    // �������ǂ̎�ނ̃h���S���Ȃ̂�
//    int raceNum;

//    // �̗́B�v���C���[�ɉ��Z����\��
//    int hp;

//    // �U���́B�����e�̊�b�l�Ɋ|���Z�������
//    int attack;

//    // �ړ��X�s�[�h
//    float speed;

//    // ���O�B�ł�����
//    string name;

//    // ���݃��x��
//    int level;

//    // ���݂̌o���l
//    int nowExp;

//    // ���݂̃f�[�^��string��s�ŕԂ��������v���p�e�B�Ŏ���
//    string dataString
//    {
//        get
//        {
//            // �Ԃ��l
//            string value = "";
//            value = raceNum + INDEXWORD + 
//                    hp + INDEXWORD + attack + "," + speed + "," ;
//        }
//    }


//    // �����o�֐�

//    // �����̂ŃR���X�g���N�^����ޔ�
//    private void CheckElements(string data)
//    {
//        // �Ƃ肠�����^����ꂽ�f�[�^�̗v�f�����z��ǂ���Ȃ̂��m�F
//        int elementCount = 0;
//        // ������̒��Ŋ���̋�؂蕶����T��
//        foreach (char c in data)
//        {
//            // ��������
//            if (c == INDEXWORD)
//            {
//                elementCount++;
//            }
//        }
//        if (elementCount != ELEMENTS) // �������v�f���łȂ����
//        {
//            throw new Exception("�v�f�����������Ȃ��H");
//        }
//        else
//        {
//            Debug.Log("�v�f���������[");
//        }
//    }

//    // �����̂őޔ�����2
//    private void AssignmentStatus(string data)
//    {
//        // �����̔Ԓn(1~7)
//        status elementNumber = status.raceNum;
//        // ���o�����l���ꎞ�ۑ�
//        string value = "";
//        // �f�[�^�̎��o��
//        foreach (char c in data)
//        {
//            // �ǂ񂾕�������؂蕶���łȂ��Ȃ�
//            if (c != INDEXWORD)
//            {
//                // �ǂݍ���ł�����
//                value = value + c;
//            }
//            // �łȂ����
//            else
//            {
//                // ������Ă���X�e�[�^�X�ɑ��(�l�X�g������)
//                // �e�X�e�[�^�X���N���X�����ăC���^�[�t�F�[�X�Ƃ���
//                // �Ȃ���������΂��ꂢ(�Ȃ͕̂������Ă�)
//                switch (elementNumber)
//                {
//                    // �L���X�g�o�O�����珟��ɃG���[�f���ł��傤
//                    case status.raceNum:
//                        raceNum = int.Parse(value);
//                        break;
//                    case status.hp:
//                        hp = int.Parse(value);
//                        break;
//                    case status.attack:
//                        attack = int.Parse(value);
//                        break;
//                    case status.speed:
//                        speed = int.Parse(value);
//                        break;
//                    case status.nowExp:
//                        nowExp = int.Parse(value);
//                        break;
//                    case status.name:
//                        name = value;
//                        break;
//                    default:
//                        throw new Exception("���������AelementNumber������������");
//                }
//                // ���̃X�e�[�^�X��
//                elementNumber++;
//                // �l�����Z�b�g
//                value = "";
//            }
//        }
//    }
//}
