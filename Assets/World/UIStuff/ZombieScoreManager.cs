using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ZombieScoreManager : MonoBehaviour
{
    public static ZombieScoreManager instance;
    public int score = 0; 
    public TextMeshPro scoreText;
    private int zombiesKilled= 0;
    void Awake()
    {
        if (instance == null)
            instance = this; 
        else 
            Destroy(gameObject);
    }


    public void AddScore(int amount)
    {
        zombiesKilled++;
        score += amount;
        Debug.Log("Score: " + score);
        
        if(scoreText != null)
            scoreText.text = "Score: " + score;
    }
    
    public int GetScore()
    {
        return score;
    }
    
    
    
    
    
}
