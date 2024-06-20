using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    // �G�f�B�^�ŃA�^�b�`
    public GameObject prefab;
    Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    // FixedUpdate�ŏ����̌y����}��܂�
    private void FixedUpdate()
    {
        if (CheckInCamera())
        {
            // ���g�̏ꏊ�ɃA�^�b�`���ꂽ�Q�[���I�u�W�F�N�g���V���E�J��
            Instantiate(prefab, transform.position, Quaternion.identity);

            // �����͑ޏ�
            Destroy(gameObject);
        }
    }

    private bool CheckInCamera()
    {
        float offset = 0.1f;
        // ���݈ʒu������o���ăJ�����ɓ���������Ԃ�
        Vector2 viewPort = mainCamera.WorldToViewportPoint(transform.position);
        bool result = ((viewPort.x + offset) > 0 &&
                       (viewPort.x - offset) < 1 &&
                       (viewPort.y + offset) > 0 &&
                       (viewPort.y - offset) < 1);
        return result;
    }
}
