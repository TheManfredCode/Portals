using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailureConditions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out FailureConditionObject failureObject))
            Debug.Log("failure!");
    }
}
