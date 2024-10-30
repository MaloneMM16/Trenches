using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomSpawn : MonoBehaviour
{
    public GameObject[] rooms;
    private bool flag = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(generateTrench.firstStageDone && !flag)
        {
            flag = true;
            int r = Random.Range(0, rooms.Length);
            Instantiate(rooms[r], transform);
        }
    }
}
