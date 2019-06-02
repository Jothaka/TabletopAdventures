using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;

[CustomEditor(typeof(FeatureCondition))]
public class FeatureConditionInspector : Editor
{
    private FeatureCondition featureCondition;
    private Type[] featureCollections;
    private string[] featureCollectionNames;
    private int selectedFeatureCollection;
    private List<FieldInfo> selectedConstants;
    private string[] selectedConstantNames;
    private int selectedFeatureID;

    private void OnEnable()
    {
        featureCondition = target as FeatureCondition;

        InitializeFeatureIDSelection();
    }

    private void InitializeFeatureIDSelection()
    {
        featureCollections = ReflectionUtility.GetAllSubTypes(typeof(FeatureCollection));
        featureCollectionNames = ReflectionUtility.GetTypeNames(featureCollections);
        selectedFeatureCollection = featureCondition.SelectedFeatureCollection;

        selectedConstants = ReflectionUtility.GetConstants(featureCollections[selectedFeatureCollection]);
        selectedConstantNames = ReflectionUtility.GetFieldNames(selectedConstants);
        var constantValues = ReflectionUtility.GetFieldConstantValues<int>(selectedConstants);
        selectedFeatureID = constantValues.IndexOf(featureCondition.FeatureID);
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
        int oldSelected = selectedFeatureCollection;

        selectedFeatureCollection = EditorGUILayout.Popup("Feature Type", selectedFeatureCollection, featureCollectionNames);

        if (oldSelected != selectedFeatureCollection)
        {
            selectedConstants = ReflectionUtility.GetConstants(featureCollections[selectedFeatureCollection]);
            selectedConstantNames = ReflectionUtility.GetFieldNames(selectedConstants);
        }

        int oldFeatureID = selectedFeatureID;
        selectedFeatureID = EditorGUILayout.Popup("Feature Name", selectedFeatureID, selectedConstantNames);

        if (oldFeatureID != selectedFeatureID)
            featureCondition.FeatureID = ReflectionUtility.GetConstantValue<int>(selectedConstants[selectedFeatureID]);
    }
}