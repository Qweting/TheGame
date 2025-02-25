using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoundScoreManager : MonoBehaviour
{
    public static RoundScoreManager instance;
    public int round = 0;
    private int killsTillNextRound = 0;
    public TextMeshPro roundText;
    
    private int zombiesKilled = 0;
    public GameObject zombieBoss;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else 
            IncrementRound();
        killsTillNextRound = 16 + 2; 
    }

    public void IncrementRound()
    {
        if (zombiesKilled >= killsTillNextRound && instance != null)
        {
            round++;
            roundText.text = "Round: " + round;
            zombieBoss.SetActive(true);
        }
        if (zombiesKilled % 5 == 0)
            zombieBoss.SetActive(true);
            
    }
    
    public void AddZombieKilled()
    {
        zombiesKilled++;
        IncrementRound();
    }
    
}
