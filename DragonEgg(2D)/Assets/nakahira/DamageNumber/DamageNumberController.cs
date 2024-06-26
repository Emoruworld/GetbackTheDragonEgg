using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageNumberController : MonoBehaviour
{
    private TextMeshPro textMeshPro;
    private float lifeSpan = 0.5f; // これが貴様に残された命だ
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        lifeSpan -= Time.deltaTime;
        if (lifeSpan < 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetDamageText(string damage)
    {
        textMeshPro.text = damage;
    }
}
