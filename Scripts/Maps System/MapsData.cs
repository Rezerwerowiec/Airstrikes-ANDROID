using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapsData : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> mapsData;

    private void Start()
    {
        RandomMap();
    }
    public void RandomMap()
    {
        int luckyNumber = Random.Range(0, mapsData.Count);

        for(int i = 0; i<mapsData.Count; i++)
        {
            if(i == luckyNumber) mapsData[i].GetComponent<MapLoader>().MapChosen(true); else mapsData[i].GetComponent<MapLoader>().MapChosen(false);
        }
        
    }

}
