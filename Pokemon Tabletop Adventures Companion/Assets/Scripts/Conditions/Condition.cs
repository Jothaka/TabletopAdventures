using System;
using UnityEngine;

[Serializable]
public class Condition : ScriptableObject
{
    public virtual bool TrainerMeetsCondition(Trainer trainer)
    {
        return true;
    }
}
