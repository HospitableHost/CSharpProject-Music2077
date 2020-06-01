using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectSongManager : MonoBehaviour
{
    public void SelectButtonOnClick(string sceneName)
    {
        //Application.LoadLevel(sceneName);
        SceneManager.LoadScene("sceneName");
    }

}
