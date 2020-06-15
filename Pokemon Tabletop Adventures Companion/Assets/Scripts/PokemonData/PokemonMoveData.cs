using UnityEngine;

public class PokemonMoveData : ScriptableObject
{
    public string MoveName;
    public PokemonType MoveType;
    public MoveFrequencies Frequency;
    public string AccuracyCheck;
    public string Range;
    public string DamageDiceRoll;
    public string AoE;
    public string Effect;
    public ContestTypes ContestType;
}