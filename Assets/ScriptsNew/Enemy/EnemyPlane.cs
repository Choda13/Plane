using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlane : MonoBehaviour, IEnemy, IPlaneController
{
    [SerializeField]PlaneMovement planeController;
    GameObject target;
    Vector3 attackRadius;
    public void SetTarget(GameObject target)
    {
        this.target = target;
    }
    public void SetAttackRange(Vector3 radius)
    {
        attackRadius = radius;
    }
    public void Attack()
    {
        //PUC PUC
    }
    public void SpeedUp(int value)
    {
        planeController.SpeedUp(1);
    }
    public void SlowDown(int value)
    {
        planeController.SlowDown(1);
    }
    public void Pitch(float value)
    {
        planeController.Pitch(value);
    }
    public void Roll(float value)
    {
        planeController.Roll(value);
    }
    public void Yaw(float value)
    {
        planeController.Yaw(value);
    }
}
