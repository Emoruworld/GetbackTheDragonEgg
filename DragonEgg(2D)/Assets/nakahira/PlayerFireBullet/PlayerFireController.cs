using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireController : MonoBehaviour
{
    private GameObject cameraObject;
    private Camera cameraComponent;
    private float bulletSpeedy = 2f; // �e���B��������

    private float bulletSpeedx;
    // Start is called before the first frame update
    void Start()
    {
        cameraObject = GameObject.Find("Main Camera");
        cameraComponent = cameraObject.GetComponent<Camera>();
        bulletSpeedx = Random.Range(-1f, 1f); // ���E�ɂ΂���悤�ɂ���
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(bulletSpeedx * Time.deltaTime, bulletSpeedy * Time.deltaTime, 0f);

        // ��������������
        bulletSpeedx *= 0.99f;
        bulletSpeedy *= 0.99f;

        // ��ʊO�ɏo�������
        Vector2 viewPos = cameraComponent.WorldToViewportPoint(transform.position);
        if (viewPos.y < 0 ||
            viewPos.y > 1 ||
            viewPos.x < 0 ||
            viewPos.x > 1) // ���ꉽ�Ƃ��Z���Ȃ�Ȃ�����)
        {
            Destroy(gameObject);
        }

        // ���x�����ȉ��ɂȂ��Ă�����
        if (bulletSpeedy < 0.5f)
        {
            Destroy(gameObject);
        }
    }
}
