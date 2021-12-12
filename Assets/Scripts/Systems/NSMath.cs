using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class NSMath
{
    public static bool FloatApproximation(float a, float b, float tolerance)
    {
        return (Mathf.Abs(b - a) < tolerance);
    }

    public static float RandomFloat(float a, float b)
    {
        return Random.Range(a, b);
    }

}
