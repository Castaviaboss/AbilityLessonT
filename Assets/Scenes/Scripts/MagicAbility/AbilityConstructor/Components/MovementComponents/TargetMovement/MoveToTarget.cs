using System;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MovementComponents
{

    private Action _moveCallback;
    private BaseCharacter _currentTarget;

    public override void OnTick()
    {
        Move(_currentTarget.transform.position, _moveCallback);
    } //MonoCache update
    
    public override void InvokeMove(BaseCharacter target, Action callback)
    {
        this._moveCallback = callback;
        this._currentTarget = target;
    }
    /*public override void MoveToCallbackTest(Vector3 target, Action callback)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, Speed * Time.deltaTime);
        
        if (transform.position == target)
        {
            if (transform.position == _currentTarget.transform.position)
            {
                print("complete");
                callback?.Invoke();
                Destroy(this.gameObject);
                return;
                
            }
            print("complete, but target is not arrived");
            Destroy(this.gameObject);
        }
    }*/
    
    public override void Move(Vector3 target, Action callback)
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        
    }

    protected override void Arrived()
    {
        _moveCallback.Invoke();
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag(_currentTarget.gameObject.tag))
        {
            Arrived();
        }
    }
}
