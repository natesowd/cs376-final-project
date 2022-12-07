using UnityEngine;

public static class SpawnUtilities
{

    public static Vector2 Min;

    public static Vector2 Max;


    static SpawnUtilities()
    {
        Min = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width - 10, Screen.height - 700));
        Max = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width - 10, Screen.height - 200));
    }


    public static Vector2 RandomVisiblePoint
        => new Vector2(Random.Range(Min.x, Max.x),
            Random.Range(Min.y, Max.y));


    public static Vector2 RandomFreePoint(float radius)
    {
        var position = RandomVisiblePoint;
        for (var i = 0; i < 50 && !PointFree(position, radius); i++)
            position = RandomVisiblePoint;
        return position;
    }


    public static bool PointFree(Vector2 position, float radius)
    {
        return Physics2D.CircleCast(position, radius, Vector2.up, 0);
    }
}

