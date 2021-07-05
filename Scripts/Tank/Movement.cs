using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody player;
    public float moveSpeed, turnSpeed;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody>();
        //moveSpeed = 10f;
        // turnSpeed = 60f;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 v3 = new Vector3(0.0f, Input.GetAxis("Horizontal"));
        transform.Rotate(v3 * turnSpeed * Time.deltaTime);
        v3 = new Vector3(0.0f, 0.0f, Input.GetAxis("Vertical"));
        transform.Translate(v3 * moveSpeed * Time.deltaTime);

    }
}

