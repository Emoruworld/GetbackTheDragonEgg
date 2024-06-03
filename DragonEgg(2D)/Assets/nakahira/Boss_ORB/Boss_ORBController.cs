using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss_ORBController : ORBController // �p��
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        hitPoint = 100; // �Ȃ�
    }

    // �����֘A�̏�����ORB�Ɠ���

    private void OnDestroy() // ���񂾂Ƃ��A�N���A��ʂ�
    {
        SceneManager.LoadScene("ClearScene"); // OnDestroy�ł̓R���[�`���g���Ȃ��񂩂�
    }

    IEnumerator Clear(float interval)
    {
        yield return new WaitForSeconds(interval);
        SceneManager.LoadScene("ClearScene");
    }
}
