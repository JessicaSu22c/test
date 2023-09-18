using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoseScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI livesText;

    [SerializeField] SceneLoader sceneLoader;

    [SerializeField] int MaxLives = 5;

    int currentLives;

    private void Awake()
    {
        int numberOfLoseScripts = FindObjectsOfType<LoseScript>().Length;

        if (numberOfLoseScripts > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        ResetLives();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<ScoreManager>().ResetScore();
        LoseLife();
    }

    void LoseLife()
    {
        currentLives--;
        livesText.text = "Lives: " + currentLives.ToString();
        sceneLoader.ReloadScene();

        if (currentLives <= 0)
        {
            sceneLoader.ChangeScene(5);
            ResetLives();
        }
    }

    void ResetLives()
    {
        currentLives = MaxLives;
        livesText.text = "Lives; " + currentLives.ToString();
    }
}
