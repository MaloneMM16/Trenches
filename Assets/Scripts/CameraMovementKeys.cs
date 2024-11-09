using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using UnityEngine;

public class CameraMovementKeys : MonoBehaviour
{

    public float dragSpeed;
    public float moveTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveTimer += 0.01f;
            transform.Translate(new UnityEngine.Vector3(dragSpeed * moveTimer * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveTimer += 0.01f;
            transform.Translate(new UnityEngine.Vector3(-dragSpeed * moveTimer * Time.deltaTime, 0, 0));
            
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveTimer += 0.01f;
            transform.Translate(new UnityEngine.Vector3(0, -dragSpeed * moveTimer * Time.deltaTime, 0));
            
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveTimer += 0.01f;
            transform.Translate(new UnityEngine.Vector3(0, dragSpeed *moveTimer* Time.deltaTime, 0));
            
        }
        else if (!Input.GetKey(KeyCode.RightArrow) &&
            !Input.GetKey(KeyCode.LeftArrow) &&
            !Input.GetKey(KeyCode.DownArrow) &&
            !Input.GetKey(KeyCode.UpArrow))
        {
            moveTimer = 1;
        }

    }
}
