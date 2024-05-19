using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class StarMgr : MonoBehaviour
{
    public GameObject[] starPrefab;
    public int starCount;
    public float starScale = 0.1f;
    public float factorStarScale = 0.05f;
    public int starLayer = 8;

    public float worldWidth = 20;
    public float worldHeight = 20;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < starCount; i++)
        {
            // Randomly instantiate a star prefab at a random position
            int RandomIndex = Random.Range(0, starPrefab.Length);

            // create a star object as child of this object
            GameObject star = Instantiate(starPrefab[RandomIndex], RandomPosition(), Quaternion.identity, this.transform);
            star.transform.SetParent(transform);

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
        float x = Random.Range(-worldWidth, worldWidth);
        float y = Random.Range(-worldHeight, worldHeight);
        return new Vector3(x, y, 0);
    }
}
