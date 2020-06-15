using UnityEngine;

public class TrainerModificationController : MonoBehaviour
{
    [Header("Scene references")]
    public Trainer Modell;
    public TrainerView View;
    [Header("Asset references")]
    public TrainerLevelChart LevelChart;

    public void InitializeViewWithModellData()
    {
        View.UpdateStatFields();
        for (int i = 1; i < 7; i++)
            SetModifier((Stats)i);
    }
   
    public void UpdateStatField(int statID)
    {
        Stats parsedStat = (Stats)statID;

        switch (parsedStat)
        {
            case Stats.Level:
                IncreaseLevel();
                if (Modell.AvailableStatPoints > 0)
                    View.ToggleButtons(true);
                break;
            case Stats.HP:
                Modell.TrainerStats.HP++;
                break;
            case Stats.ATK:
                Modell.TrainerStats.ATK++;
                break;
            case Stats.DEF:
                Modell.TrainerStats.DEF++;
                break;
            case Stats.SATK:
                Modell.TrainerStats.SATK++;
                break;
            case Stats.SDEF:
                Modell.TrainerStats.SDEF++;
                break;
            case Stats.SPD:
                Modell.TrainerStats.SPD++;
                break;
            default:
                break;
        }
        if (parsedStat != Stats.Level)
        {
            Modell.AvailableStatPoints--;
            SetModifier(parsedStat);
            if (Modell.AvailableStatPoints <= 0)
                View.ToggleButtons(false);
        }

        View.UpdateStatFields();
    }

    private void IncreaseLevel()
    {
        Modell.Level++;
        var levelData = LevelChart.GetPlayerLevelData(Modell.Level);
        Modell.AvailableFeaturePoints += levelData.FeatsGained;
        Modell.AvailableStatPoints += levelData.StatsGained;
    }


    private void SetModifier(Stats statType)
    {
        string newModifier = string.Empty;
        switch (statType)
        {
            case Stats.HP:
                newModifier = CalculateModifier(Modell.TrainerStats.HP);
                break;
            case Stats.ATK:
                newModifier = CalculateModifier(Modell.TrainerStats.ATK);
                break;
            case Stats.DEF:
                newModifier = CalculateModifier(Modell.TrainerStats.DEF);
                break;
            case Stats.SATK:
                newModifier = CalculateModifier(Modell.TrainerStats.SATK);
                break;
            case Stats.SDEF:
                newModifier = CalculateModifier(Modell.TrainerStats.SDEF);
                break;
            case Stats.SPD:
                newModifier = CalculateModifier(Modell.TrainerStats.SPD);
                break;
            default:
                break;
        }
        View.UpdateModifier(statType, newModifier);
    }

    private string CalculateModifier(int statValue)
    {
        float tempValue = statValue;
        tempValue -= 10;
        tempValue *= 0.5f;
        statValue = (int)tempValue;
        return statValue.ToString();
    }
}
