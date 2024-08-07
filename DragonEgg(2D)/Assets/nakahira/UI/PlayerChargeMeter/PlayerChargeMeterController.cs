using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerChargeMeterController : MonoBehaviour
{
    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void FillMeter(float value)
    {
        image.fillAmount = value;
    }

    public IEnumerator ReduceMeter(float time) // time�b�����đS���̃Q�[�W������
    {
        if (time == 0) // 0�Ŋ���̂�h���܂�
        {
            image.fillAmount = 0;
            yield break;
        }

        // ����ς�|���Z�ɂ��Ƃ����ق����������Ȃ�����
        float factor = 1 / time;

        while (image.fillAmount > 0)
        {
            image.fillAmount -= factor * Time.deltaTime;
            yield return null;
        }
    }
}
