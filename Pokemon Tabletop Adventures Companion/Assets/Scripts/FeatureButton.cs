using System;
using UnityEngine;
using UnityEngine.UI;

public class FeatureButton : MonoBehaviour
{
    public event Action<string> OnFeatureSelected;

    public Feature AssignedFeature;

    [Header("Local References")]
    public Text FeatureName;
    public Text FeatureClassName;

    private void Start()
    {
        FeatureClassName.text = AssignedFeature.FeatureClass.ToString();
        var features = FeatureCollection.GetClassFeatures(AssignedFeature.FeatureClass);
        FeatureName.text = features[AssignedFeature.FeatureID];
    }

    public void InvokeFeatureSelected()
    {
        OnFeatureSelected?.Invoke(AssignedFeature.FeatureEffect);
    }
}