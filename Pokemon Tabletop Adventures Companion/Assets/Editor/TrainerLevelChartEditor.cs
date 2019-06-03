using UnityEditor;

public class TrainerLevelChartEditor : Editor
{
    [MenuItem("Assets/Create/LevelChart")]
    static void CreateLevelChart()
    {
        ScriptableObjectUtility.CreateAsset<TrainerLevelChart>();
    }
}