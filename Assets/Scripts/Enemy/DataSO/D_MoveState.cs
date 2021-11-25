using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newMoveData", menuName = "Data/State Data/MoveData", order = 1)]

public class D_MoveState : ScriptableObject
{
    public float MoveSpeed = 125f;
    public int MinPatrolTime = 6;
    public int MaxPatrolTime = 10;
}
