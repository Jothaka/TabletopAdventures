using System;
using System.Collections.Generic;

[Serializable]
public class OrCondition : Condition
{
    public List<Condition> ConditionsToCheck;

    public override bool TrainerMeetsCondition(Trainer trainer)
    {
        if (ConditionsToCheck.Count > 0)
        {
            for (int i = 0; i < ConditionsToCheck.Count; i++)
            {
                if (ConditionsToCheck[i].TrainerMeetsCondition(trainer))
                    return true;
            }
            return false;
        }
        return true;
    }
}
