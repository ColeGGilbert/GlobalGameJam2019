using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevelScene : MonoBehaviour
{
    [SerializeField] private GameObject endLevelCanvas;
    [SerializeField] private GameObject upgradeHolder;
    private GameObject wall;
    private GameObject player;

    public static ResetLevelScene m_instance;

    public delegate void Reset();
    public static event Reset OnReset;

    private void OnLevelWasLoaded(int level)
    {
        if(level == 1)
        {
            wall = GameObject.FindGameObjectWithTag("Destruction");
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    private void OnEnable()
    {
        m_instance = this;
    }

    public void ResetLevel()
    {
        player.SetActive(true);
        upgradeHolder.SetActive(true);
        wall.transform.position = new Vector3(-15f, -3f, 0f);
        OnReset();
    }

    public void ToggleEndgameScreen()
    {
        endLevelCanvas.SetActive(!endLevelCanvas.activeSelf);
    }
}
