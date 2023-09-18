using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
   [SerializeField] TextMeshProUGUI scoreText;

    int score = 0;

    private void Awake()
    {
        int numberofScoreManagers = FindObjectsOfType<ScoreManager>().Length;

        if (numberofScoreManagers > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);
    }

    public void ResetScore()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

    public void  AddScore(int scoreToAdd)
    {
        score += scoreToAdd;

        scoreText.text = score.ToString();
    }
}
