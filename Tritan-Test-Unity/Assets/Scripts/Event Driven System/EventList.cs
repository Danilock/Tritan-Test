using System.Collections.Generic;
using UnityEngine;

public struct SpeedIncrease
{
    public float CurrentSpeed;
    public float AmountIncreased;

    public SpeedIncrease(float currentSpeed, float amountIncreased)
    {
        CurrentSpeed = currentSpeed;
        AmountIncreased = amountIncreased;
    }
}

public struct SpeedDecrease
{
    public float CurrentSpeed;
    public float AmountDecreased;

    public SpeedDecrease(float currentSpeed, float amountDecreased)
    {
        CurrentSpeed = currentSpeed;
        AmountDecreased = amountDecreased;
    }
}

public struct OnScorePoint
{
    public int CurrentScore;

    public OnScorePoint(int currentScore) => CurrentScore = currentScore;
}

public struct OnWinMatch { }

public struct OnLevelRestart { }