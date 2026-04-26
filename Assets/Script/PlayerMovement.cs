using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : Move
{
  
    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        currentinput = input.normalized;
    }

}