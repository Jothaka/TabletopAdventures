using System;

[Serializable]
public class TrainerStatCondition : Condition
{
    public Stats DesiredStatType;
    public int DesiredStatValue;

    public override bool TrainerMeetsCondition(Trainer trainer)
    {
        int statValue = 0;
        switch (DesiredStatType)
        {
            case Stats.Level:
                statValue = trainer.Level;
                break;
            case Stats.HP:
                statValue = trainer.TrainerStats.HP;
                break;
            case Stats.ATK:
                statValue = trainer.TrainerStats.ATK;
                break;
            case Stats.DEF:
                statValue = trainer.TrainerStats.DEF;
                break;
            case Stats.SATK:
                statValue = trainer.TrainerStats.SATK;
                break;
            case Stats.SDEF:
                statValue = trainer.TrainerStats.SDEF;
                break;
            case Stats.SPD:
                statValue = trainer.TrainerStats.SPD;
                break;
            default:
                break;
        }

        return statValue >= DesiredStatValue;
    }
}