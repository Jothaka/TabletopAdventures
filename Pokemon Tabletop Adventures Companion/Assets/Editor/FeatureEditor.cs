using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

[CustomEditor(typeof(Feature))]
public class FeatureEditor : Editor
{
    private Feature feature;

    #region SelectFeatureID
    private FeatureClasses selectedFeatureClass;
    private int selectedFeatureID;

    private List<string> selectedFeatureNames;
    #endregion

    private ReorderableList reorderableConditionList;

    private void OnEnable()
    {
        feature = target as Feature;
        InitializeFeatureIDSelection();
        InitializeFeatureConditions();
    }

    private void InitializeFeatureIDSelection()
    {
        selectedFeatureClass = feature.FeatureClass;

        var classFeatures = FeatureCollection.GetClassFeatures(selectedFeatureClass);

        selectedFeatureNames = classFeatures.Values.ToList();
        var currentSelectedFeatureID = classFeatures[feature.FeatureID];
        selectedFeatureID = selectedFeatureNames.IndexOf(currentSelectedFeatureID);
    }

    private void InitializeFeatureConditions()
    {
        reorderableConditionList = new ReorderableList(feature.FeatureConditions, typeof(Condition));

        reorderableConditionList.drawHeaderCallback = (Rect rect) => { EditorGUI.LabelField(rect, "Conditions"); };
        reorderableConditionList.onAddDropdownCallback = AddDropDown;
        reorderableConditionList.drawElementCallback = DrawElement;
        reorderableConditionList.onRemoveCallback = RemoveElement;
    }

    public override void OnInspectorGUI()
    {
        if (feature == null)
            return;

        base.OnInspectorGUI();
        OnDrawSelectFeatureID();
        OnDrawFeatureConditions();
    }

    private void OnDrawSelectFeatureID()
    {
        FeatureClasses oldSelected = selectedFeatureClass;

        selectedFeatureClass = (FeatureClasses)EditorGUILayout.EnumPopup("Feature Class", selectedFeatureClass);

        if (oldSelected != selectedFeatureClass)
        {
            var classFeatures = FeatureCollection.GetClassFeatures(selectedFeatureClass);
            selectedFeatureNames = classFeatures.Values.ToList();
            feature.FeatureClass = selectedFeatureClass;
            EditorUtility.SetDirty(feature);
        }

        int oldFeatureID = selectedFeatureID;
        selectedFeatureID = EditorGUILayout.Popup("Feature Name", selectedFeatureID, selectedFeatureNames.ToArray());

        if (oldFeatureID != selectedFeatureID)
        {
            var featureName = selectedFeatureNames[selectedFeatureID];
            var classFeatures = FeatureCollection.GetClassFeatures(selectedFeatureClass);
            feature.FeatureID = classFeatures.FirstOrDefault(x => x.Value == featureName).Key;
            EditorUtility.SetDirty(feature);
        }

        var oldTiming = feature.FeatureTiming;

        feature.FeatureTiming = (FeatureTiming)EditorGUILayout.EnumPopup("Feature Timing", feature.FeatureTiming);
        if (feature.FeatureTiming != oldTiming)
            EditorUtility.SetDirty(feature);
    }

    private void OnDrawFeatureConditions()
    {
        if (reorderableConditionList == null)
            return;

        if (reorderableConditionList.list == null)
            return;

        reorderableConditionList.DoLayoutList();
        DrawSelectedCondition();
    }

    #region FeatureConditions
    private void AddDropDown(Rect buttonRect, ReorderableList list)
    {
        GenericMenu menu = new GenericMenu();

        List<Type> conditions = typeof(Condition).Assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(Condition))).ToList();

        for (int i = 0; i < conditions.Count; i++)
        {
            var condition = conditions[i];
            var displayName = condition.Name;

            menu.AddItem(new GUIContent(displayName), false, AddItemClickHandler, condition);
        }
        menu.ShowAsContext();
    }

    private void AddItemClickHandler(object selectedType)
    {
        Type conditionType = selectedType as Type;
        if (conditionType != null)
        {
            Condition newCondition = ScriptableObjectUtility.CreateAssetInSubfolder(selectedFeatureNames[selectedFeatureID] + "_Conditions", conditionType, feature.FeatureConditions.Count) as Condition;

            if (newCondition != null)
            {
                int id = reorderableConditionList.list.Add(newCondition);
                reorderableConditionList.index = id;
                EditorUtility.SetDirty(feature);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
        }
    }

    private void DrawElement(Rect rect, int index, bool isActive, bool isFocused)
    {
        Condition targetCondition = feature.FeatureConditions[index];
        if (targetCondition != null)
            EditorGUI.LabelField(rect, targetCondition.GetType().Name);
    }

    private void RemoveElement(ReorderableList list)
    {
        var conditionToDelete = feature.FeatureConditions[list.index];
        DestroyImmediate(conditionToDelete, true);
        list.list.RemoveAt(list.index);
        EditorUtility.SetDirty(feature);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    private void DrawSelectedCondition()
    {
        if (reorderableConditionList.index >= 0 && reorderableConditionList.index < feature.FeatureConditions.Count)
        {
            Condition condition = reorderableConditionList.list[reorderableConditionList.index] as Condition;
            if (condition == null)
                feature.FeatureConditions.RemoveAt(reorderableConditionList.index);

            Editor conditionEditor = CreateEditor(condition);
            conditionEditor.OnInspectorGUI();
        }
        else
        {
            EditorGUILayout.LabelField("Select a condition in the above list to edit its properties.");
        }
    }
    #endregion
}