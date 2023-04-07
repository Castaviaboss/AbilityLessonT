using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public enum CharacterType
{
    Enemy = 0,
    Neutral = 1,
    Player = 2
}
public class BaseCharacter : MonoBehaviour
{
    [SerializeField] private CharacterType characterType;
    [SerializeField] protected int maximumHealth;
    [SerializeField] protected int maximumMana;
    [SerializeField] protected int health;
    [SerializeField] protected int mana;
    [SerializeField] protected int damage;
    [SerializeField] protected int magicDamage;
    [SerializeField] private FindClosetEnemy findClosetEnemy;
    [SerializeField] private EffectsController effectsController;
    
    public void SetEffect(BaseEffect effect) //
    {
        effectsController.AddEffect(effect);
    }
    
    public virtual void GetDamage(int incomingDamage)
    {
        health -= incomingDamage;

        if (health <= 0) 
            Die();
    }

    /*public virtual void DealDamage(int outgoingDamage)
    {
        
    }

    public virtual void DealMagicDamage(int outgoingDamage)
    {
        
    }

    public virtual void TakeMana(int quantity)
    {
        
    }*/

    public FindClosetEnemy Find()
    {
        return findClosetEnemy;
    }
    
    public CharacterType GetCharacterType()
    {
        return characterType;
    }

    protected virtual void Die()
    {
        gameObject.SetActive(false);
    }
}
