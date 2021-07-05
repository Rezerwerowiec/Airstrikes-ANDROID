using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MapLoader : MonoBehaviour
{
    [SerializeField]
    GameObject checkPoints = null;
    GameObject player = null;

    private void Start()
    {
       player = GameObject.FindGameObjectWithTag("Player");
    }
    public void MapChosen(bool isMapChosen)
    {
        if (isMapChosen)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = checkPoints.transform.position;
            GameObject.FindGameObjectWithTag("Crosshair").transform.position = new Vector3(player.transform.position.x, player.transform.position.y+40f, player.transform.position.z);
            StartCoroutine(NavMeshTurnOn(player));
           
            Debug.Log("Map chosen: " + gameObject.name);
        } else
        {
            Destroy(checkPoints); Destroy(gameObject);
        }
        
    }

    IEnumerator NavMeshTurnOn(GameObject player)
    {
        yield return new WaitForSeconds(2);
        player.GetComponent<NavMeshAgent>().enabled = true;
        player.GetComponent<NaviAgent>().enabled = true;
        player.GetComponent<NaviAgent>().CheckpointsHolder = checkPoints;
    }
    private void Update()
    {
        //player.transform.position = checkPoints.transform.position;
    }

}
