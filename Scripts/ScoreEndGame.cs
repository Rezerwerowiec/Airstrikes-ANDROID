using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreEndGame : MonoBehaviour
{
    
    [SerializeField]
    Text earned = null, total = null;
    void Start()
    {
        earned.text = "SCORE EARNED:  " + GAME_CONTROLLER.GameScoreEarned;
        GAME_CONTROLLER.GameScore += GAME_CONTROLLER.GameScoreEarned;
        GAME_CONTROLLER.GameScoreEarned = 0;
        total.text = "TOTAL SCORE: " + GAME_CONTROLLER.GameScore;
        //GAME_CONTROLLER.Save();
    }
}
