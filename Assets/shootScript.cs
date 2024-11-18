using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootScript : MonoBehaviour
{
    int damping = 1;
    int enemiesKilled;
    GameObject target;
    bool foundTarget = false;

    public float shootingDelay;
    float shootInterval;

    public GameObject bulletPrefab;
    private List<GameObject> activeBullets;

    // List to track all potential targets within the trigger
    private List<GameObject> potentialTargets = new List<GameObject>();

    void Start()
    {
        activeBullets = new List<GameObject>();
        shootInterval = Time.time + shootingDelay;
    }

    void Update()
    {
        // Check if target is null or destroyed, and attempt to find a new target
        if (target == null || !foundTarget)
        {
            UpdateTarget();
        }

        if (foundTarget)
        {
            // Rotating towards the target
            Vector3 lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            Quaternion targetRotation = Quaternion.LookRotation(lookPos);
            Vector3 currentEulerAngles = transform.rotation.eulerAngles;
            float targetYRotation = targetRotation.eulerAngles.y;
            Vector3 newEulerAngles = new Vector3(
                currentEulerAngles.x,
                Mathf.LerpAngle(currentEulerAngles.y, targetYRotation, Time.deltaTime * damping),
                currentEulerAngles.z
            );
            transform.rotation = Quaternion.Euler(newEulerAngles);

            // Shooting
            if (Time.time > shootInterval)
            {
                shootInterval = Time.time + shootingDelay;
                GameObject bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x, 10, transform.position.z), Quaternion.identity);
                float aimError = Random.Range(-0.05f, 0.05f);
                bullet.GetComponent<Rigidbody>().AddForce(new Vector3(transform.forward.x, 0, transform.forward.z) * 5000);

                activeBullets.Add(bullet);
            }
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }

        if (activeBullets.Count >= 100)
        {
            foreach (GameObject bullets in activeBullets)
            {
                Destroy(bullets);
            }
            activeBullets.Clear();
        }

        if (target == null)
        {
            foundTarget = false;
            UpdateTarget();
        }
    }

    // Detects the target when entering trigger
    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("RedBalloon") || other.CompareTag("BlueBalloon") ||
            other.CompareTag("GreenBalloon") || other.CompareTag("YellowBalloon"))
        {
            potentialTargets.Add(other.gameObject);

            // If no target is currently set, assign the new object as the target

        }
    }

    // Reset target and remove from potential targets when exiting trigger
    void OnTriggerExit(Collider other)
    {
        if (potentialTargets.Contains(other.gameObject))
        {
            potentialTargets.Remove(other.gameObject);
        }

        if (other.gameObject == target)
        {
            UpdateTarget();
        }
    }

    // Update the current target to the first available object in the list
    void UpdateTarget()
    {
        potentialTargets.RemoveAll(item => item == null);
        if (potentialTargets.Count > 0)
        {
            target = potentialTargets[0];
            foundTarget = true;
        }
        else
        {
            target = null;
            foundTarget = false;
        }
    }
}
