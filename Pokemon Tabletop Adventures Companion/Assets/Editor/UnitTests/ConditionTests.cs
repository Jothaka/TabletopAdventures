using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class ConditionTests
    {
        [Test]
        public void FeatureAmount_Test()
        {
            var go = new GameObject("TestObject");
            var trainer = go.AddComponent<Trainer>();
            trainer.SetMockupFeatures();

            var aceAmountCondition = ScriptableObject.CreateInstance<FeatureAmountCondition>();
            aceAmountCondition.FeatureClass = FeatureClasses.Ace;
            aceAmountCondition.DesiredFeatureAmount = 2;

            Assert.That(aceAmountCondition.TrainerMeetsCondition(trainer), Is.True);

            aceAmountCondition.DesiredFeatureAmount = 3;

            Assert.That(aceAmountCondition.TrainerMeetsCondition(trainer), Is.False);
        }

        [Test]
        public void Feature_Test()
        {
            var go = new GameObject("TestObject");
            var trainer = go.AddComponent<Trainer>();
            trainer.SetMockupFeatures();

            var pokedexCondition = ScriptableObject.CreateInstance<FeatureCondition>();
            pokedexCondition.FeatureID = 0; // Use Pokedex
            Assert.That(pokedexCondition.TrainerMeetsCondition(trainer), Is.True);

            var chaserCondition = ScriptableObject.CreateInstance<FeatureCondition>();
            chaserCondition.FeatureID = 115; // Chaser
            Assert.That(chaserCondition.TrainerMeetsCondition(trainer), Is.False);
        }

        [Test]
        public void Or_Test()
        {
            var go = new GameObject("TestObject");
            var trainer = go.AddComponent<Trainer>();
            trainer.SetMockupStats();
            trainer.SetMockupFeatures();

            var pokedexCondition = ScriptableObject.CreateInstance<FeatureCondition>();
            pokedexCondition.FeatureID = 0; // Use Pokedex

            var badgeCondition = ScriptableObject.CreateInstance<TrainerAchievementCondition>();
            badgeCondition.DesiredAchievementType = Achievements.Badges;
            badgeCondition.DesiredAchievementAmount = 2;

            var atkCondition = ScriptableObject.CreateInstance<TrainerStatCondition>();
            atkCondition.DesiredStatType = Stats.ATK;
            atkCondition.DesiredStatValue = 12;

            var aceAmountCondition = ScriptableObject.CreateInstance<FeatureAmountCondition>();
            aceAmountCondition.FeatureClass = FeatureClasses.Ace;
            aceAmountCondition.DesiredFeatureAmount = 2;

            var orCondition = ScriptableObject.CreateInstance<OrCondition>();
            orCondition.ConditionsToCheck.Add(badgeCondition);
            orCondition.ConditionsToCheck.Add(atkCondition);
            Assert.That(orCondition.TrainerMeetsCondition(trainer), Is.False);

            orCondition.ConditionsToCheck.Add(pokedexCondition);
            orCondition.ConditionsToCheck.Add(aceAmountCondition);
            Assert.That(orCondition.TrainerMeetsCondition(trainer), Is.True);
        }

        [Test]
        public void TrainerAchievement_Test()
        {
            var go = new GameObject("TestObject");
            var trainer = go.AddComponent<Trainer>();
            trainer.SetMockupStats();
            trainer.Badges = 3;

            var badgeCondition = ScriptableObject.CreateInstance<TrainerAchievementCondition>();
            badgeCondition.DesiredAchievementType = Achievements.Badges;
            badgeCondition.DesiredAchievementAmount = 2;
            Assert.That(badgeCondition.TrainerMeetsCondition(trainer), Is.True);

            var medalCondition = ScriptableObject.CreateInstance<TrainerAchievementCondition>();
            medalCondition.DesiredAchievementType = Achievements.Medals;
            medalCondition.DesiredAchievementAmount = 1;
            Assert.That(medalCondition.TrainerMeetsCondition(trainer), Is.False);
        }

        [Test]
        public void TrainerStat_Test()
        {
            var go = new GameObject("TestObject");
            var trainer = go.AddComponent<Trainer>();
            trainer.SetMockupStats();

            var atkCondition = ScriptableObject.CreateInstance<TrainerStatCondition>();
            atkCondition.DesiredStatType = Stats.ATK;
            atkCondition.DesiredStatValue = 12;
            Assert.That(atkCondition.TrainerMeetsCondition(trainer), Is.False);

            var defCondition = ScriptableObject.CreateInstance<TrainerStatCondition>();
            defCondition.DesiredStatType = Stats.DEF;
            defCondition.DesiredStatValue = 11;
            Assert.That(defCondition.TrainerMeetsCondition(trainer), Is.True);
        }
    }
}
