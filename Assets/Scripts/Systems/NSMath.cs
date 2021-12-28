using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Easy Maths
 * duh
 */

public static class NSMath
{

    //Gets the Distance Between two Objects
    public static bool FloatApproximation(float a, float b, float tolerance)
    {
        return (Mathf.Abs(b - a) < tolerance);
    }

    //Returns a random float between two data points
    public static float RandomFloat(float a, float b)
    {
        return Random.Range(a, b);
    }
}
