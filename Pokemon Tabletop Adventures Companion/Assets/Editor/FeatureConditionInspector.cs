using System.Collections.Generic;
using System.Linq;
using UnityEditor;

[CustomEditor(typeof(FeatureCondition))]
public class FeatureConditionInspector : Editor
{
    private FeatureCondition featureCondition;
    private FeatureClasses selectedFeatureClass;
    private int selectedFeatureID;

    private List<string> selectedFeatureNames;

    private void OnEnable()
    {
        featureCondition = target as FeatureCondition;

        InitializeFeatureIDSelection();
    }

    private void InitializeFeatureIDSelection()
    {
        selectedFeatureClass = featureCondition.FeatureClass;

        var classFeatures = FeatureCollection.GetClassFeatures(selectedFeatureClass);

        selectedFeatureNames = classFeatures.Values.ToList();
        var currentSelectedFeatureID = classFeatures[featureCondition.FeatureID];
        selectedFeatureID = selectedFeatureNames.IndexOf(currentSelectedFeatureID);
    }

    public override void OnInspectorGUI()
    {
        if (featureCondition == null)
            return;

        base.OnInspectorGUI();
        OnDrawSelectFeatureID();
    }

    private void OnDrawSelectFeatureID()
    {
        var oldSelected = selectedFeatureClass;

        selectedFeatureClass = (FeatureClasses)EditorGUILayout.EnumPopup("Feature Class", selectedFeatureClass);

        if (oldSelected != selectedFeatureClass)
        {
            var classFeatures = FeatureCollection.GetClassFeatures(selectedFeatureClass);
            selectedFeatureNames = classFeatures.Values.ToList();
        }

        int oldFeatureID = selectedFeatureID;
        selectedFeatureID = EditorGUILayout.Popup("Feature Name", selectedFeatureID, selectedFeatureNames.ToArray());

        if (oldFeatureID != selectedFeatureID)
        {
            var featureName = selectedFeatureNames[selectedFeatureID];
            var classFeatures = FeatureCollection.GetClassFeatures(selectedFeatureClass);
            featureCondition.FeatureID = classFeatures.FirstOrDefault(x => x.Value == featureName).Key;
            EditorUtility.SetDirty(featureCondition);
        }
    }
}