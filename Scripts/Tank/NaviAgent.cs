using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NaviAgent : MonoBehaviour {
    public GameObject CheckpointsHolder = null;
    private Transform[] checkpoints;
    // Use this for initialization
    private int i = 0;

    private void Start()
    {
        
        checkpoints = CheckpointsHolder.GetComponentsInChildren<Transform>();
        ChangeCheckpoint();
    }
    // Update is called once per frame
    void FixedUpdate () {
        if(Vector3.Distance(checkpoints[i].position, transform.position) < 7f)
        {
            //Debug.Log(Vector3.Distance(checkpoints[i].position, transform.position));
            ChangeCheckpoint();
        }

        //Debug.Log(Vector3.Distance(checkpoints[i].position, transform.position));
    }

    void ChangeCheckpoint()
    {
        i = Random.Range(0, checkpoints.Length);
        GetComponent<NavMeshAgent>().destination = checkpoints[i].transform.position;
    }
}
