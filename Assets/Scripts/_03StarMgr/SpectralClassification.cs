using UnityEngine;

[System.Serializable]
public class SpectralClassification
{
    public string classification;
    public Color color;
    public float distribution;

    public SpectralClassification(string classification, Color color, float distribution)
    {
        this.classification = classification;
        this.color = color;
        this.distribution = distribution;
    }

    public override string ToString()
    {
        return $"Classification: {classification}, Color: {color}, Distribution: {distribution}";
    }
}