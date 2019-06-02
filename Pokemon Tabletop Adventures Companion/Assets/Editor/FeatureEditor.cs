using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

[CustomEditor(typeof(Feature))]
public class FeatureEditor : Editor
{
    private Feature feature;

    #region SelectFeatureID
    private Type[] featureCollections;
    private string[] featureCollectionNames;

    private FeatureClasses selectedFeatureClass;
    private int selectedFeatureID;

    private List<FieldInfo> selectedConstants;
    private string[] selectedConstantNames;
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
        featureCollections = ReflectionUtility.GetAllSubTypes(typeof(FeatureCollection));
        featureCollectionNames = ReflectionUtility.GetTypeNames(featureCollections);
        selectedFeatureClass = feature.FeatureClass;

        selectedConstants = ReflectionUtility.GetConstants(FeatureCollection.FeatureClassToCollectionType(selectedFeatureClass));
        selectedConstantNames = ReflectionUtility.GetFieldNames(selectedConstants);
        var constantValues = ReflectionUtility.GetFieldConstantValues<int>(selectedConstants);
        selectedFeatureID = constantValues.IndexOf(feature.FeatureID);
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
        feature.FeatureTiming = (FeatureTiming)EditorGUILayout.EnumPopup("Feature Timing", feature.FeatureTiming);
        OnDrawFeatureConditions();
    }

    private void OnDrawSelectFeatureID()
    {
        FeatureClasses oldSelected = selectedFeatureClass;

        selectedFeatureClass = (FeatureClasses)EditorGUILayout.EnumPopup("Feature Class", selectedFeatureClass); //EditorGUILayout.Popup("Feature Class", selectedFeatureClass, featureCollectionNames);

        if (oldSelected != selectedFeatureClass)
        {
            selectedConstants = ReflectionUtility.GetConstants(FeatureCollection.FeatureClassToCollectionType(selectedFeatureClass));
            selectedConstantNames = ReflectionUtility.GetFieldNames(selectedConstants);
            feature.FeatureClass = selectedFeatureClass;
        }

        int oldFeatureID = selectedFeatureID;
        selectedFeatureID = EditorGUILayout.Popup("Feature Name", selectedFeatureID, selectedConstantNames);

        if (oldFeatureID != selectedFeatureID)
            feature.FeatureID = ReflectionUtility.GetConstantValue<int>(selectedConstants[selectedFeatureID]);
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
            Condition newCondition = ScriptableObjectUtility.CreateAssetInSubfolder(selectedConstantNames[selectedFeatureID] + "_Conditions", conditionType, feature.FeatureConditions.Count) as Condition;

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