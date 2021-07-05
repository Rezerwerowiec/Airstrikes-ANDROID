using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StrikeThis : MonoBehaviour
{
    int CountOfBombs;
    float TimeBetweenStrikes;
    
    

    public float MaxDubbleTapTime;

    int TapCount;
    float NewTime, timer = 0;
    public GameObject airStrike;
    public Text text;
    public Transform Holder;
    void Start()
    {
        CountOfBombs = GAME_CONTROLLER.AirstrikeCountOfBombs;
        TimeBetweenStrikes = GAME_CONTROLLER.AirstrikeCooldown;

        TapCount = 0;
        Strike();
    }

    void Update()
    {
        if (timer > TimeBetweenStrikes)
        {
            CheckDoubleTap();
            text.text = "Airstrikes are ready!";
        }
        else
        {
            timer += Time.deltaTime;
            int timeTo = (int)(TimeBetweenStrikes - timer);
            text.text = "Next airstrikes in: " + timeTo + "s!";
        }
    }

    void CheckDoubleTap()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Ended)
            {
                TapCount += 1;
            }

            if (TapCount == 1)
            {

                NewTime = Time.time + MaxDubbleTapTime;
            }
            else if (TapCount == 2 && Time.time <= NewTime)
            {

                //Whatever you want after a dubble tap    
                print("Dubble tap");
                Strike();
                timer = 0;
                TapCount = 0;
            }

        }
        if (Time.time > NewTime)
        {
            TapCount = 0;
        }
    }

    void Strike()
    {
        for(int i = 0; i<CountOfBombs; i++)
        {
            GameObject go =  Instantiate(airStrike, Holder) as GameObject;
            go.transform.position = new Vector3(transform.position.x + Random.Range(-5, 5), transform.position.y + Random.Range(40+i*8f, 6+i*8f), transform.position.z + Random.Range(-5, 5));
        }
    }
}
