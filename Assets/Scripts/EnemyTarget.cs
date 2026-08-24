using System;
using UnityEngine;

public class EnemyTarget : MonoBehaviour
{
    [SerializeField] Transform target;
    
    public Transform Target { get; private set; }
    
    public bool HasTarget => Target != null;
    
    public Vector3 TargetPosition => Target.position;

    void Awake() {
        Target = target;
    }

    public void SetTarget(Transform target) {
        Target = target;
    }
}