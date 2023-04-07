using Unity.Mathematics;
using UnityEngine;

public class SpellFireball : BaseSpell
{
    public MovementComponents movementComponent;
    public DamageComponent damageComponent;
    /*public BurnEffect burnEffect;*/

    public override void Cast(BaseCharacter caster)
    {
        var cachedTarget = caster.Find().FindClosestEnemy();
        
        if (cachedTarget != null)
        {
            var fireball = CreateSpellBaseSpell(this, caster.transform.position);
            
            fireball.movementComponent.InvokeMove(cachedTarget, () =>
            {
                damageComponent.GiveMagicDamage(spellData, cachedTarget, () =>
                {
                   /*cachedTarget.SetEffect(fireball.burnEffect);*/
                    /*ParticlesContainer.Instance.InvokeParticle(fireball.transform.position, 0);*/
                });
            });
        }
    } //work. Main

    
    /*[SerializeReference] public BaseComponent[] components; //test*/
    /*public void CastTestSerializeReference(BaseCharacter caster) //Запомнить и удалить к чертям
    {
        var cachedTarget = caster.Find().FindClosestEnemy();
        if (cachedTarget != null)
        {
            var fireball = CreateSpellBaseSpell(this, caster.transform.position);
            foreach (var component in fireball.components)
            {
                if (component != null)
                {
                    if (component is MovementComponents movementComponentsReference)
                    {
                        movementComponentsReference.InvokeMove(cachedTarget, () =>
                        {
                            if (component is DamageComponent damageComponentReference) //Эта часть не работает из-за того, что мы уже прошлись по всем компонентам и
                            {                                                          //на этом этапе мы просто не можем получить компонент урона и пройти проверку if
                                damageComponentReference.GiveMagicDamage(spellData, cachedTarget);
                            }
                        });
                    }
                }
            }
        }
    }*/
    
    /*public override void Cast(BaseCharacter caster) //multiple targets
    {
        /*var cachedTargets = caster.FindClosestEnemies(3);#1#
        var cachedTargets = caster.Find().FindClosestEnemies(spellData.maxTargetsCount);
        print(cachedTargets.Count);

        for (int i = 0; i < cachedTargets.Count; i++)
        {
            print(cachedTargets[i].transform.position);
            var a = CreateSpellBaseSpell(this);
            a.transform.position = caster.transform.position;
            a.movementComponent.MoveInvoke(cachedTargets[i].transform.position, null);
        }
    }*/

    /*public override void CreateSpellFromPrefab(BaseCharacter caster) //Change on pull
    {
        var spellPrefab = Instantiate(this.gameObject);
        spellPrefab.transform.position = caster.transform.position;
    }*/
    
    public SpellFireball CreateSpellBaseSpell(SpellFireball spell, Vector2 spawnPosition)
    {
        var spellPrefab = Instantiate(spell.gameObject, spawnPosition, quaternion.identity).GetComponent<SpellFireball>();
        return spellPrefab;
    } //новый уникальный префаб с уникальным компонентом. 
}
