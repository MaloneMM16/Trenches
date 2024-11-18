using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    public static int level = 0;
    public GameObject[] balloonType;
    public List<GameObject> activeBalloons = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activeBalloons.Count == 0)
        {
            for (int i = 0; i < 10 * level; i++)
            {
                spawnLocation();
            }
            level++;
            Debug.Log(level);
        }

        if (Input.GetKey(KeyCode.C) && Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.Equals))
        {
            destroyAll();
        }

    }

    void spawnLocation()
    {
        float spawnPosX = Random.Range(0, 257);

        transform.position = new Vector3(spawnPosX, 10, 250);

        if (level < 5)
        {
            createBalloon(balloonType[0]);
        }
        else if (level > 5 && level < 10)
        {
            int r = Random.Range(0, 2);
            createBalloon(balloonType[r]);
        }
        else if (level > 10 && level < 20)
        {
            int r = Random.Range(0, 3);
            createBalloon(balloonType[r]);
        }
        else if (level > 20)
        {
            int r = Random.Range(0, 4);
            createBalloon(balloonType[r]);
        }
    }

    void createBalloon(GameObject balloon)
    {
        GameObject newBallon = Instantiate(balloon, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
        activeBalloons.Add(newBallon);
    }

    void destroyAll()
    {
        level++;
        for (int i = activeBalloons.Count - 1; i >= 0; i--)
        {
            Destroy(activeBalloons[i]);
            activeBalloons.RemoveAt(i);
        }
    }
}
