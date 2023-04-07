using System;
using System.Collections.Generic;
using UnityEngine;

public class FindClosetEnemy : GetClose
{
    private GetClose _getCloseEnemy;
    private void Awake()
    {
        _getCloseEnemy = this;
    }

    public BaseCharacter FindClosestEnemy()
    {
        return _getCloseEnemy.GetCloseCharacter();
    }

    public List<BaseCharacter> FindClosestEnemies(int maxTargets) //test
    {
        return _getCloseEnemy.GetClosestCharacters(maxTargets);
    }

    public T FindCloseEnemyT<T>() where T : BaseCharacter
    {
        return _getCloseEnemy.GetCloseCharacterT<T>();
    }
}
