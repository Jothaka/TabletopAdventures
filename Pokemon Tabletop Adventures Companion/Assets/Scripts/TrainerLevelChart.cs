using UnityEngine;
using System;

public class TrainerLevelChart : ScriptableObject
{
    public TrainerLevel[] LevelChart;

    public TrainerLevel GetPlayerLevelData(int level)
    {
        return LevelChart[level];
    }
}

[Serializable]
public class TrainerLevel
{
    public int Level;
    public int FeatsGained;
    public int StatsGained;
}