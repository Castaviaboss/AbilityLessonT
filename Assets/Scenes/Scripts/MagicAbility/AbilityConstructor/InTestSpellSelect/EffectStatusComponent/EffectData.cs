using UnityEngine;

[CreateAssetMenu(menuName = "Create EffectData", fileName = "EffectData")]
public class EffectData : ScriptableObject
{
    public float effectLifetime;
    public int effectDamage;
    public float effectDelay;
    public float effectPerTiming;
}
