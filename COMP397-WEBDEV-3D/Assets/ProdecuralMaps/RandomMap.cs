using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class RandomMap : MonoBehaviour
{
    [SerializeField] private int width;
    [SerializeField] private int depth;
    [SerializeField] private List<GameObject> prefabTilesList = new List<GameObject>();
    [SerializeField] private GameObject[] prefabTiles;

    [SerializeField] private Transform mapParent;
    [SerializeField] private Transform startPoint;
    //[SerializeField] private List<GameObject> map;
    [SerializeField] private GameObject[,] map;
    [SerializeField] private List<List<GameObject>> listMap = new List<List<GameObject>>();
    private float xOffset, zOffset;
    [SerializeField] private float perlinScale;

    private void Start()
    {

        map = new GameObject[width, depth];
        xOffset = Random.Range(1000, 5000);
        zOffset = Random.Range(-1000, -5000);
        //BuildRandonMap();
        BuildPerlinNoiseMap();
       
        // build Wave function collaspe map();

    }

    private void BuildRandonMap()
    {
        for (int row = 0; row < depth; row++)
        {
            List<GameObject> listRow = new List<GameObject>();

            for (int col = 0; col < width; col++)
            {

                if (row == 0 && col == 0)
                {
                    continue;
                }
                Vector3 pos = new Vector3(col * 50, 0f, row * 50);
                GameObject tile = Instantiate(prefabTilesList[Random.Range(0, prefabTilesList.Count)], pos, Quaternion.identity, mapParent);
                listRow.Add(tile);
                map[col, row] = tile;

            }
            listMap.Add(listRow);

        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            RebuildPerlinMap();
        }
    }

   private void RebuildPerlinMap()
   {
        listMap.Clear();
        for (int row = 0; row < depth; row++)
        {
   

            for (int col = 0; col < width; col++)
            {
                Destroy(map[col, row]);
            }
        }
        
        BuildPerlinNoiseMap();
    }

    private void BuildPerlinNoiseMap()
    {
        for (int row = 0; row < depth; row++)
        {
            List<GameObject> listRow = new List<GameObject>();

            for (int col = 0; col < width; col++)
            {

                if (row == 0 && col == 0)
                {
                    continue;
                }

                float perlinNoiseValue = GetPerlinNoise(col, row);
                Vector3 pos = new Vector3(col * 50, 0f, row * 50);
                GameObject tile = Instantiate(GenerateTileOnPerlinNoise(perlinNoiseValue), pos, Quaternion.identity, mapParent);


                listRow.Add(tile);
                map[col, row] = tile;

            }
            listMap.Add(listRow);

        }
    }


    private float GetPerlinNoise(float x, float z)
    {
        float xCoord = (x + xOffset) * (width * perlinScale);
        float zCoord = (z + zOffset) * (depth * perlinScale);
        return Mathf.Clamp01(Mathf.PerlinNoise(xCoord, zCoord));
    }

    private GameObject GenerateTileOnPerlinNoise(float noiseValue)
    {
        Debug.Log($"GenerateTilesOnPerlin ({noiseValue})");
        switch (noiseValue)
        {
            case <= 0.20f: return prefabTiles[0]; ////water
            case <= 0.5f: return prefabTiles[1]; ///grass
            case <= 0.6f: return prefabTiles[2]; //road
            case <= 0.8f: return prefabTiles[3]; //ground
            case <= 1f: return prefabTiles[4]; ///lava
            default: return prefabTilesList[1]; ///default is grass
        }

    }
}




//list is dynamic - > add and remove it in runtime and will resize
///array is fixed size