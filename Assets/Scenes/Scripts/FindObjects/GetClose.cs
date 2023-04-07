using System.Collections.Generic;
using UnityEngine;

public class GetClose : MonoBehaviour
{
    [SerializeField] private List<BaseCharacter> _characters = new List<BaseCharacter>();
    private BoxCollider2D _collider;
    private BaseCharacter _closetCharacter;

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out BaseCharacter character))
        {
            _characters.Add(character);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out BaseCharacter character))
        {
            _characters.Remove(character);
        }
    }

    public BaseCharacter GetCloseCharacter()
    {
        if (_characters.Count <= 0) return null;
        _closetCharacter = null;
        float closestDistance = float.PositiveInfinity;
        
        for (int i = 0; i < _characters.Count; i++)
        {
            var currentCharacter = _characters[i];
            if (currentCharacter == null)
            {
                _characters.RemoveAt(i);
                i--;
                continue;
            }
            var distance = Vector2.SqrMagnitude(transform.position - _characters[i].transform.position); //Разница с дистанс в точности (нет операции извлечения корня, которая дорогая)

            if (distance < closestDistance)
            {
                closestDistance = distance;
                _closetCharacter = currentCharacter;
            }
        }
        return _closetCharacter;
    }
    
    public T GetCloseCharacterT<T>() where T : BaseCharacter
    {
        if (_characters.Count <= 0) return null;
        _characters.RemoveAll(c => c == null);
        var closestCharacter = default(T);
        float closestDistance = float.PositiveInfinity;
        
        for (int i = 0; i < _characters.Count; i++)
        {
            var currentCharacter = _characters[i];
            var distance = (transform.position - _characters[i].transform.position).sqrMagnitude; //Разница с дистанс в точности (нет операции извлечения корня, которая дорогая)

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestCharacter = currentCharacter as T;
            }
        }
        return closestCharacter;
    }
    
    public List<BaseCharacter> GetClosestCharacters(int maxTargets)
    {
        if (_characters.Count <= 0) return null;
        
        List<BaseCharacter> characters = new List<BaseCharacter>();
        
        for (int i = 0; i < _characters.Count && i < maxTargets; i++)
        {
            if (_characters[i] == null) continue;

            characters.Add(_characters[i]);
        }
        return characters;
    }
    
    public List<BaseCharacter> GetSortedClosestCharacters(int maxTargets)
    {
        return null;
    }
    
    
    /*public BaseCharacter GetCloseCharacter()
    {
        if (_characters.Count <= 0) return null;
        _closetCharacters = null;
        float closestDistance = float.PositiveInfinity;
        
        for (int i = 0; i < _characters.Count; i++)
        {
            if (_characters[i] != null)
            {
                var distance = Vector2.SqrMagnitude(transform.position - _characters[i].transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    _closetCharacters = _characters[i];
                }
            }
            else
            {
                _characters.Remove(_characters[i]);
            }
        }
        return _closetCharacters == null ? null : _closetCharacters;
    }*/
    
    /*private BaseCharacter _closetCharacter;
    [SerializeField] private float distanceSearchingTarget;
    private readonly List<BaseCharacter> _characters = new List<BaseCharacter>();
    private void Start()
    {
        _characters.AddRange(CharactersContainer.Instance.characters);
    }

    public BaseCharacter GetCloseCharacter()
    {
        if (_characters.Count <= 0) return null;
        _closetCharacter = null;
        float closestDistance = Mathf.Infinity;
        for (int i = 0; i < _characters.Count; i++)
        {
            if (_characters[i] != null)
            {
                var distance = Vector3.Distance(transform.position,_characters[i].transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    _closetCharacter = _characters[i];
                }
            }
            else
            {
                _characters.Remove(_characters[i]);
            }
        }
        return _closetCharacter == null ? null : _closetCharacter;
    }*/
}
