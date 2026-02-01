using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

public static class Gamestate
{
    static readonly ReadOnlyCollection<float> baseScores = new(new float[]{
        0.5f, //Smelliness
        0.2f, //Exposure
        0.0f, //Police Heat
        0.7f, //Mod skill
        0.5f //Addiction
    });
    //All from 0 - 1 
    static float[] scores = baseScores.ToArray();

    public static void ResetScores()
    {
        Debug.Log("Reset Scores");
        Debug.Log(baseScores[0]);
        scores = baseScores.ToArray();
    }

    public static void AddScore(Stats scoreType, float amt)
    {
        if (scoreType == Stats.SIZE)
        {
            Debug.LogError("Tried to get SIZE"); 
            return;
        }
        scores[(int)scoreType] += amt;
    }

    public static float GetScore(Stats scoreType)
    {
        if (scoreType == Stats.SIZE) Debug.LogError("Tried to get SIZE");
        return scores[(int)scoreType];
    }

    public static void AddScore(float[] scores)
    {
        for (int i = 0; i < (int)Stats.SIZE; i++)
        {
            AddScore((Stats)i, scores[i]);
        }
    }
    public static float[] CreateScoreArray(float smelliness = 0, float exposure = 0, float policeHeat = 0, float modSkill = 0, float addiction = 0)
    {
        return new float[] { smelliness, exposure, policeHeat, modSkill, addiction };
    }
}

public enum Stats {
    Smelliness,
    Exposure,
    PoliceHeat,
    ModSkill,
    Addiction,
    SIZE
}
