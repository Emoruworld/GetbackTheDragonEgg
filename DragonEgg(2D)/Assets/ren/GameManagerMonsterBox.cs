using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerMonsterBox : MonoBehaviour
{
    public RectTransform moveIcon;
    const float UPPER = 100.00f;//���
    const float LOWER = 0.00f;//����
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MonsterBox();
    }
    public void MonsterBox()//�J���������ꂢ��y=0�Ŏ~�܂�Ȃ��@����I�ɂ͖��Ȃ����ǋC�ɂȂ邩�獡��C��
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("up");
            if (transform.position.y !>= UPPER)
            {
                moveIcon.position += new Vector3(0, 3.0f, 0);
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("down");
            //���݂̈ʒu����x������1�ړ�����

            if (transform.position.y !<= LOWER)
            {
                moveIcon.position += new Vector3(0f, -3.0f, 0f);
            }
        }
    }


}
