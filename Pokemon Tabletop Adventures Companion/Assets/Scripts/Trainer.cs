using System.Collections.Generic;
using UnityEngine;

public class Trainer : MonoBehaviour
{
    [Header("Stats")]
    public int Level;
    public int HP;
    public int ATK;
    public int DEF;
    public int SATK;
    public int SDEF;
    public int SPD;

    [Header("Achievements")]
    public int Badges;
    public int Medals;
    public int ContestRibbons;

    [Header("Features")]
    public List<Feature> UnlockedFeatures;

    public int Health { get { return (HP * 4) + (Level * 4); } }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
