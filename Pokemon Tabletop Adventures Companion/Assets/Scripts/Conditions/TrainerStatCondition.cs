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
                statValue = trainer.HP;
                break;
            case Stats.ATK:
                statValue = trainer.ATK;
                break;
            case Stats.DEF:
                statValue = trainer.DEF;
                break;
            case Stats.SATK:
                statValue = trainer.SATK;
                break;
            case Stats.SDEF:
                statValue = trainer.SDEF;
                break;
            case Stats.SPD:
                statValue = trainer.SPD;
                break;
            default:
                break;
        }

        return statValue >= DesiredStatValue;
    }
}