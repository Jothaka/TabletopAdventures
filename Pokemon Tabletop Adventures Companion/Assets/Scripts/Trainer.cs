using System.Collections.Generic;
using UnityEngine;

public class Trainer : MonoBehaviour
{
    [Header("Stats")]
    public int Level = 0;
    public int AvailableStatPoints = 30;
    public int AvailableFeaturePoints = 0;
    public int HP = 6;
    public int ATK = 6;
    public int DEF = 6;
    public int SATK = 6;
    public int SDEF = 6;
    public int SPD = 6;

    [Header("Achievements")]
    public int Badges = 0;
    public int Medals = 0;
    public int ContestRibbons = 0;

    [Header("Features")]
    public List<Feature> UnlockedFeatures = new List<Feature>();

    public int Health { get { return (HP * 4) + (Level * 4); } }

    public void SetMockupFeatures()
    {
        Feature pokedexFeature = ScriptableObject.CreateInstance<Feature>();
        pokedexFeature.FeatureID = 0; //Use Pokedex
        pokedexFeature.FeatureClass = FeatureClasses.General;
        pokedexFeature.FeatureType = FeatureTypes.AtWill;

        UnlockedFeatures.Add(pokedexFeature);

        Feature aceAffirmationFeature = ScriptableObject.CreateInstance<Feature>();
        aceAffirmationFeature.FeatureID = 103; //Affirmation
        aceAffirmationFeature.FeatureClass = FeatureClasses.Ace;
        aceAffirmationFeature.FeatureType = FeatureTypes.Static;

        UnlockedFeatures.Add(aceAffirmationFeature);

        Feature aceBeastMasterFeature = ScriptableObject.CreateInstance<Feature>();
        aceBeastMasterFeature.FeatureID = 104; //Beast Master
        aceBeastMasterFeature.FeatureClass = FeatureClasses.Ace;
        aceBeastMasterFeature.FeatureType = FeatureTypes.Static;

        UnlockedFeatures.Add(aceBeastMasterFeature);

        Feature aceClassFeature = ScriptableObject.CreateInstance<Feature>();
        aceClassFeature.FeatureID = 100; //Ace Trainer
        aceClassFeature.FeatureClass = FeatureClasses.Ace;
        aceClassFeature.FeatureType = FeatureTypes.Class;

        UnlockedFeatures.Add(aceClassFeature);
    }

    public void SetMockupStats()
    {
        Level = 0;
        HP = 11;
        ATK = 11;
        DEF = 11;
        SATK = 11;
        SDEF = 8;
        SPD = 14;
    }
}
