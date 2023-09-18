using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ChangeScene(int buildIndex)
        {
            SceneManager.LoadScene(buildIndex);

        }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
    }
}