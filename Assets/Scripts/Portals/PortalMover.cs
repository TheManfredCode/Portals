using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalMover : MonoBehaviour
{
    private Vector3 _worldPosition;

    private void OnMouseDrag()
    {
        Plane plane = new Plane(Vector3.up, 0);

        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            _worldPosition = ray.GetPoint(distance);
        }

        transform.position = _worldPosition;
    }
}
