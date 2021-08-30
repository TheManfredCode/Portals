using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _moveDistance;
    [SerializeField] private float _moveDuration;

    private void Start()
    {
        _direction.Normalize();

        Move();
    }

    public Tween Move(float delay = 0)
    {
        Vector3 targetPosition = transform.position + _direction * _moveDistance;

        Tween move = transform.DOMove(targetPosition, _moveDuration).SetDelay(delay);

        return move;
    }
}
