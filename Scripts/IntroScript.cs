using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Intro");
    }

    IEnumerator Intro()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }
}
