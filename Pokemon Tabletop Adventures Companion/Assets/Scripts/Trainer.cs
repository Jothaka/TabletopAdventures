using System.Collections.Generic;
using UnityEngine;

public class Trainer : MonoBehaviour
{
    [Header("Stats")]
    public int Level;
    public int HP;
    public int ATK;
    public int DEF;
    public int SATK;
    public int SDEF;
    public int SPD;

    [Header("Achievements")]
    public int Badges;
    public int Medals;
    public int ContestRibbons;

    [Header("Features")]
    public List<Feature> UnlockedFeatures = new List<Feature>();

    public int Health { get { return (HP * 4) + (Level * 4); } }

   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMockupFeatures()
    {
        Feature pokedexFeature = ScriptableObject.CreateInstance<Feature>();
        pokedexFeature.FeatureID = GeneralFeatureCollection.UsePokedex;
        pokedexFeature.FeatureClass = FeatureClasses.General;
        pokedexFeature.FeatureType = FeatureTypes.AtWill;

        UnlockedFeatures.Add(pokedexFeature);

        Feature aceAffirmationFeature = ScriptableObject.CreateInstance<Feature>();
        aceAffirmationFeature.FeatureID = AceFeatureCollection.Affirmation;
        aceAffirmationFeature.FeatureClass = FeatureClasses.Ace;
        aceAffirmationFeature.FeatureType = FeatureTypes.Static;

        UnlockedFeatures.Add(aceAffirmationFeature);

        Feature aceBeastMasterFeature = ScriptableObject.CreateInstance<Feature>();
        aceBeastMasterFeature.FeatureID = AceFeatureCollection.BeastMaster;
        aceBeastMasterFeature.FeatureClass = FeatureClasses.Ace;
        aceBeastMasterFeature.FeatureType = FeatureTypes.Static;

        UnlockedFeatures.Add(aceBeastMasterFeature);

        Feature aceClassFeature = ScriptableObject.CreateInstance<Feature>();
        aceClassFeature.FeatureID = AceFeatureCollection.AceTrainer;
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
        SDEF = 11;
        SPD = 11;
    }
}
