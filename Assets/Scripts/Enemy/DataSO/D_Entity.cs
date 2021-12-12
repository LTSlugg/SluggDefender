using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newBasicEntityData", menuName = "Data/Entity Data", order = 0)]

public class D_Entity : ScriptableObject
{
    public string whatIsHuman = "Human";
    public float raycastDownDistance = 20f;
    public float avoidDistance = 1f;
}
