using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallOutCheck : MonoBehaviour
{
    [SerializeField] bool isFallOut = false;
    [SerializeField] float heightLimit = -50;
    PlayerHealth health;

    void Start()
    {
        health = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (health == null) return;
        CheckFallOut();    
    }

    private void CheckFallOut()
    {
        if (isFallOut) enabled = false;

        if (transform.position.y < heightLimit)
        {
            isFallOut = true;
            health.TakeDamage(health.HitPoints);
        }
    }
}
