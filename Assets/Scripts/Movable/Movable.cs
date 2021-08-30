using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TeleportedObjectAnimation))]
public class Movable : MonoBehaviour
{
    private Vector3 _previousPosition;
    private float _speed;

    public float Speed => _speed;

    private void Start()
    {
        _previousPosition = transform.position;
    }

    private void FixedUpdate()
    {
        Vector3 speedVector = transform.position - _previousPosition;
        _speed = Mathf.Abs(speedVector.magnitude);

        _previousPosition = transform.position;
    }
}
