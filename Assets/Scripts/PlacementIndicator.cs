using System;
using UnityEngine;

public class PlacementIndicator : MonoBehaviour
{
    void Update() {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit, 100f, LayerMask.GetMask("Ground"))) {
            transform.position = hit.point;
        }
    }
}