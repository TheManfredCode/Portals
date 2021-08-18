using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterPortal : MonoBehaviour
{
    [SerializeField] private ExitPortal _exitPortal;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Movable cube) && other.TryGetComponent(out TeleportedObjectAnimation cubeAnimator))
        {
            StartCoroutine(_exitPortal.DoTeleportation(cube, cubeAnimator));
        }
    }
}
