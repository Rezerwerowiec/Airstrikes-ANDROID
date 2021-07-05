using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnGround : MonoBehaviour
{
    [SerializeField]
    private GameObject effect =null;
    private GameObject go;
    private float timer = 2f, stimer = -1f;
    private TankHP tank;

    private float range, DamageMultiplier, DamageBasic; 
    private void Start()
    {
        tank = GameObject.FindGameObjectWithTag("Player").GetComponent<TankHP>();

        DamageMultiplier = GAME_CONTROLLER.AirstrikeDamageMultiplier;
        DamageBasic = GAME_CONTROLLER.AirstrikeDamageBasic;
        range = GAME_CONTROLLER.AirstrikeRange;
        timer = stimer;
    }
    private void Update()
    {
        if (stimer != -1f && stimer < timer)
        {
            Destroy(gameObject);
        }
        else if(stimer != -1f) stimer += Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.tag.Equals("AirStrike"))
        {
            go = Instantiate(effect, Camera.main.transform) as GameObject;
            go.transform.position = this.transform.position;
            stimer = 0f;
            GetComponent<BoxCollider>().enabled = false;
            CheckDistance();
            GetComponent<AudioSource>().Play();
        }
    }

    private void CheckDistance()
    {
        float distance = Vector3.Distance(this.transform.position, tank.GetComponent<Transform>().position);
        //distance = 20f - distance * 2;
        int dmg = (int)((DamageBasic*DamageMultiplier/distance)*100);
        if (dmg < 1 || distance > range) { //Debug.Log("Distance: " + distance + ", too long to deal damage!"); 
            return; }
        else
        {
            Debug.Log("Distance: " + distance + " dmg:" + dmg);
            GAME_CONTROLLER.GameScoreEarned += dmg * 2;
            Debug.Log("Current GameScore Earned: " + GAME_CONTROLLER.GameScoreEarned);
            tank.DealDamage(dmg);
        }
    }
}