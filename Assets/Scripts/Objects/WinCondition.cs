using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private int _objectsRequired;

    private int _objectsGained = 0;

    public event UnityAction Win;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out WinConditionObject winObject))
        {
            _objectsGained++;

            winObject.enabled = false;

            if (_objectsGained == _objectsRequired)
                Win?.Invoke();
        }
    }
}
