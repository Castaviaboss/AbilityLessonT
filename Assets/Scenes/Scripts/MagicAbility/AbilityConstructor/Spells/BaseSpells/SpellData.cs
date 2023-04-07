using UnityEngine;

[CreateAssetMenu(menuName = "Create SpellData", fileName = "SpellData")]
public class SpellData : ScriptableObject
{
    public int spellDamage;
    public int spellCost;
    public float spellRechargeTime;
    public float spellLifetime;
    
    /*public int spellMaxTargetsCount;*/
}
