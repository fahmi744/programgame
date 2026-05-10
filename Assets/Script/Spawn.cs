using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemy;

    [Header("Object Spawn Setting")]
    public float spawndelay = 2f;

    [Header("Spawn Setting")]
    public float spawninterval = 3f;
    public Transform player;

    private void Start()
    {
        Debug.Log("Spawn Start() dipanggil!");
        
        if (enemy == null) Debug.LogError("Enemy belum di-assign!");
        if (player == null) Debug.LogError("Player belum di-assign!");

        InvokeRepeating(nameof(Spawner), spawndelay, spawninterval);
    }

    void Spawner()
    {
        Debug.Log("Spawner() dipanggil!");
        
        if (enemy == null || player == null) return;
        
        // Spawn tepat di posisi Spawner object, bukan relatif ke player
        Vector2 spawnPosisi = transform.position;
        Instantiate(enemy, spawnPosisi, Quaternion.identity);
        Debug.Log("Enemy di-spawn di: " + spawnPosisi);
    }
}