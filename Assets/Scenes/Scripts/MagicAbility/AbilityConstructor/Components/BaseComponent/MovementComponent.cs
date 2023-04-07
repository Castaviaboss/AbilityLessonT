using System;
using UnityEngine;

public class MovementComponents : BaseComponent
{
    [SerializeField] protected float speed;

    public virtual void Move() {}
    public virtual void Move(Vector3 target) {}
    public virtual void Move(Vector3 target, Action callback) {}


    public virtual void InvokeMove() {}
    public virtual void InvokeMove(BaseCharacter target) {}
    public virtual void InvokeMove(BaseCharacter target, Action callback) {}
    

    protected virtual void Arrived() {}
    
}
