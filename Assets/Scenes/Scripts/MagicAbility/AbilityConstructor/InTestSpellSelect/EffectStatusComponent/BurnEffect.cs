

using UnityEngine;

public class BurnEffect : BaseEffect
{
    public float effectElapsedTime = 0f;
    public override void ApplyEffect()
    {
        Burning(effectData);
    }

    private void Burning(EffectData data)
    {
        effectElapsedTime += Time.deltaTime;
        
    }
}
