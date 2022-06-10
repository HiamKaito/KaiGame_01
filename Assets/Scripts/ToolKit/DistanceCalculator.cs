using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCalculator
{
    public static float calculatorDis(Transform v1, Transform v2)
    {
        return calculatorDis(v1.position.x, v1.position.y, v2.position.x, v2.position.y);
    }

    public static float calculatorDis(Transform v1, float x2, float y2)
    {
        return calculatorDis(v1.position.x, v1.position.y, x2, y2);
    }

    public static float calculatorDis(float x1, float y1, float x2, float y2)
    {
        return Mathf.Sqrt(Mathf.Pow(x1 - x2, 2) + Mathf.Pow(y1 - y2, 2));
    }
}
