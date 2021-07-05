using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasJoint : MonoBehaviour
{
    public Transform Tr;
    Vector3 tr;
    // Start is called before the first frame update
    void Start()
    {
        tr = Tr.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        tr = Tr.position;
        transform.position = new Vector3(tr.x, tr.y+5f, tr.z);
    }
}
