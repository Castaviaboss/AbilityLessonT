using System;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;



    private void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(movementSpeed * inputX, movementSpeed * inputY);

        movement *= Time.deltaTime;
        
        transform.Translate(movement);
    }
}
