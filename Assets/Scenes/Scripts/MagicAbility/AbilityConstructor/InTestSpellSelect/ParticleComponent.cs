using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ParticleComponent : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;

    public void InvokeParticle(Vector2 targetPosition)
    {
        Instantiate(particle, targetPosition, quaternion.identity);
        particle.Play();
    }
}
