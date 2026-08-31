using UnityEngine;

[CreateAssetMenu]
public class EnemyAttackData : ScriptableObject
{
    public float duration;

    public float hitTime;
    public float recoveryTime;

    public float damage;
    public float range;
    public float angle;
}