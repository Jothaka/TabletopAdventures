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
            case FeatureClasses.StatAce:
                return typeof(StatAceFeatureCollection);
            case FeatureClasses.Strategist:
                return typeof(StrategistFeatureCollection);
//            case FeatureClasses.TagBattler:
//                return typeof(TagBattlerFeatureCollection);
//            case FeatureClasses.TypeAce:
//                return typeof(TypeAceFeatureCollection);
//            case FeatureClasses.Underdog:
//                return typeof(UnderdogFeatureCollection);
            default:
                return typeof(GeneralFeatureCollection);
        }
    }
}