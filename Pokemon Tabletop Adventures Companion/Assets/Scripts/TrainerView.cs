using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainerView : MonoBehaviour
{
    public Trainer TrainerModell;

    [Header("Stat references")]
    public Text Level;
    public Text HP;
    public Text ATK;
    public Text DEF;
    public Text SATK;
    public Text SDEF;
    public Text SPD;

    public Button[] StatButtons;

    [Header("Indirect Stats references")]
    public Text AvailableStatPoints;
    public Text ModifierHP;
    public Text ModifierATK;
    public Text ModifierDEF;
    public Text ModifierSATK;
    public Text ModifierSDEF;
    public Text ModifierSPD;

    [Header("Feature Display references")]
    public Text FeatureEffectContent;
    public List<FeatureButton> FeatureButtons;

    private void Start()
    {
        //DEBUG ONLY!
        foreach (var button in FeatureButtons)
            button.OnFeatureSelected += OnFeatureSelected;
        //
    }

    private void OnFeatureSelected(string obj)
    {
        FeatureEffectContent.text = obj;
    }

    public void ToggleButtons(bool active)
    {
        for (int i = 0; i < StatButtons.Length; i++)
            StatButtons[i].interactable = active;
    }

    public void UpdateStatFields()
    {
        Level.text = TrainerModell.Level.ToString();
        HP.text = TrainerModell.HP.ToString();
        ATK.text = TrainerModell.ATK.ToString();
        DEF.text = TrainerModell.DEF.ToString();
        SATK.text = TrainerModell.SATK.ToString();
        SDEF.text = TrainerModell.SDEF.ToString();
        SPD.text = TrainerModell.SPD.ToString();
        AvailableStatPoints.text = TrainerModell.AvailableStatPoints.ToString();
    }

    public void UpdateModifier(Stats stat, string newModifier)
    {
        switch (stat)
        {
            case Stats.HP:
                ModifierHP.text = newModifier;
                break;
            case Stats.ATK:
                ModifierATK.text = newModifier;
                break;
            case Stats.DEF:
                ModifierDEF.text = newModifier;
                break;
            case Stats.SATK:
                ModifierSATK.text = newModifier;
                break;
            case Stats.SDEF:
                ModifierSDEF.text = newModifier;
                break;
            case Stats.SPD:
                ModifierSPD.text = newModifier;
                break;
            default:
                break;
        }
    }
}