using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{

    static public string keepLevelName;

    void Start()
    {
        RestartLevel.keepLevelName = SceneManager.GetActiveScene().name;
    }

    public void Restart()
    {
        SceneManager.LoadScene(RestartLevel.keepLevelName, LoadSceneMode.Single);
    }
}
