using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class transmiFX : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] float explosionScale = 2f;
    [SerializeField] int numExplosions = 3;
    [SerializeField] float explosionRadius = 1;
    [SerializeField] float lifePoints = 3;
    [SerializeField] AudioClip boom;

    List<GameObject> explosionPrefabs;

    AudioSource audioTransmi;


    public UnityEvent lifePointsZero;

    private void Start()
    {
        explosionPrefabs = new List<GameObject>(); 
        audioTransmi = transform.AddComponent<AudioSource>();

        for (int i = 0; i < numExplosions; i++)
        {
            UnityEngine.Vector3 spawnPoint = UnityEngine.Random.onUnitSphere * explosionRadius;
            GameObject explosion = Instantiate(explosionPrefab, transform); 
            explosion.transform.localPosition = spawnPoint;
            explosion.transform.localScale = explosion.transform.localScale * explosionScale;
            explosionPrefabs.Add(explosion);
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("environment"))
        {
            lifePoints--;
            if (lifePoints <= 0)
            {
                lifePointsZero?.Invoke();
            }

        }
    }

    public void startParticleSystem()
    {
        foreach (var explosion in explosionPrefabs)
        {
            explosion.GetComponent<ParticleSystem>().Play();
            //audioTransmi.PlayOneShot(boom);
        }
    }
}
