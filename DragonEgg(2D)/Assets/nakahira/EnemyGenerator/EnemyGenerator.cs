using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    // �G�f�B�^�ŃA�^�b�`
    public GameObject prefab;
    Camera mainCamera;

    // �G�f�B�^�ł��낢��ł���悤�ɂ����������B

    private float offsetX = 0.1f;
    private float offsetY = 0.1f;

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
        // ���݈ʒu������o���ăJ�����ɓ���������Ԃ�
        Vector2 viewPort = mainCamera.WorldToViewportPoint(transform.position);
        bool result = (viewPort.x + offsetX) > 0 &&
                      (viewPort.x - offsetX) < 1 &&
                      (viewPort.y + offsetY) > 0 &&
                      (viewPort.y - offsetY) < 1;
        return result;
    }
}
