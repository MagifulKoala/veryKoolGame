using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class playerControll : MonoBehaviour
{
    [SerializeField] GameObject swordPrefab;
    [SerializeField] GameObject hand;
    [SerializeField] public float playerHealth = 10;
    [SerializeField] float explosionForce = 1000;
    GameObject playerHand;
    Rigidbody rb;


    void Start()
    {
        Instantiate(swordPrefab, hand.transform);
        rb = GetComponent<Rigidbody>();
    }

    public void explode()
    {
        UnityEngine.Vector3 explosionDirection = UnityEngine.Random.onUnitSphere;
        rb.AddForce(explosionDirection * explosionForce);
    }
}
