using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoundPanelManeger : MonoBehaviour
{
    [SerializeField] private GameObject soundPanel;
    // Start is called before the first frame update
    void Start()
    {
        soundPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSoundPanel()
    {
        soundPanel.SetActive(true);
        EventSystem e = EventSystem.current;
        e.SetSelectedGameObject(soundPanel.transform.GetChild(0).gameObject);
    }

    public void OffSoundPanel()
    {
        soundPanel.SetActive(false);
        EventSystem e = EventSystem.current;
        e.SetSelectedGameObject(GameObject.Find("SEButton"));
    }
}
