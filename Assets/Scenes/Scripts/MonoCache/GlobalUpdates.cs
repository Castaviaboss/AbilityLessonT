using UnityEngine;

public class GlobalUpdates : MonoBehaviour
{
    private void Update()
    {
        for (int i = 0; i < MonoCache.UpdatesList.Count; i++) MonoCache.UpdatesList[i].Tick();
    }
}
