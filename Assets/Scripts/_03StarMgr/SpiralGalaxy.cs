using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralGalaxy : Galaxy
{
    public GameObject[] starPrefab;
    public int starCount;
    public float centralCluster = .75f;
    public int numberOfArms = 3;
    public float starScale;
    public float factorStarScale;
    public int starLayer;
    public float galaxyRadius;
    public int indexGalaxyType = 1;
    public float worldWidth = 20;
    public float worldHeight = 20;
    public bool DebugMode = false;

    public override void CreateAndPosition()
    {
        if(DebugMode) Debug.Log($"Created a galaxy of type: {this.GetType().Name}");

        int centralStarCount = (int)(starCount * centralCluster); // 80% of stars
        int spiralStarCount = starCount - centralStarCount; // remaining 20%

        // Create central stars
        for (int i = 0; i < centralStarCount; i++)
        {
            GameObject starPrefab = this.starPrefab[UnityEngine.Random.Range(0, this.starPrefab.Length)];
            GameObject star = Instantiate(starPrefab, RandomCentralPosition(), Quaternion.identity, this.transform);
            SetupStar(star);
        }

        // Create spiral stars
        for (int i = 0; i < spiralStarCount; i++)
        {
            GameObject starPrefab = this.starPrefab[UnityEngine.Random.Range(0, this.starPrefab.Length)];
            GameObject star = Instantiate(starPrefab, RandomSpiralPosition(i, spiralStarCount), Quaternion.identity, this.transform);
            SetupStar(star);
        }
    }

    Vector3 RandomCentralPosition()
    {
        // Generate a position closer to the center
        float radius = galaxyRadius * 0.2f; // Adjust as needed
        float angle = Random.Range(0, 2 * Mathf.PI);
        float distance = Random.Range(0, radius);
        return new Vector3(distance * Mathf.Cos(angle), distance * Mathf.Sin(angle), 0);
    }

    Vector3 RandomSpiralPosition(int index, int totalSpiralStars)
    {
        float armSeparation = (2 * Mathf.PI) / numberOfArms; // Separation between arms in radians
        float angleIncrement = 0.5f; // Adjust for tighter or looser spirals

        // Calculate the position for this star in its arm
        float armIndex = index % numberOfArms; // Determine which arm this star belongs to
        float distance = (index / (float)totalSpiralStars) * galaxyRadius; // Linear distribution of stars along the arm
        float angle = armIndex * armSeparation + distance * angleIncrement; // Adjust angle based on arm and position along the arm

        return new Vector3(distance * Mathf.Cos(angle), distance * Mathf.Sin(angle), 0);
    }

    void SetupStar(GameObject star)
    {
        // Set the scale and layer of the star
        float randomScale = Random.Range((starScale - factorStarScale), (starScale + factorStarScale));
        star.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
        star.layer = starLayer;
    }

    // random position function
    Vector3 RandomPosition()
    {
        float x = UnityEngine.Random.Range(-worldWidth, worldWidth);
        float y = UnityEngine.Random.Range(-worldHeight, worldHeight);
        return new Vector3(x, y, 0);
    }
    
}
