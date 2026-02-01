using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ScoreCheckCondition : DynamicCondition
{
    [SerializeField] Stats StatToCheck;
    [SerializeField] Comparison Comparison;
    [SerializeField] float value;
    public override bool Evaluate()
    {
        switch (Comparison)
        {
            case Comparison.LessThan:
                return Gamestate.GetScore(StatToCheck) <= value;
            case Comparison.GreaterThan:
                return Gamestate.GetScore(StatToCheck) >= value;
        }
        return false;
    }
}

public enum Comparison
{
    LessThan,
    GreaterThan
}
