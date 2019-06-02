using UnityEngine;

public class FeatureCondition : Condition
{
    [HideInInspector]
    public int FeatureID;

    [HideInInspector]
    public FeatureClasses FeatureClass;

    public override bool TrainerMeetsCondition(Trainer trainer)
    {
        return trainer.UnlockedFeatures.Exists(feature => feature.FeatureID == FeatureID);
    }
}