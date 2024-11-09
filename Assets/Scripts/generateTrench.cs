using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateTrench : MonoBehaviour
{
    public int width;
    public int length;
    public int height;

    int direction; // 0 & 1 = right, 2 = down, 3 = up
    int prevDirection;

    public float trenchDepth;


    public GameObject buildParent;

    public GameObject[] straightTrenches;
    public GameObject[] upTrenches;
    public GameObject[] brTrenches;
    public GameObject[] blTrenches;
    public GameObject[] trTrenches;
    public GameObject[] tlTrenches;

    public GameObject[] fillerRooms;

    public  GameObject[,] roomArray;
    public List<Vector2> loadedRooms;

    public static bool firstStageDone;
    public int movementInt;
    public int movementConstraint = 0;

    public int startingPosition;

    public Terrain terrain;
    private TerrainGenerator terrainScript;

    public static float[,] heightsArray;
    public bool generated;

    void Start()
    {
        terrainScript = terrain.GetComponent<TerrainGenerator>();


        startingPosition = Random.Range(startingPosition-10, startingPosition) * 4;


        transform.position = new Vector3(0, 0, startingPosition);
        direction = 0;

        roomArray = new GameObject[width, length];



        // Start the coroutine to wait for terrain generation to complete
        StartCoroutine(WaitForGenerationDone());
    }

    // Coroutine that waits for the terrain to finish generating
    IEnumerator WaitForGenerationDone()
    {
        // Wait until the terrain generation is complete
        while (!terrainScript.generationDone)
        {
            yield return null; // Wait for the next frame
        }

        // Terrain generation is done, now proceed with trench generation
        Debug.Log("Terrain generation complete! Starting trench generation.");



        StartTrenchGeneration();
    }

    // Function to start trench generation after terrain is ready
    void StartTrenchGeneration()
    {
        if (!firstStageDone)
        {

            while (transform.position.x < width)
            {

                //REMINDER: CHANGE ROTATION BASED ON LAST TURN
                direction = Random.Range(0, 6);
                if (direction == 0 | direction == 1 | direction == 2 | direction == 3)
                {

                    if(prevDirection == 5)
                    {
                        int r = 0;
                        CreateTrench(blTrenches[r]);
                        prevDirection = direction;
                        transform.position += Vector3.right * movementInt;
                    }
                    else if(prevDirection == 4)
                    {
                        int r = 0;
                        CreateTrench(tlTrenches[r]);
                        prevDirection = direction;
                        transform.position += Vector3.right * movementInt;
                    }
                    else
                    {
                        int r = 0; // Use first trench in the array for simplicity
                        CreateTrench(straightTrenches[r]);
                        prevDirection = direction;
                        transform.position += Vector3.right * movementInt;
                    }

                }
                else if (direction == 5 && prevDirection != 4)
                {
                    if (prevDirection == 5 && movementConstraint >= -3)
                    {
                        int r = 0;
                        
                        CreateTrench(upTrenches[r]);
                        prevDirection = direction;
                        movementConstraint -= 1;
                        transform.position += Vector3.back * movementInt;
                    }
                    else if (movementConstraint >= -3)
                    {
                        int r = 0;
                        CreateTrench(trTrenches[r]);
                        prevDirection = direction;
                        movementConstraint -= 1;
                        transform.position += Vector3.back * movementInt;
                    }


                }
                else if (direction == 4 && prevDirection != 5)
                {
                    if (prevDirection == 4 && movementConstraint <= -3)
                    {
                        int r = 0;
                        
                        CreateTrench(upTrenches[r]);
                        prevDirection = direction;
                        movementConstraint += 1;
                        transform.position += Vector3.forward * movementInt;
                    }
                    else if (movementConstraint <= -3)
                    {
                        int r = 0;
                        CreateTrench(brTrenches[r]);
                        prevDirection = direction;
                        movementConstraint += 1;
                        transform.position += Vector3.forward * movementInt;
                    }
                }
                else
                {
                    direction = Random.Range(0, 6);
                }
            }
            if(transform.position.x == width)
            {
                firstStageDone = true;
                startingPosition = Mathf.Clamp(startingPosition / 4, 60, 256);
                transform.position = new Vector3(0, trenchDepth, startingPosition);
                secondStageTrench();
                
            }
            
        }
    }

    void secondStageTrench()
    {
        while (transform.position.x < width)
        {

            //REMINDER: CHANGE ROTATION BASED ON LAST TURN
            direction = Random.Range(0, 6);
            if (direction == 0 | direction == 1 | direction == 2 | direction == 3)
            {

                if (prevDirection == 5)
                {
                    int r = 0;
                    CreateTrench(blTrenches[r]);
                    prevDirection = direction;
                    transform.position += Vector3.right * movementInt;
                }
                else if (prevDirection == 4)
                {
                    int r = 0;
                    CreateTrench(tlTrenches[r]);
                    prevDirection = direction;
                    transform.position += Vector3.right * movementInt;
                }
                else
                {
                    int r = 0; // Use first trench in the array for simplicity
                    CreateTrench(straightTrenches[r]);
                    prevDirection = direction;
                    transform.position += Vector3.right * movementInt;
                }

            }
            else if (direction == 5 && prevDirection != 4)
            {
                if (prevDirection == 5 && movementConstraint >= -3)
                {
                    int r = 0;
                    
                    CreateTrench(upTrenches[r]);
                    prevDirection = direction;
                    movementConstraint -= 1;
                    transform.position += Vector3.back * movementInt;
                }
                else if (movementConstraint >= -3)
                {
                    int r = 0;
                    CreateTrench(trTrenches[r]);
                    prevDirection = direction;
                    movementConstraint -= 1;
                    transform.position += Vector3.back * movementInt;
                }


            }
            else if (direction == 4 && prevDirection != 5)
            {
                if (prevDirection == 4 && movementConstraint <= -3)
                {
                    int r = 0;
                    
                    CreateTrench(upTrenches[r]);
                    prevDirection = direction;
                    movementConstraint += 1;
                    transform.position += Vector3.forward * movementInt;
                }
                else if (movementConstraint <= -3)
                {
                    int r = 0;
                    CreateTrench(brTrenches[r]);
                    prevDirection = direction;
                    movementConstraint += 1;
                    transform.position += Vector3.forward * movementInt;
                }
            }
            else
            {
                direction = Random.Range(0, 6);
            }
        }
        if (transform.position.x == width)
        {
            startingPosition = Mathf.Clamp(startingPosition / 3, 24, 256);
            transform.position = new Vector3(0, trenchDepth, startingPosition);
            finalStageTrench();
        }

    }

    void finalStageTrench()
    {
        while (transform.position.x < width)
        {
            int r = 0; // Use first trench in the array for simplicity
            CreateTrench(straightTrenches[r]);
            prevDirection = direction;
            transform.position += Vector3.right * movementInt;
        }
        FillMap();
    }

    // Function to create a trench at the current position
    void CreateTrench(GameObject trench)
    {
        int x = (int)transform.position.x; // Convert x position from float to int
        int z = (int)transform.position.z; // Convert z position from float to int

        // Instantiate the trench at the calculated height based on the heightmap
        GameObject temp = Instantiate(trench, new Vector3(transform.position.x, trenchDepth, transform.position.z), Quaternion.identity, buildParent.transform);

        // Store the trench object in the roomArray
        //roomArray[x, z] = temp;
        loadedRooms.Add(new Vector2(x, z)); // Keep track of loaded rooms

        // Apply this change to the terrain heightmap
        SetTerrainHeightAtPoint(x, z, 0f);
    }


    // Function to set the terrain height at a specific point
    void SetTerrainHeightAtPoint(int x, int z, float newHeight)
    {
        TerrainData terrainData = terrain.terrainData;

        // Convert world coordinates (x, z) to heightmap coordinates
        int heightmapX = Mathf.RoundToInt((float)x / terrainData.size.x * terrainData.heightmapResolution);
        int heightmapZ = Mathf.RoundToInt((float)z / terrainData.size.z * terrainData.heightmapResolution);

        // Ensure indices are within the valid range
        heightmapX = Mathf.Clamp(heightmapX, 0, terrainData.heightmapResolution);
        heightmapZ = Mathf.Clamp(heightmapZ, 0, terrainData.heightmapResolution);

        // Create a 4x4 array to store the new height at this position
        float[,] heightPatch = new float[4, 4];
        heightPatch[0, 0] = newHeight / terrainData.size.y;  // Normalize height based on terrain size.y

        // Apply the modified height back to the terrain
        terrainData.SetHeights(heightmapX, heightmapZ, heightPatch);
    }


    void FillMap()
    {
        for (int z = 0; z < width + 1; z += 4)
        {
            for (int x = 0; x < length + 1; x += 4)
            {
                if (!loadedRooms.Contains(new Vector2(x, z)))
                {
                    int r = Random.Range(0, fillerRooms.Length);
                    transform.position = new Vector3(x, 0, z);
                    CreateFiller(fillerRooms[r]);
                }
            }
        }
    }

    void CreateFiller(GameObject trench)
    {

        TerrainData terrainData = terrain.terrainData;

        int x = (int)transform.position.x; // Convert x position from float to int
        int z = (int)transform.position.z; // Convert z position from float to int

        int heightmapX = Mathf.RoundToInt(x / terrainData.size.x * terrainData.heightmapResolution +1);
        int heightmapZ = Mathf.RoundToInt(z / terrainData.size.z * terrainData.heightmapResolution +1);



        float terrainHeight = terrainData.GetHeight(heightmapX, heightmapZ);

        // Instantiate the trench at the calculated height based on the heightmap
        GameObject temp = Instantiate(trench, new Vector3(transform.position.x, terrainHeight, transform.position.z), Quaternion.identity, buildParent.transform);

        // Store the trench object in the roomArray
        //roomArray[x, z] = temp;
        loadedRooms.Add(new Vector2(x, z)); // Keep track of loaded rooms


    }
}


