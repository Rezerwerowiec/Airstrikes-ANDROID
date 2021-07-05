using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UPGRADEDMGMULTI : MonoBehaviour
{
    [SerializeField]
    string Name = null;
    // Start is called before the first frame update
    float var = 0, varNext = 0;
    int cost = 1500;
    void Start()
    {

        InvokeRepeating("Refresh", 0.0f, 0.3f);
    }
    private void Update()
    {
        GetComponentInChildren<Text>().text = Name + "\n" + var + " -> " + varNext + "\nCOST: " + cost;
    }

    void Refresh()
    {
        switch (Name)
        {
            case "DAMAGE MULTIPLIER":
                {
                    var = GAME_CONTROLLER.AirstrikeDamageMultiplier;
                    varNext = GAME_CONTROLLER.AirstrikeDamageMultiplierNext;
                    cost = (int)Mathf.Pow(GAME_CONTROLLER.AirUpgMultiplier, 2) * 1500 +1500;
                    break;
                }
            case "COUNT OF MISSILES":
                {
                    var = GAME_CONTROLLER.AirstrikeCountOfBombs;
                    varNext = GAME_CONTROLLER.AirstrikeCountOfBombsNext;
                    cost = (int)Mathf.Pow(GAME_CONTROLLER.AirUpgCount, 2) * 1500 +1500;
                    break;
                }
            case "COOLDOWN":
                {
                    var = GAME_CONTROLLER.AirstrikeCooldown;
                    varNext = GAME_CONTROLLER.AirstrikeCooldownNext;
                    cost = (int)Mathf.Pow(GAME_CONTROLLER.AirUpgCooldown, 3) * 1500 + 5000;
                    break;
                }
        }
        ChangeColor();
    }


    void ChangeColor()
    {
        if (GAME_CONTROLLER.GameScore < cost)
        {
            ColorBlock color = GetComponent<Button>().colors;
            color.normalColor = Color.red;
            color.highlightedColor = Color.red;
            color.selectedColor = Color.red;
            GetComponent<Button>().colors = color;
        }
    }
    public void OnClick()
    {
        if (GAME_CONTROLLER.GameScore < cost)
        {
            Debug.Log("U HAVE NO MONEY TO PURCHASE IT!");
        }
        else
        {
            switch (Name)
            {
                case "DAMAGE MULTIPLIER":
                    {
                        GAME_CONTROLLER.AirUpgMultiplier += 1;
                        break;
                    }
                case "COUNT OF MISSILES":
                    {
                        GAME_CONTROLLER.AirUpgCount += 1;
                        break;
                    }
                case "COOLDOWN":
                    {
                        GAME_CONTROLLER.AirUpgCooldown += 1;
                        break;
                    }
            }
            GAME_CONTROLLER.GameScore -= cost;
        }
        //GAME_CONTROLLER.Save();
    }
}
