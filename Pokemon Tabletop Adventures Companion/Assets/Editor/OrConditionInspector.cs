using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Collections.Generic;
using System;
using System.Linq;

[CustomEditor(typeof(OrCondition))]
public class OrConditionInspector : Editor
{
    private OrCondition orCondition;
    private ReorderableList reorderableConditionList;

    private void OnEnable()
    {
        orCondition = target as OrCondition;
        InitializeFeatureConditions();
    }

    private void InitializeFeatureConditions()
    {
        reorderableConditionList = new ReorderableList(orCondition.ConditionsToCheck, typeof(Condition));

        reorderableConditionList.drawHeaderCallback = (Rect rect) => { EditorGUI.LabelField(rect, "Conditions"); };
        reorderableConditionList.onAddDropdownCallback = AddDropDown;
        reorderableConditionList.drawElementCallback = DrawElement;
        reorderableConditionList.onRemoveCallback = RemoveElement;
    }

    public override void OnInspectorGUI()
    {
        if (reorderableConditionList == null)
            return;

        if (reorderableConditionList.list == null)
            return;

        reorderableConditionList.DoLayoutList();
        DrawSelectedCondition();
    }

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
            string conditionPath = AssetDatabase.GetAssetPath(this);
            Condition newCondition = ScriptableObjectUtility.CreateAssetInSubfolder(conditionPath + "_Conditions", conditionType, orCondition.ConditionsToCheck.Count) as Condition;

            if (newCondition != null)
            {
                int id = reorderableConditionList.list.Add(newCondition);
                reorderableConditionList.index = id;
                EditorUtility.SetDirty(orCondition);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
        }
    }

    private void DrawElement(Rect rect, int index, bool isActive, bool isFocused)
    {
        Condition targetCondition = orCondition.ConditionsToCheck[index];
        if (targetCondition != null)
            EditorGUI.LabelField(rect, targetCondition.GetType().Name);
    }

    private void RemoveElement(ReorderableList list)
    {
        var conditionToDelete = orCondition.ConditionsToCheck[list.index];
        DestroyImmediate(conditionToDelete, true);
        list.list.RemoveAt(list.index);
        EditorUtility.SetDirty(orCondition);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    private void DrawSelectedCondition()
    {
        if (reorderableConditionList.index >= 0 && reorderableConditionList.index < orCondition.ConditionsToCheck.Count)
        {
            Condition condition = reorderableConditionList.list[reorderableConditionList.index] as Condition;
            if (condition == null)
                orCondition.ConditionsToCheck.RemoveAt(reorderableConditionList.index);

            Editor conditionEditor = CreateEditor(condition);
            conditionEditor.OnInspectorGUI();
        }
        else
        {
            EditorGUILayout.LabelField("Select a condition in the above list to edit its properties.");
        }
    }
}