using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : Move
{
    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        currentinput = input.normalized;

        // cek arah horizontal
        if (input.x > 0)
        {
            FaceRight();
        }
        else if (input.x < 0)
        {
            FaceLeft();
        }
    }

    void FaceRight()
    {
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x);
        transform.localScale = scale;
    }

    void FaceLeft()
    {
        Vector3 scale = transform.localScale;
        scale.x = -Mathf.Abs(scale.x);
        transform.localScale = scale;
    }
}