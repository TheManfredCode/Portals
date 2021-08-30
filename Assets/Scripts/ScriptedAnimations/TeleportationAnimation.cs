using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationAnimation : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Movable movable))
            _particleSystem.Play();
    }
}
