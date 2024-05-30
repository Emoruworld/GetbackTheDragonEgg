using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageNumberGenerator : MonoBehaviour
{
    // �v���n�u�Ȃ�ŃG�f�B�^����
    [SerializeField]
    private GameObject objTemp;
    private static GameObject s_damageText;

    private void Awake() // Awake�ł�GameObject����񂾂�
    {
        s_damageText = objTemp;
    }

    public static void GenerateText(float damage, Vector2 pos, Color color) // �^����ꂽ�������������e�L�X�g�𐶐�����
    {
        GameObject instance = Instantiate(s_damageText, pos, Quaternion.identity);
        TextMeshPro temp = instance.GetComponent<TextMeshPro>();
        temp.text = damage.ToString("f"); // �����_���ʂ܂ŕ\���i���j
        temp.color = color; // �F���w��
    }
}
