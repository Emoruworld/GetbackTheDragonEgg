using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class HomeDirector : MonoBehaviour
{
    void Start()
    {
        //if (Input.GetAxisRaw("Vertical") < 0)
        //{
        //    // �I�𒆂̃I�u�W�F�N�g�擾
        //    GameObject nowObj = EventSystem.current.currentSelectedGameObject;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("joystick button 0"))
<<<<<<< Updated upstream
=======
        {
            SceneManager.LoadScene("LevelUpScene");
        }
        if (Input.GetKeyDown("joystick button 1"))
        {
            SceneManager.LoadScene("LevelUpScene");
        }
        if (Input.GetKeyDown("joystick button 2"))
        {
            SceneManager.LoadScene("LevelUpScene");
        }
        if (Input.GetKeyDown("joystick button 3"))
        {
            SceneManager.LoadScene("LevelUpScene");
        }
        if (Input.GetKeyDown("joystick button 4"))
        {
            SceneManager.LoadScene("LevelUpScene");
        }
        if (Input.GetKeyDown("joystick button 5"))
>>>>>>> Stashed changes
        {
            SceneManager.LoadScene("TitleScene");
        }
        //    if (Input.GetKeyDown("joystick button 1"))
        //    {
        //        SceneManager.LoadScene("LevelUpScene");
        //    }
        //    if (Input.GetKeyDown("joystick button 2"))
        //    {
        //        SceneManager.LoadScene("LevelUpScene");
        //    }
        //    if (Input.GetKeyDown("joystick button 3"))
        //    {
        //        SceneManager.LoadScene("LevelUpScene");
        //    }
        //    if (Input.GetKeyDown("joystick button 4"))
        //    {
        //        SceneManager.LoadScene("LevelUpScene");
        //    }
        //    if (Input.GetKeyDown("joystick button 5"))
        //    {
        //        SceneManager.LoadScene("LevelUpScene");
        //    }
        //    if (Input.GetKeyDown("joystick button 6"))
        //    {
        //        SceneManager.LoadScene("LevelUpScene");
        //    }
    }
}
