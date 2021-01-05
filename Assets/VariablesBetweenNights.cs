using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VariablesBetweenNights : MonoBehaviour {

	public static int currentNight;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OutputNight;
    }

    private void Start()
	{
        DontDestroyOnLoad(gameObject);
		currentNight = 1;
        Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow);
	}

    void OutputNight(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 1)
        {
            Debug.Log("Current Night:" + currentNight);
        }
    }
}
