using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseSelector : MonoBehaviour
{
    public GameObject generator;
    GameObject roomNode;

    public Vector3 pos;
    public float turretHeight;

    private generateTrench loadedRoomScript;
    private Vector3 pointOfInterest;

    private LayerMask trench;
    RaycastHit hit;

    public Terrain terrain;

    public Material OldMaterial;

    Material m_material;

    GameObject selectedTrench;

    public GameObject MgObj;
    public GameObject FhObj;
    public GameObject AtObj;

    public static int money = 500;
    // Start is called before the first frame update
    void Start()
    {
        loadedRoomScript = generator.GetComponent<generateTrench>();
        trench = LayerMask.GetMask("Trench");
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, trench))
        {
            if (selectedTrench != null)
            {
                m_material.color = OldMaterial.color;
            }
            selectedTrench = hit.transform.gameObject;
            m_material = selectedTrench.GetComponent<Renderer>().material;
            m_material.color = Color.white;
        }

        else
        {
            m_material.color = OldMaterial.color;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                pointOfInterest = hit.point;
                foreach (Vector2 value in loadedRoomScript.loadedRooms)
                {
                    if (value.x <= (int)pointOfInterest.x && value.x + 4 > (int)pointOfInterest.x)
                    {
                        float xCoord = value.x;
                        if (value.y <= (int)pointOfInterest.z && value.y + 4 > (int)pointOfInterest.z)
                        {
                            float yCoord = value.y;
                            pos = new Vector3(xCoord, turretHeight, yCoord);
                            transform.position = new Vector3(xCoord, 10, yCoord);
                            Debug.Log(xCoord + ", " + yCoord);

                            roomNode = loadedRoomScript.roomArray[(int)xCoord, (int)yCoord];
                            

                            if(roomNode.tag == "StraightTrench" && scriptOnClick.activeObj == 1 && money >= 50)
                            {
                                createBuilding(MgObj);
                            }
                        }
                    }
                }
            }
        }
    }

    public void createBuilding(GameObject building)
    {
        GameObject weapon = Instantiate(building, new Vector3(pos.x + 2.1f, pos.y, pos.z + 4), Quaternion.identity);

        if(scriptOnClick.activeObj == 1)
        {
            money -= 50;
        }
    }
}