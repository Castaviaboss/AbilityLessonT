using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public abstract class BaseSpell : MonoCache
{ 
    public SpellData spellData;
    /*public MovementComponents movementComponent;
    public DamageComponent damageComponent;*/
    //Либо добавлять компоненты в скрипте самого заклинания, либо думать что-то ещё.
    /*private float elapsedLifetime = 0f;*/
    
    public abstract void Cast(BaseCharacter caster);

    protected virtual Task CastAsync()
    {
        return null;
    }
    //test
    
    protected virtual void CreateSpellFromPrefab(BaseCharacter caster)
    {
        
    }
    

    /*public void StartLifetime()
    {
        elapsedLifetime += Time.deltaTime;
        if (!(elapsedLifetime >= spellData.spellLifetime)) return;
        
        elapsedLifetime = 0;
        gameObject.SetActive(false);
    }
    
    public override void OnTick()
    {
        StartLifetime();
    }*/ 
}

