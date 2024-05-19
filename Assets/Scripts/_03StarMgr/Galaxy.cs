using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Galaxy : MonoBehaviour
{
    // virutal method to create a galaxy
    public abstract void CreateAndPosition();

    internal class GalaxyType
    {
    }
}


public enum GalaxyType
{
    SpiralGalaxy = 1,
    EllipticalGalaxy = 2,
    OpenCluster = 3,
    IrregularGalaxy = 4,
    GlobularCluster = 5
}


