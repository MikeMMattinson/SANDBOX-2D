using System.Collections;
using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using System.Collections.Generic;

public class GalaxyMgr : MonoBehaviour
{
    public int galaxyCount;

    // the world width and height are used to determine the range of random positions for the stars
    // TODO: consider using the camera's size to determine the world width and height
    // TODO: consider putting these in a GameManager script
    public float worldWidth = 20;
    public float worldHeight = 20;

    public GameObject[] galaxyPrefabs;
    public List<GameObject> galaxies = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        CreateGalaxies();
    }   
    
    public void CreateGalaxies()
    {
        for (int i = 0; i < galaxyCount; i++)
        {
            // get a random galaxy prefab
            GameObject galaxyPrefab = galaxyPrefabs[UnityEngine.Random.Range(0, galaxyPrefabs.Length)];

            // create a galaxy
            GameObject galaxy = Instantiate(galaxyPrefab, RandomPosition(), Quaternion.identity, this.transform);

            // add the galaxy to the list of galaxies
            galaxies.Add(galaxy);

            // get the galaxy script
            Galaxy galaxyScript = galaxy.GetComponent<Galaxy>();

            // create and position the galaxy
            galaxyScript.CreateAndPosition();
        }
    }


    // random position function
    Vector3 RandomPosition()
    {
        float x = UnityEngine.Random.Range(-worldWidth, worldWidth);
        float y = UnityEngine.Random.Range(-worldHeight, worldHeight);
        return new Vector3(x, y, 0);
    }    
}
