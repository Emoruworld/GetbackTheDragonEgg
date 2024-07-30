using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageNumberGenerator : MonoBehaviour
{
    // �v���n�u�Ȃ�Ń��\�[�X����
    private static GameObject s_damageText;
    private static GameObject s_canvas;

    private void Awake() // Awake�ł�GameObject����񂾂�
    {
        s_damageText = (GameObject)Resources.Load("DamageNumber");
        s_canvas = GameObject.Find("Canvas");
    }

    public static void GenerateText(int damage, Vector2 pos, Color color) // �^����ꂽ�������������e�L�X�g�𐶐�����
    {
        GameObject instance = Instantiate(s_damageText, pos, Quaternion.identity);
        TextMeshPro temp = instance.GetComponent<TextMeshPro>();
        temp.text = damage.ToString();
        temp.color = color; // �F���w��
        // �Ō�A���������L�����o�X�ɒu��
        temp.transform.SetParent(s_canvas.transform, true);
    }
}
