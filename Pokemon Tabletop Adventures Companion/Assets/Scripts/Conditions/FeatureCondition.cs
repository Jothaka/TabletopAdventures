using UnityEngine;

public class FeatureCondition : Condition
{
    [HideInInspector]
    public int FeatureID;

    [HideInInspector]
    public int SelectedFeatureCollection;

    public override bool TrainerMeetsCondition(Trainer trainer)
    {
        return trainer.UnlockedFeatures.Exists(feature => feature.FeatureID == FeatureID);
    }
}