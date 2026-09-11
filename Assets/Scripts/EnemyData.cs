using UnityEngine;

[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    [Header("Decision Data")]
    public float enterAttackRange;
    // 与正前方的最大夹角，例如 45° 表示总攻击范围 90°
    [Range(0f, 180f)] public float attackFacingAngle = 45f;
    
    [Header("Attack Data")]
    public float duration;

    public float hitTime;
    public float recoveryTime;

    public float damage;
    public float range;
    public float angle;
}