using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public void StartGameOnClick(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }
}
