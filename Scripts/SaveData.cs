using System;
using UnityEngine;

[Serializable]
public class SaveData
{
    /// AIRSTRIKE VARIABLES ////
    public float sdAirstrikeRange, sdAirstrikeDamageBasic, sdAirstrikeCooldown;
    public int sdAirstrikeCountOfBombs;

    /// TANK VARIABLES ///
    public float sdTankSpeed;
    public int sdTankHp;


    public int sdGameScore;
    public int sdUpgAirMultiplier, sdUpgAirCooldown, sdUpgAirCount;
}
