using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRapidBulletController : MonoBehaviour
{
    // �G�f�B�^�ŃA�^�b�`
    private GameObject cameraObject;
    private Camera cameraComponent;
    private float bulletSpeed = 10f; // �e���B��������
    // Start is called before the first frame update
    void Start()
    {
        cameraObject = GameObject.Find("Main Camera");
        cameraComponent = cameraObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update() // ���܂ꂽ��꒼���ɏc�����Ɉړ�����
    {
        transform.Translate(0f, bulletSpeed * Time.deltaTime, 0f);

        // ��ʊO�ɏo�������
        Vector2 viewPos = cameraComponent.WorldToViewportPoint(transform.position);
        if (viewPos.y > 1)
        {
            Destroy(gameObject);
        }
    }
}
