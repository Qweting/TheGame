using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public Text roundText;
    public Text healthText;

    private int score = 0;
    private int round = 1;
    private PlayerController playerController;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>(); // Get player reference
        UpdateScore();
        UpdateRound();
    }

    void Update()
    {
        if (playerController != null)
        {
            UpdateHealth();
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScore();
    }

    public void NextRound()
    {
        round++;
        UpdateRound();
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    private void UpdateRound()
    {
        roundText.text = "Round: " + round;
    }

    private void UpdateHealth()
    {
        healthText.text = "Health: " + playerController.GetHealth();
    }
}