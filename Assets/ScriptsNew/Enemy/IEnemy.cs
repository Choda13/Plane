using UnityEngine;
public interface IEnemy
{
    void SetTarget(GameObject target);
    void SetAttackRange(Vector3 radius);
    void Attack();
}
