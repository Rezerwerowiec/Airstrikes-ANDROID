using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GAME_CONTROLLER : MonoBehaviour
{
   
    public static GAME_CONTROLLER GC;
    /// AIRSTRIKE VARIABLES ////
    public static float AirstrikeRange = 20f, AirstrikeDamageMultiplier = 1f, AirstrikeDamageBasic = 10f, AirstrikeCooldown = 5f;
    public static int AirstrikeCountOfBombs = 5, AirUpgMultiplier = 0, AirUpgCooldown = 0, AirUpgCount = 0;

    public static float AirstrikeDamageMultiplierNext = 0, AirstrikeCountOfBombsNext = 0, AirstrikeCooldownNext= 0;
    /// TANK VARIABLES ///
    public static float TankSpeed = 8f;
    public static int TankHp = 2500;


    public static int GameScore = 0, GameScoreEarned = 0;
    static SaveData sd = null;
    static SaveController sc = null;
    private void Start()
    {
        InitialLoadSavingSystem();

        InvokeRepeating("CalculateStats", 1.0f, 0.3f);
        InvokeRepeating("Save", 5.0f, 5f);
    }

    void InitialLoadSavingSystem()
    {
        sc = GetComponent<SaveController>();
        sd = sc.LoadGame();
        if (sd == null)
        {
            sd = new SaveData
            {
                sdAirstrikeDamageBasic = AirstrikeDamageBasic,
                sdAirstrikeRange = AirstrikeRange,
                sdTankHp = TankHp,
                sdTankSpeed = TankSpeed,

                sdUpgAirCount = AirUpgCount,
                sdUpgAirMultiplier = AirUpgMultiplier,
                sdUpgAirCooldown = AirUpgMultiplier
            };
            Debug.Log("NEW DATA CREATED");
        }
        else
        {
            AirstrikeDamageBasic = sd.sdAirstrikeDamageBasic;
            AirstrikeRange = sd.sdAirstrikeRange;
            GameScore = sd.sdGameScore;
            TankHp = sd.sdTankHp;
            TankSpeed = sd.sdTankSpeed;

            AirUpgCount = sd.sdUpgAirCount;
            AirUpgMultiplier = sd.sdUpgAirMultiplier;
            AirUpgCooldown = sd.sdUpgAirCooldown;

            Debug.Log("LOADED SAVED DATA");
        }

        sc.SaveGame(sd);
        //CalculateStats();
    }

    void CalculateStats()
    {
        Debug.Log("CalculateStats done!");
        AirstrikeDamageMultiplier = 1+ ((float)AirUpgMultiplier*0.1f);
        AirstrikeCountOfBombs = 5 + AirUpgCount;
        AirstrikeCooldown = 5 - (AirUpgCooldown * 0.5f);


        //NEXT//
        AirstrikeCountOfBombsNext = 5 + (AirUpgCount + 1);
        AirstrikeDamageMultiplierNext = 1 + ((float)(AirUpgMultiplier+1) * 0.1f);
        AirstrikeCooldownNext = 5 - ((AirUpgCooldown+1) * 0.5f);
    }
    private void Awake()
    {
        if (GC != null)
            GameObject.Destroy(GC);
        else
            GC = this;
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            //TankHp = 2500;
            //Save();
            //sc.DeleteGame();
            //GameScore += 5000;
        }
    }

    public void Save()
    {
        sc.DeleteGame();

        sd.sdAirstrikeDamageBasic = AirstrikeDamageBasic;
        sd.sdAirstrikeRange = AirstrikeRange;
        sd.sdTankHp = TankHp;
        sd.sdTankSpeed = TankSpeed;
        sd.sdGameScore = GameScore;
        sd.sdUpgAirCooldown = AirUpgCooldown;
        sd.sdUpgAirCount = AirUpgCount;
        sd.sdUpgAirMultiplier = AirUpgMultiplier;
        
        sc.SaveGame(sd);
    }
}
