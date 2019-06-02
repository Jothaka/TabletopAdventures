using System;

public class FeatureCollection
{
    public static Type FeatureClassToCollectionType(FeatureClasses featureClass)
    {
        switch (featureClass)
        {
            case FeatureClasses.General:
                return typeof(GeneralFeatureCollection);
            case FeatureClasses.Ace:
                return typeof(AceFeatureCollection);
            case FeatureClasses.Chaser:
                return typeof(ChaserFeatureCollection);
            case FeatureClasses.EnduringSoul:
                return typeof(EnduringSoulFeatureCollection);
            default:
                return typeof(GeneralFeatureCollection);
        }
    }
}