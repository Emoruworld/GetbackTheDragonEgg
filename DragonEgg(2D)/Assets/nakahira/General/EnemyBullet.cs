using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    protected static Camera cameraComponent;
    // �C���X�^���X���ő�����Ă��炤
    protected Vector2 angle;
    protected Vector2 speed;

    public int attack { get; protected set; }
    // Start is called before the first frame update
    protected virtual void Start()
    {
        cameraComponent = Camera.main;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        //�@�J�����̈ړ����x�܂߂Ĉړ�
        transform.Translate((speed + BattleCameraController.cameraSpeed) * Time.deltaTime);

        // ��ʊO�ɏo�������
        if (CheckViewPosOver())
        {
            Destroy(gameObject);
        }
    }

    protected bool CheckViewPosOver()
    {
        Vector2 viewPos = cameraComponent.WorldToViewportPoint(transform.position);
        return (viewPos.y < 0 ||
                viewPos.y > 1 ||
                viewPos.x < 0 ||
                viewPos.x > 1); // ���ꉽ�Ƃ��Z���Ȃ�Ȃ�����
    }

    public void SetAngle(Vector2 _angle)
    { 
        angle = _angle; 
    }
}
