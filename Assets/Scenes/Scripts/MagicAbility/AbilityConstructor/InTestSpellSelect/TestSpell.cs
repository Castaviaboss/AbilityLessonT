using System.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;

public class TestSpell : BaseSpell
{
    [SerializeField] private SelectForSpell selectComponent;
    [SerializeField] private DamageComponent damageComponent;
    [SerializeField] private ParticleComponent particleComponent;
    public override void Cast(BaseCharacter caster)
    {
        CastAsync();
    }
    
    protected override async Task CastAsync()
    {
        var a = await selectComponent.WaitForClickToEnemyAsync();
        /*var b = CreateSpellFromPrefabInTarget(this, a);*/
        damageComponent.GiveMagicDamage(spellData, a, () =>
        {
            particleComponent.InvokeParticle(a.transform.position);
            /*Destroy(b.gameObject);*/
        });
    }

    protected override void CreateSpellFromPrefab(BaseCharacter caster)
    {
        
    }

    public TestSpell CreateSpellFromPrefabInTarget(TestSpell spell, BaseCharacter target)
    {
        var spellPrefab = Instantiate(spell.gameObject, target.transform.position, quaternion.identity).GetComponent<TestSpell>();
        return spellPrefab;
    }
}
