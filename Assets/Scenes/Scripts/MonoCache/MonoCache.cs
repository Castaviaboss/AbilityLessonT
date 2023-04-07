using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoCache : MonoBehaviour
{
    public static List<MonoCache> UpdatesList = new List<MonoCache>(50);

    private void OnEnable()
    {
        UpdatesList.Add(this);
    }

    private void OnDisable()
    {
        UpdatesList.Remove(this);
    }

    private void OnDestroy()
    {
        UpdatesList.Remove(this);
    }

    public void Tick() => OnTick();
    
    public virtual void OnTick() { }

}
