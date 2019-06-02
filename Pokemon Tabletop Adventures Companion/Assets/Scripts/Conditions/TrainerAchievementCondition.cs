using System;

[Serializable]
public class TrainerAchievementCondition : Condition
{
    public Achievements DesiredAchievementType;
    public int DesiredAchievementAmount;

    public override bool TrainerMeetsCondition(Trainer trainer)
    {
        int amount = 0;
        switch (DesiredAchievementType)
        {
            case Achievements.Badges:
                amount = trainer.Badges;
                break;
            case Achievements.Medals:
                amount = trainer.Medals;
                break;
            case Achievements.ContestRibbons:
                amount = trainer.ContestRibbons;
                break;
            default:
                break;
        }
        return amount >= DesiredAchievementAmount;
    }
}