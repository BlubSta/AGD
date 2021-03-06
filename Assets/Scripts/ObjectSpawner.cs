﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    public Terrain terrain;
    public int numberOfObjects; // number of objects to place
    private int currentObjects; // number of placed objects
    public GameObject objectToPlace; // GameObject to place
    public int sphereRadius;
    public float scaleMultiplier;
    public float scaleVariation = 0f;
    public float yOffset;
    public List<int> textureIDs;
    private int terrainWidth; // terrain size (x)
    private int terrainLength; // terrain size (z)
    private int terrainPosX; // terrain position x
    private int terrainPosZ; // terrain position z
    private TerrainDetector td;
    void Start()
    {
        td = new TerrainDetector();
        // terrain size x
        terrainWidth = (int)terrain.terrainData.size.x;
        // terrain size z
        terrainLength = (int)terrain.terrainData.size.z;
        // terrain x position
        terrainPosX = (int)terrain.transform.position.x;
        // terrain z position
        terrainPosZ = (int)terrain.transform.position.z;


        for (int i = 0; i < 5000 && currentObjects < numberOfObjects; i++)
        {
            // generate random x position
            int posx = Random.Range(terrainPosX, terrainPosX + terrainWidth);
            // generate random z position
            int posz = Random.Range(terrainPosZ, terrainPosZ + terrainLength);
            // get the terrain height at the random position
            float posy = Terrain.activeTerrain.SampleHeight(new Vector3(posx, 0, posz)) - yOffset - 1.1f;
            // create new gameObject on random position


            Collider[] cols = Physics.OverlapSphere(new Vector3(posx, posy, posz), sphereRadius);
            foreach (Collider col in cols)
            {
                if (col.gameObject != terrain.gameObject)
                {
                    continue;
                }
            }
            if (textureIDs.Count != 0)
            {
                if (textureIDs.Contains(td.GetActiveTerrainTextureIdx(new Vector3(posx, posy, posz))))
                {
                    GameObject newObject = (GameObject)Instantiate(objectToPlace, new Vector3(posx, posy, posz), Quaternion.Euler(0, Random.Range(0.0f, 360.0f), 0));
                    newObject.transform.localScale *= scaleMultiplier + Random.RandomRange(-scaleVariation, scaleVariation);
                    currentObjects += 1;
                }
            }
            else
            {
                GameObject newObject = (GameObject)Instantiate(objectToPlace, new Vector3(posx, posy, posz), Quaternion.Euler(0, Random.Range(0.0f, 360.0f), 0));
                newObject.transform.localScale *= scaleMultiplier;
                currentObjects += 1;
            }

        }

        print("name: " + objectToPlace.name + " currentObj: " + currentObjects);

    }
}
