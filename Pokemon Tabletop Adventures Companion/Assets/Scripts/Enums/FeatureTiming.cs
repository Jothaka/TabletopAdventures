using System;

#pragma warning disable CS0612 

//marking base enum values obsolete to make them unselectable in UnityEditor
[Flags]
public enum FeatureTiming
{
    [Obsolete]
    Legal = 1,
    [Obsolete]
    Illegal = 2,
    [Obsolete]
    Static = 4,
    [Obsolete]
    Free = 8,
    [Obsolete]
    Trainer = 16,
    [Obsolete]
    Interrupt = 32,
    [Obsolete]
    Extended = 64,
    LegalStatic = Legal | Static,
    IllegalStatic = Illegal | Static,
    LegalFree = Legal | Free,
    IllegalFree = Illegal | Free,
    LegalTrainer = Legal | Trainer,
    IllegalTrainer = Illegal | Trainer,
    LegalInterrupt = Legal | Interrupt,
    IllegalInterrupt = Illegal | Interrupt,
    LegalExtended = Legal | Extended,
    IllegalExtended = Illegal | Extended
}
#pragma warning restore CS0612
