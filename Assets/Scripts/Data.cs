﻿using UnityEngine;
public enum ProjectileForce
{
    low,
    medium,
    high
};

[CreateAssetMenu(fileName = "Data", menuName = "DataScriptableObject", order = 1)]

public class Data : ScriptableObject
{
    public ProjectileForce projectileForce;
    [SerializeField] private float playerMoveSpeed;
    [SerializeField] private float playerFirerate;

    public float MoveSpeed()
    {
        return playerMoveSpeed;
    }
    public float FireRate()
    {
        return playerFirerate;
    }

    public float HitForse()
    {
        switch (projectileForce)
        {
            case ProjectileForce.low:
                return 2000f;
            case ProjectileForce.medium:
                return 5000f;
            case ProjectileForce.high:
                return 10000f;
            default:
                return 2000f;
        }
    }
}

