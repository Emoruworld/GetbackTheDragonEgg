using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  // scene�؂�ւ����s������
using TMPro;
using UnityEngine.EventSystems;

public class CreditScript : MonoBehaviour
{
    private GameObject button;
    private bool isEnd;
    private const int scroolSpeed = 100;
    // Start is called before the first frame update
    void Start()
    {
        button = GameObject.Find("Button");
        button.SetActive(false);
        isEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(this.transform.position.y > 1900)
        {
            isEnd = true;
            button.SetActive(true);
            EventSystem eventSystem = EventSystem.current;
            eventSystem.SetSelectedGameObject(button);
        }

        if (!isEnd)
        {

            if (Input.GetKey(KeyCode.Space) || Input.GetKey("joystick button 0"))
            {
                this.transform.position += new Vector3(0, scroolSpeed * 3 * Time.deltaTime, 0);
            }
            else
            {
                this.transform.position += new Vector3(0, scroolSpeed * Time.deltaTime, 0);
            }
        }
    }

    public void OnSceneMove()
    {
        SceneManager.LoadScene("optionScene");
    }
}
