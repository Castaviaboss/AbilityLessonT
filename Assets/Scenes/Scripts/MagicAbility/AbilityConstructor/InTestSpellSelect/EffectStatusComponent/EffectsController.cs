
using System.Collections.Generic;
using UnityEngine;

public class EffectsController : MonoCache
{
    [SerializeField] private List<BaseEffect> activeEffects;
    /*private float elapsedLifetime = 0f;
    private float effectLifetime = 7f;
    
    public void StartLifetime(BaseEffect effect)
    {
        elapsedLifetime += Time.deltaTime;
        if (!(elapsedLifetime >= effectLifetime)) return;
        
        elapsedLifetime = 0;
        RemoveEffect(effect);
    }*/

    public override void OnTick()
    {
        if (activeEffects.Count == 0) return;

        for (int i = 0; i < activeEffects.Count; i++)
        {
            activeEffects[i].ApplyEffect();
            EffectAction(activeEffects[i].effectData, i);
        }
    }

    public void AddEffect(BaseEffect effect)
    {
        effect.GetComponent<BaseEffect>();
        activeEffects.Add(effect);
    }

    public void RemoveEffect(BaseEffect effect)
    {
        activeEffects.Remove(effect);
    }

    private void EffectAction(EffectData effectData, int counter)
    {
        
    }
}
