using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public float depth;
    public static int width = 256;
    public static int height = width;

    public float scale = 20f;

    public static float offsetX;
    public static float offsetY;

    public static List<Vector3> HeightCoords;

    public float[,] heights = new float[width, height];

    public float[,] heightData;

    public Terrain terrain;

    public bool generationDone = false;

    void Start()
    {

        offsetX = Random.Range(0f, 99999f);
        offsetY = Random.Range(0f, 99999f);
        terrain = GetComponent<Terrain>();

        terrain.terrainData = GenerateTerrain(terrain.terrainData);

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            terrain.terrainData = GenerateTerrain(terrain.terrainData);
        }
        
    }

    public TerrainData GenerateTerrain (TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;
        
        terrainData.size = new Vector3(width, depth, height);
        terrainData.SetHeights(0, 0, GenerateHeights());
        generationDone = true;
        return terrainData;
    }

    float[,] GenerateHeights ()
    {
        
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                heights[x, y] = CalculateHeight(x, y);
            }
        }

        return heights;
    }

    public float CalculateHeight (int x, int y)
    {
        float xCoord = (float)x / width * scale + offsetX;
        float yCoord = Mathf.Clamp((float)y / height * scale + offsetY, 0, 2);
        return Mathf.PerlinNoise(xCoord, yCoord);
    }





    //heights[x,y] = 0;

}