
using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class SelectForSpell : MonoBehaviour
{
    private TaskCompletionSource<Vector3> _clickTask;
    private TaskCompletionSource<Enemy> _clickTaskEnemy;

    public async Task<Vector3> WaitForClickAsync()
    {
        _clickTask = new TaskCompletionSource<Vector3>();

        while (!Input.GetMouseButton(0))
        {
            await Task.Yield();
        }
        
        Vector3 selectedPoint = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
        selectedPoint.z = 0f;

        _clickTask.SetResult(selectedPoint);
        
        return selectedPoint;
    }
    
    public async Task<Enemy> WaitForClickToEnemyAsync()
    {
        _clickTaskEnemy = new TaskCompletionSource<Enemy>();
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        while (!cancellationTokenSource.IsCancellationRequested)
        {
            if (Input.GetMouseButtonDown(1))
            {
                cancellationTokenSource.Cancel();
                break;
            }

            if (Input.GetMouseButtonDown(0))
            {
                Vector2 rayOrigin = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.zero, float.PositiveInfinity, LayerMask.GetMask("Enemy"));
                if (hit.collider != null)
                {
                    Enemy clickedEnemy = hit.collider.GetComponent<Enemy>();
                    if (clickedEnemy != null)
                    {
                        _clickTaskEnemy.SetResult(clickedEnemy);
                        return await _clickTaskEnemy.Task;
                    }
                }
            }
            await Task.Yield();
        }
        _clickTaskEnemy.TrySetCanceled();
        return null;
    } //work
    
    public async Task<Enemy> WaitForClickToEnemyAsyncTest()
    {
        while (true)
        {
            if (Input.GetMouseButtonDown(1))
            {
                return null;
            }

            if (Input.GetMouseButtonDown(0))
            {
                Vector2 rayOrigin = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.zero, Mathf.Infinity, LayerMask.GetMask("Enemy"));
                if (hit.collider != null)
                {
                    Enemy clickedEnemy = hit.collider.GetComponent<Enemy>();
                    if (clickedEnemy != null)
                    {
                        return clickedEnemy;
                    }
                }
            }
            await Task.Yield();
        }
    }//work 
}
