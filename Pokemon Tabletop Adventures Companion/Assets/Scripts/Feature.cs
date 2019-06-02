using System.Collections.Generic;
using UnityEngine;

public class Feature : ScriptableObject
{
    [HideInInspector]
    public int FeatureID;

    [HideInInspector]
    public List<Condition> FeatureConditions = new List<Condition>();
    [HideInInspector]
    public FeatureTiming FeatureTiming;
    public FeatureTypes FeatureType;
    public string Target;
    public string Trigger;
    [TextArea]
    public string FeatureEffect;

    [HideInInspector]
    public int SelectedFeatureCollection;

    public bool TrainerMeetsCondition(Trainer trainer)
    {
        if (FeatureConditions.Count > 0)
        {
            for (int i = 0; i < FeatureConditions.Count; i++)
            {
                if (!FeatureConditions[i].TrainerMeetsCondition(trainer))
                    return false;
            }
        }
        return true;
    }
}