using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FailureConditions : MonoBehaviour
{
    public event UnityAction Failed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out FailureConditionObject failureObject))
            Failed?.Invoke();
    }
}
