using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TankHP : MonoBehaviour
{
    [SerializeField]
    private GameObject popDamage = null;
    [SerializeField]
    private int maxHp;
    [SerializeField]
    private HealthBar HP = null;
    [SerializeField]
    private int hp;
    void Start()
    {
        maxHp = GAME_CONTROLLER.TankHp;
        hp = maxHp;
        HP.SetMaxHealth(maxHp);
    }

    public void DealDamage(int dmg)
    {
        GameObject go = Instantiate(popDamage, Camera.main.transform) as GameObject;
        go.GetComponent<PopDamage>().Damage(dmg);
        go.transform.position = transform.position;
        hp -= dmg;
        //Debug.Log("Damage dealt: " + dmg);
        if (hp <= 0) EndGame();
        else HP.SetHealth(hp);
    }

    private void EndGame()
    {
        Debug.Log("END GAME");
        SceneManager.LoadScene(3);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
