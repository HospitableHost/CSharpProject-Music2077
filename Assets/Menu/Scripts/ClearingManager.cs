using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearingManager : MonoBehaviour
{
    public void backBtnOnClick()
    {        
        SceneManager.LoadScene("Menu");
    }
    public void selectOtherBtnOnClick()
    {
        SceneManager.LoadScene("SelectSongMenu");
    }
    public void restartBtnOnClick()
    {
        SceneManager.LoadScene("Main");
    }
}
