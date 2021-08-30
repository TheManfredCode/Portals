using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPortal : MonoBehaviour
{
    [SerializeField] private Vector3 _pushDirection;
    [SerializeField] private float _pushForce;
    [SerializeField] private float _minPushForce;

    private void Start()
    {
        _pushDirection.Normalize();
    }

    public IEnumerator DoTeleportation(Movable cube, TeleportedObjectAnimation cubeAnimator)
    {
        cubeAnimator.EnterAimation();
        Vector3 pushDirection = ChangeDirction(cube.Speed);

        yield return new WaitForSeconds(cubeAnimator.EnterAnimationDuration);

        Teleport(cube, pushDirection);
        cubeAnimator.ExitAnimation();
    }

    private void Teleport(Movable cube, Vector3 direction)
    {
        cube.transform.position = transform.position;

        Rigidbody cubeRigidboody = cube.GetComponent<Rigidbody>();

        PushObject(cubeRigidboody, direction);
    }

    private Vector3 ChangeDirction(float speed)
    {
        return _pushDirection* speed;
    }

    private void PushObject(Rigidbody rigidbody, Vector3 direction)
    {
        rigidbody.velocity = Vector3.zero;

        rigidbody.AddForce(direction * _pushForce + _pushDirection * _minPushForce, ForceMode.VelocityChange);
    }

}
