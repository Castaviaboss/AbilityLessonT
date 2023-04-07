
using System;
using System.Collections.Generic;

public class DamageComponent : BaseComponent
{
    public virtual void GiveMagicDamage(SpellData spellData, BaseCharacter target) {}
    public virtual void GiveMagicDamage(SpellData spellData, BaseCharacter target, Action callback) {}
    

    public virtual void GiveMagicDamageForTargets(SpellData spellData, List<BaseCharacter> targets) {}
    public virtual void GiveMagicDamageForTargets(SpellData spellData, List<BaseCharacter> targets, Action callback) {}
}
