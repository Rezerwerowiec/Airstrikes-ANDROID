using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingOnHills : MonoBehaviour
{
    void Update()
    {
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, 0.5f, -(transform.up), out hit, 1, LayerMask.NameToLayer("Ground")))
        {
            transform.rotation = Quaternion.LookRotation(Vector3.Cross(transform.right, hit.normal));
                    }

    }
}
