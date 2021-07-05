using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIVariables : MonoBehaviour
{
    [SerializeField]
    Text gameScore = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameScore.text = "Game Score: " +GAME_CONTROLLER.GameScore;
    }
}
