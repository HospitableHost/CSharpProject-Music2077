using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSongManager : MonoBehaviour
{
    public void SelectButtonOnClick(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }

}
