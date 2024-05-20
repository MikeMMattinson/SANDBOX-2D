using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    // Updated list to include spectral classification and color
    public List<SpectralClassification> spectralClassification = new List<SpectralClassification>()
    {
        new SpectralClassification("O", new Color(0.6f, 0.8f, 1f), 0.00003f),    // O: Blue
        new SpectralClassification("B", new Color(0.7f, 0.8f, 1f), 0.1f),        // B: Blue White
        new SpectralClassification("A", new Color(0.8f, 0.9f, 1f), 0.6f),        // A: White
        new SpectralClassification("F", new Color(1f, 1f, 0.9f), 3f),            // F: Yellow White
        new SpectralClassification("G", new Color(1f, 1f, 0.8f), 7.6f),          // G: Yellow
        new SpectralClassification("K", new Color(1f, 0.8f, 0.6f), 12.1f),       // K: Orange
        new SpectralClassification("M", new Color(1f, 0.6f, 0.6f), 76.45f)       // M: Red
    };
    private List<float> cumulativeDistribution = new List<float>();

    void Start()
    {
        // Calculate cumulative distribution and select classification  
        CalculateCumulativeDistribution();
        SpectralClassification selectedClassification = SelectClassificationBasedOnDistribution();
        GetComponent<Renderer>().material.color = selectedClassification.color;

        // Assign sprite based on spectral classification
        StarSpriteAssigner spriteAssigner = GetComponent<StarSpriteAssigner>();
        if (spriteAssigner != null)
        {
            spriteAssigner.AssignSpriteBasedOnClassification(selectedClassification.classification);
        }   
    }

    void CalculateCumulativeDistribution()
    {
        float total = 0;
        foreach (var classification in spectralClassification)
        {
            total += classification.distribution;
            cumulativeDistribution.Add(total);
        }
    }

    SpectralClassification SelectClassificationBasedOnDistribution()
    {
        float randomPoint = Random.Range(0, cumulativeDistribution[cumulativeDistribution.Count - 1]);
        for (int i = 0; i < cumulativeDistribution.Count; i++)
        {
            if (randomPoint <= cumulativeDistribution[i])
            {
                return spectralClassification[i];
            }
        }
        return null; // Should never hit this if distributions are set up correctly
    }

 

}