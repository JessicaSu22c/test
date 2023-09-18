using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    [SerializeField] Sprite[] blockStages;

    [SerializeField] int scoreToAddOnHit = 10;
    [SerializeField] int scoreToAddOnDestruction = 100;

    [SerializeField] GameObject hitEffect;

    int numberOfHits = 0;

    SpriteRenderer spriteRenderer;
    LevelController levelController;
    ScoreManager scoreManager;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        levelController = FindObjectOfType<LevelController>();
        scoreManager = FindObjectOfType<ScoreManager>();

        levelController.AddBlock();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(hitEffect, transform.position, Quaternion.identity);

        numberOfHits++;

        if (numberOfHits == blockStages.Length)
        {
            scoreManager.AddScore(scoreToAddOnDestruction);
            levelController.RemoveBlock();
            Destroy(gameObject);
        }
        else
        {
            scoreManager.AddScore(scoreToAddOnHit);
            spriteRenderer.sprite = blockStages[numberOfHits];
        }
    }
}