using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerMoves : MonoBehaviour
{
    // Start is called before the first frame update
    float factor = 80f;
    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                transform.Translate(touch.deltaPosition.x / Screen.height * factor, touch.deltaPosition.y / Screen.height * factor, 0.0f);
            }
        }
    }
}
