using System;
using UnityEngine;

public class MoveInArc : MovementComponents
{
    [SerializeField][Range(0, 1)] private float arcHeight;
    private float _stepScale;
    private float _progress;
    
    /*private Vector3 _targetPosition;*/
    private Action _moveCallback;
    private BaseCharacter _currentTarget;

    private void Start()
    {
        var distance = Vector3.Distance(transform.position, _currentTarget.transform.position);
        arcHeight *= distance;
        _stepScale = speed / distance;
    }

    public override void OnTick()
    {
        Move(_currentTarget.transform.position, _moveCallback);
    }

    public override void InvokeMove(BaseCharacter target, Action callback)
    {
        this._moveCallback = callback;
        this._currentTarget = target;
    }

    public override void Move(Vector3 target, Action callback)
    {
        _progress = Mathf.Min(_progress + Time.deltaTime * _stepScale, 1f);
		
        var parabola = 1f - 4f * (_progress - 0.5f) * (_progress - 0.5f);
        var nextPos = Vector3.Lerp(transform.position, target, _progress);
        nextPos.y += parabola * arcHeight;
        
        transform.position = nextPos;
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
