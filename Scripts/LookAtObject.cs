using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtObject : MonoBehaviour {

    // Use this for initialization

    public Transform player, target;
    public float angle;
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 targetPos = target.position;
        Vector3 playerPos = player.position;
        Vector3 dir = targetPos - playerPos;
        angle = -90 - Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);

    }
}
