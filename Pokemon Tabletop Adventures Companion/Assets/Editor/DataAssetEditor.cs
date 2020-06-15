using UnityEngine;
using UnityEditor;

public class DataAssetEditor : ScriptableObject
{
    [MenuItem("Assets/Create/DataAsset/Feature")]
    static void CreateFeature()
    {
        ScriptableObjectUtility.CreateAsset<Feature>();
    }

    [MenuItem("Assets/Create/DataAsset/Pokémon Nature")]
    static void CreatePokemonNature()
    {
        ScriptableObjectUtility.CreateAsset<PokemonNatureData>();
    }

    [MenuItem("Assets/Create/DataAsset/Trainer Level Chart")]
    static void CreateLevelChart()
    {
        ScriptableObjectUtility.CreateAsset<TrainerLevelChart>();
    }
}