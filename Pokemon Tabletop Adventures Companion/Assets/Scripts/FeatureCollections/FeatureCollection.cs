using System.Collections.Generic;

public static class FeatureCollection
{
    private static readonly Dictionary<int, string> GeneralFeatures
        = new Dictionary<int, string>
        {
            {0,"Use Pokédex" },
            {1,"Aim for the Horn!" },
            {2,"Aim for the Horn! +" },
            {3,"Back Off" },
            {4,"Chosen One" },
            {5,"Dual Wielding" },
            {6,"Give It Your All" },
            {7,"Hey Guys, Watch This" },
            {8,"I Can Take a Hit" },
            {9,"I can Take a Hit +" },
            {10,"I Believe in You!" },
            {11,"League Member" },
            {12,"Let Me Help You With That" },
            {13,"Let Me Help You With That +" },
            {14,"Let's Get That Lock Open" },
            {15,"Look Out!" },
            {16,"Mega Evolver" },
            {17,"Multitasking" },
            {18,"Not Yet!" },
            {19,"Random Knowledge" },
            {20,"Remedial First Aid" },
            {21,"Satoshi's Karma" },
            {22,"Satoshi's Luck" },
            {23,"Step Aside!" },
            {24,"Study Session" },
            {25,"Voltorb Flip" },
            {26,"Workout" },
            {27,"Arms User" },
            {28,"Weapon of Choice" }
        };

    #region Ace&AceAdvanced
    private static readonly Dictionary<int, string> AceFeatures
        = new Dictionary<int, string>
        {
            {100,"Ace Trainer" },
            {101,"Enhanced Training" },
            {102,"Improved Attacks" },
            {103,"Affirmation" },
            {104,"Beast Master" },
            {105,"Break Through!" },
            {106,"Brutal Workout" },
            {107,"Constructive Criticism" },
            {108,"Focus" },
            {109,"Improved Attacks +" },
            {110,"Improved Attacks Z" },
            {111,"Intimidate" },
            {112,"Press" },
            {113,"Press +" },
            {114,"Taskmaster" }
        };

    private static readonly Dictionary<int, string> ChaserFeatures
        = new Dictionary<int, string>
        {
            {115,"Chaser" },
            {116,"No Escape" },
            {117,"Torrential Assault" },
            {119,"Aha! Got You!" },
            {120,"Bloodthirst" },
            {121,"Don't Stop" },
            {122,"Finish Them!" },
            {123,"Hunting Techniques" },
            {124,"Natural High" },
            {125,"No Escape +" },
            {126,"Pursuit" },
            {127,"Shifting Pursuit" },
            {128,"Sprints" },
            {129,"Thrill of the Hunt" }
        };

    private static readonly Dictionary<int, string> EnduringSoulFeatures
        = new Dictionary<int, string>
        {
            {130,"Enduring Soul" },
            {131,"Boundless Endurance" },
            {132,"Press On!" },
            {133,"Aware" },
            {134,"Hold!" },
            {135,"Padding" },
            {136,"Padding +" },
            {137,"Soul's Protection" },
            {138,"Soul's Endurance" },
            {139,"Split" },
            {140,"Stand!" },
            {141,"Still Standing" },
            {142,"Still Standing +" }
        };
    #endregion

    public static Dictionary<int, string> GetClassFeatures(FeatureClasses featureClass)
    {
        switch (featureClass)
        {
            case FeatureClasses.General:
                return GeneralFeatures;
            case FeatureClasses.Ace:
                return AceFeatures;
            case FeatureClasses.Chaser:
                return ChaserFeatures;
            case FeatureClasses.EnduringSoul:
<<<<<<< HEAD
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
=======
                return EnduringSoulFeatures;
>>>>>>> 951bd724f3d1a9e4a17263e7337a2d38df250bd9
            default:
                return new Dictionary<int, string>();
        }
    }
}