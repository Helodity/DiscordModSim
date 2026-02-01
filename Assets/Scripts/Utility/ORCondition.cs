using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ORCondition : DynamicCondition
{
    [SerializeReference, SubclassSelector]  List<DynamicCondition> conditionList;

    public override bool Evaluate()
    {
        foreach (DynamicCondition condition in conditionList)
        {
            if(condition.Evaluate()) return true;
        }
         return false;
    }
}
