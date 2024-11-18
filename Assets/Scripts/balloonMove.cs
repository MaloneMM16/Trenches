using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balloonMove : MonoBehaviour
{
    public float speed;

    int health;

    Rigidbody rb;

    enemySpawn Es;

    GameObject enemySpawner;

    public GameObject parent;

    public static int playerHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        rb = GetComponent<Rigidbody>();
        enemySpawner = GameObject.FindWithTag("enemySpawner");
        Es = enemySpawner.GetComponent<enemySpawn>();
        
    }
    // Update is called once per frame
    void Update()
    {


        transform.Translate(Vector3.back * speed * Time.deltaTime);
        

        if (transform.position.y < 0)
        {
            rb.AddForce(transform.up * 10);
        }



        if (health <= 0)
        {
            if (this.tag == "RedBalloon")
            {
                mouseSelector.money += 1;
                Es.activeBalloons.Remove(parent);
                Destroy(parent);
                Destroy(this.gameObject);
            }
            else if (this.tag == "BlueBalloon")
            {
                GameObject newBalloon = Instantiate(Es.balloonType[0], transform.position, Quaternion.identity);
                mouseSelector.money += 1;
                Es.activeBalloons.Add(newBalloon);
                Es.activeBalloons.Remove(parent);
                Destroy(parent);
                Destroy(this.gameObject);
            }
            else if (this.tag == "GreenBalloon")
            {
                GameObject newBalloon = Instantiate(Es.balloonType[1], transform.position, Quaternion.identity);
                mouseSelector.money += 1;
                Es.activeBalloons.Add(newBalloon);
                Es.activeBalloons.Remove(parent);
                Destroy(parent);
                Destroy(this.gameObject);
            }
            else if (this.tag == "YellowBalloon")
            {
                GameObject newBalloon = Instantiate(Es.balloonType[2], transform.position, Quaternion.identity);
                mouseSelector.money += 1;
                Es.activeBalloons.Add(newBalloon);
                Es.activeBalloons.Remove(parent);
                Destroy(parent);
            }
        }

        if (this.tag == "RedBalloon" && transform.position.z <= 0)
        {
            playerHealth -= 1;
            Es.activeBalloons.Remove(parent);
            Destroy(this.gameObject);
        }
        else if (this.tag == "BlueBalloon" && transform.position.z <= 0)
        {
            playerHealth -= 2;
            Es.activeBalloons.Remove(parent);
            Destroy(this.gameObject);
        }
        else if (this.tag == "GreenBalloon" && transform.position.z <= 0)
        {
            playerHealth -= 3;
            Es.activeBalloons.Remove(parent);
            Destroy(this.gameObject);
        }
        else if (this.tag == "YellowBalloon" && transform.position.z <= 0)
        {
            playerHealth -= 4;
            Es.activeBalloons.Remove(parent);
            Destroy(this.gameObject);
        }


        if(playerHealth <= 0)
        {
            Time.timeScale = 0f;
            Application.Quit();

        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "MGBullet")
        {
            health -= 3;
        }
    }
}
