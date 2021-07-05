using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PopDamage : MonoBehaviour
{
    [SerializeField]
    Text txt = null;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
    }
    public void Damage(int dmg)
    {
        txt.text = "" + dmg;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 1f * 0.1f, 0);
    }
}
