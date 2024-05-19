using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralGalaxy : Galaxy
{
    public GameObject[] starPrefab;
    public int starCount;
    public float starScale;
    public float factorStarScale;
    public int starLayer;
    public float galaxyRadius;
    public int indexGalaxyType = 1;
    public float worldWidth = 20;
    public float worldHeight = 20;

    public override void CreateAndPosition()
    {
        //og the creation for demonstration purposes
        Debug.Log($"Created a galaxy of type: {this.GetType().Name}");

        // create stars
        for (int i = 0; i < starCount; i++)
        {
            // get a random star prefab
            GameObject starPrefab = this.starPrefab[UnityEngine.Random.Range(0, this.starPrefab.Length)];

            // create a star
            GameObject star = Instantiate(starPrefab, RandomPosition(), Quaternion.identity, this.transform);

            // get the star script
            Star starScript = star.GetComponent<Star>();

            // create and position the star
            //starScript.CreateAndPosition(starScale, factorStarScale, starLayer, galaxyRadius);

            // Set the scale and layer of the star
            // TODO test to see if these can be set in the prefab or Star.cs script
            // randomize the default scale of the star to within a range +/- .05 of the default scale
            float randomScale = Random.Range((starScale - factorStarScale), (starScale + factorStarScale));
            star.transform.localScale = new Vector3(randomScale, randomScale, randomScale);

            // Set the layer of the star
            star.layer = starLayer;
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
