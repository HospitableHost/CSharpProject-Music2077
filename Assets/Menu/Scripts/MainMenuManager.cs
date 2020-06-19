using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGameOnClick(string sceneName)
    {
        //Application.LoadLevel(sceneName);
        SceneManager.LoadScene("sceneName");
    }
}
