﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVFX;
    
    [SerializeField] int scorePerHit = 15;
    [SerializeField] int killHit = 2;
    // [SerializeField] AudioClip musicEnemy ;

    // AudioSource audioSource ;
    ScoreBoard scoreBoard;
    GameObject parentGameObject;
    Rigidbody rb;

    void Start()
    {
        AddRigidbody();
        scoreBoard = FindObjectOfType<ScoreBoard>();
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
        // audioSource = GetComponent<AudioSource>();
    }

    private void AddRigidbody()
    {
        rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void OnParticleCollision(GameObject other)
    {
        // audioSource.Stop();
        // audioSource.Play(musicEnemy);
        ProcessHit();
        if(killHit<1)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        Destroy(gameObject);       
    }

    private void ProcessHit()
    {
        killHit--;
        GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
        scoreBoard.IncreaseScore(scorePerHit);
    }
}
