using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (gameObject.name == "EndLevelCanvas")
        {
            gameObject.SetActive(false);
        }
    }
}
