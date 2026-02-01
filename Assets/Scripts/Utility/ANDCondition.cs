using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ANDCondition : DynamicCondition
{
    [SerializeReference, SubclassSelector] List<DynamicCondition> conditionList;

    public override bool Evaluate()
    {
        foreach (var condition in conditionList)
        {
            if(!condition.Evaluate()) return false;
        }
        return true;
    }
    
}
