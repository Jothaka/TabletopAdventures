using UnityEngine;
using UnityEditor;

public class FeatureAsset : ScriptableObject
{
    [MenuItem("Assets/Create/Feature")]
    static void CreateAsset()
    {
        ScriptableObjectUtility.CreateAsset<Feature>();
    }
}