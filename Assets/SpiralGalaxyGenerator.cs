using UnityEngine;

public class SpiralGalaxyGenerator : MonoBehaviour
{
    public int numberOfParticles = 1000; // Number of particles in the galaxy
    public float spiralArmLength = 5f; // Length of each spiral arm
    public float spiralArmCount = 5; // Number of spiral arms
    public float particleSize = 0.1f; // Size of each particle

    private new ParticleSystem particleSystem;
    private ParticleSystem.Particle[] particles;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        var main = particleSystem.main;
        main.maxParticles = numberOfParticles;

        particles = new ParticleSystem.Particle[numberOfParticles];
        particleSystem.Emit(numberOfParticles);
        particleSystem.GetParticles(particles);

        GenerateSpiralGalaxy();
    }

    void GenerateSpiralGalaxy()
    {
        for (int i = 0; i < numberOfParticles; i++)
        {
            float t = i / (float)numberOfParticles;
            float angle = t * spiralArmCount * Mathf.PI * 2;
            float distance = Mathf.Sqrt(t) * spiralArmLength;

            float x = distance * Mathf.Cos(angle);
            float y = distance * Mathf.Sin(angle);

            particles[i].position = new Vector3(x, y, 0);
            particles[i].startSize = particleSize;
            particles[i].startColor = new Color(Random.value, Random.value, Random.value);
        }

        particleSystem.SetParticles(particles, particles.Length);
    }
}
