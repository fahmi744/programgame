using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCRotasi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float speed = 40f; 
    public float maxRotation = 40f; 
    private float currentRotation = 0f;
    void Update()
    {
    float step = speed * Time.deltaTime;
    currentRotation += step;
    if (currentRotation >= maxRotation || currentRotation <= 0)
    {
        speed *= -1; 
    }
    transform.Rotate(0, 0, step);
    }
}


