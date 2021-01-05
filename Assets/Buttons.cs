using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {

    public string scene1;

    public void ButtonStart()
    {
        SceneManager.LoadSceneAsync(scene1);
    }

    public void NextLevel()
    {
        ResetLevelScene.m_instance.ResetLevel();
        ResetLevelScene.m_instance.ToggleEndgameScreen();
    }

    public void ButtonExit()
    {
        Application.Quit();
    }

}
