using System;
using UnityEngine;

[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    public DecisionData decision;
    public AttackData attack;
}

[Serializable]
public struct DecisionData
{
    public float enterAttackRange;
    // 与正前方的最大夹角，例如 45° 表示总攻击范围 90°
    [Range(0f, 180f)] public float attackFacingAngle;
}

[Serializable]
public struct AttackData
{
    public float duration;
    public float hitTime;
    public float recoveryTime;

    public float damage;
    public float range;
    
    [Range(0f, 180f)]
    public float angle;
}