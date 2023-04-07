using System;

public class DamageToTarget : DamageComponent
{
    public override void GiveMagicDamage(SpellData spellData, BaseCharacter target)
    {
        target.GetDamage(spellData.spellDamage);
    }
    
    public override void GiveMagicDamage(SpellData spellData, BaseCharacter target, Action callback)
    {
        target.GetDamage(spellData.spellDamage);
        callback();
    }
}
