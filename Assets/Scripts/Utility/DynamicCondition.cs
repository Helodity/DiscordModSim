using System;
using UnityEngine;

[Serializable]
public abstract class DynamicCondition
{
    public abstract bool Evaluate();
}
