using System.Linq;

public class FeatureAmountCondition : Condition
{
    public FeatureClasses FeatureClass;

    public int DesiredFeatureAmount;

    public override bool TrainerMeetsCondition(Trainer trainer)
    {
        var featureAmount = trainer.UnlockedFeatures.Count(feature => IsClassFeature(feature));

        return featureAmount >= DesiredFeatureAmount;
    }

    private bool IsClassFeature(Feature feature)
    {
        return feature.FeatureClass == FeatureClass
            && feature.FeatureType != FeatureTypes.AdvancedClass
            && feature.FeatureType != FeatureTypes.Class;
    }
}