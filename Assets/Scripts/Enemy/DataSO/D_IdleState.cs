using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newIdleData", menuName = "Data/State Data/IdleData", order = 0)]
public class D_IdleState : ScriptableObject
{
    public float idleWaitTimeMax = 2.5f;
    public float idleWaitTimeMin = .5f;
}
