using UnityEngine;
using UnityEngine.Serialization;

/*public class MoveInArcToTarget : MovementComponents
{
	[SerializeField] private float speed;
	[SerializeField][Range(0, 1)] private float arcHeight;
	
	private Vector3 _target;
	private Vector3 _startPosition;
	private float _stepScale;
	private float _progress;
	/*[SerializeField] private GetClosetCharacters getClosetCharactersTarget;#1#
	
	void Start()
	{
		/*getClosetCharactersTarget = GetComponent<GetClosetCharacters>();
		target = getClosetCharactersTarget.GetCloseCharacter().transform.position;#1#
		
		_startPosition = transform.position;

		var distance = Vector3.Distance(_startPosition, _target);
		arcHeight *= distance;
		_stepScale = speed / distance;
	}

	/*void Update()
	{
		MoveInArc();
	}#1#

	public void MoveInArc(Vector3 target)
	{
		_progress = Mathf.Min(_progress + Time.deltaTime * _stepScale, 1f);
		
		var parabola = 1f - 4f * (_progress - 0.5f) * (_progress - 0.5f);
		var nextPos = Vector3.Lerp(_startPosition, target, _progress);
		nextPos.y += parabola * arcHeight;
		
		/*transform.LookAt(nextPos, transform.forward);#1#
		transform.position = nextPos;
		
		if(_progress == 1f)
			Arrived();
	}
	
	/*[SerializeField] private float moveSpeed = 15f;
	[SerializeField] private float arcHeight = 1f;

	private GetCloset _getClosestTarget;
	
	private Vector3 _endPositionTarget;
	private Vector3 _startPosition;
	
	void Start()
	{
		_getClosestTarget.GetComponent<GetCloset>();
		
		_endPositionTarget = _getClosestTarget.GetCloseCharacter().transform.position;
		_startPosition = transform.position;
	}
	
	private void Update()
	{
		MoveInArc();
	}#1#


	/*private void MoveInArc()
	{
		float x0 = startPos.x;
		float x1 = closestForSpell.x;
		float dist = x1 - x0;
		float nextX = Mathf.MoveTowards(transform.position.x, x1, speed * Time.deltaTime);
		float baseY = Mathf.Lerp(startPos.y, closestForSpell.y, (nextX - x0) / dist);
		float arc = arcHeight * (nextX - x0) * (nextX - x1) / (-0.25f * dist * dist);
		var nextPos = new Vector3(nextX, baseY + arc, transform.position.z);

		transform.position = nextPos;
		
		if (nextPos == closestForSpell) Arrived();
	}#1#
	/*private void MoveInArc()
	{
		float distance = _endPositionTarget.x - _startPosition.x;
		float nextStepX = Mathf.MoveTowards(transform.position.x, _endPositionTarget.x, moveSpeed * Time.deltaTime);
		float baseY = Mathf.Lerp(_startPosition.y, _endPositionTarget.y, (nextStepX - _startPosition.x) / distance);
		float arc = arcHeight * (nextStepX - _startPosition.x) * (nextStepX - _endPositionTarget.x) / (-0.25f * distance * distance);
		var nextPosition = new Vector3(nextStepX, baseY + arc, transform.position.z);

		transform.position = nextPosition;
		
		if(nextPosition == _endPositionTarget) Arrived();
	}#1#
	private void Arrived()
	{
		
	}
}*/
