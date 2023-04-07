using System;
using Unity.Mathematics;
using UnityEngine;

public class ParticlesContainer : MonoBehaviour
{ //Alpha version 0.00001
    public static ParticlesContainer Instance;

    [SerializeField] private ParticleSystem[] particles;
    
    private void Awake()
    {
        Instance = this;
    }

    public void InvokeParticle(Vector3 position, int type)
    {
        var test = Instantiate(particles[type], position, quaternion.identity);
        test.Play();
    }
}
