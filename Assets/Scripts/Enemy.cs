using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;

    private void Start()
    {
        speed = Random.Range(2, 4);
    }

    private void Update()
    {
        transform.position += Vector3.left * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Projectile")
        {
            Debug.Log("Target was hit by an arrow");
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
