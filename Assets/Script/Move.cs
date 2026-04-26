using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]

public class Move : MonoBehaviour
{
    [SerializeField]private float speed;
    private Rigidbody2D body;
    protected Vector2 currentinput;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        body.velocity = currentinput * speed;
    }
}
