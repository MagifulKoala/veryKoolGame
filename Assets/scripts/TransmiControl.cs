using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TransmiControl : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float rotationSpeed;

    [SerializeField] int numberOfWagons = 0;
    [SerializeField] float forceMultiply = 1;

    [SerializeField] GameObject busMiddlePrefab;
    [SerializeField] GameObject busBackPrefab;
    [SerializeField] UnityEngine.Vector3 busMiddleSpawnOffset = new UnityEngine.Vector3(-10.89f, 0f, 0f);
    [SerializeField] UnityEngine.Vector3 busBackSpawnOffset = new UnityEngine.Vector3(-13.94f, 0f, 0f);
    [SerializeField] AudioClip accelerateAudioClip;


    AudioSource transmiAudioSource;
    //bool isPlaying = false;

    Rigidbody rb;
    UnityEngine.Vector3 moveVector = new UnityEngine.Vector3(0, 0, 0);
    UnityEngine.Vector3 angularVector = new UnityEngine.Vector3(0, 0, 0);




    void Start()
    {
        transmiAudioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();

        if (numberOfWagons > 0)
        {
            speed *= numberOfWagons * forceMultiply;
        }

        initializeWagons(numberOfWagons);
    }

    private void initializeWagons(int numberOfWagons)
    {
        GameObject parentWagon = gameObject;


        for (int i = 0; i < numberOfWagons; i++)
        {
            GameObject tempWagon;

            if (i == numberOfWagons - 1)
            {
                UnityEngine.Vector3 spawnPoint = new UnityEngine.Vector3(
                parentWagon.transform.position.x + busBackSpawnOffset.x,
                transform.localPosition.y,
                transform.localPosition.z
                );
                //Debug.Log("last Wagon pos: " + spawnPoint);
                tempWagon = Instantiate(busBackPrefab, spawnPoint, transform.rotation);
                initializeConfigurableJoint(tempWagon, parentWagon);

            }
            else
            {
                UnityEngine.Vector3 spawnPoint2 = new UnityEngine.Vector3(
                parentWagon.transform.position.x + busMiddleSpawnOffset.x,
                transform.localPosition.y,
                transform.localPosition.z
                );
                //Debug.Log("middle " + i + " pos: " + spawnPoint2);
                tempWagon = Instantiate(busMiddlePrefab, spawnPoint2, transform.rotation);
                initializeConfigurableJoint(tempWagon, parentWagon);
            }

            parentWagon = tempWagon;
        }
    }

    private void initializeSpringJoints(GameObject pWagon, GameObject pParent)
    {
        SpringJoint springJoint = pWagon.GetComponent<SpringJoint>();
        springJoint.autoConfigureConnectedAnchor = false;
        springJoint.anchor = new UnityEngine.Vector3(6.52f, 1f, 0f);
        springJoint.connectedAnchor = new UnityEngine.Vector3(-7.55f, 1f, 0f);
        springJoint.spring = 200;
        springJoint.damper = 1;
        springJoint.connectedBody = pParent.GetComponent<Rigidbody>();
    }

    private void initializeConfigurableJoint(GameObject pWagon, GameObject pParent)
    {
        ConfigurableJoint configJoint = pParent.transform.AddComponent<ConfigurableJoint>();
        configJoint.anchor = new UnityEngine.Vector3(-7.8f, 1.89f, 0f);
        configJoint.autoConfigureConnectedAnchor = false;
        configJoint.connectedAnchor = new UnityEngine.Vector3(3.66f, 1.87f, 0f);
        configJoint.connectedBody = pWagon.GetComponent<Rigidbody>();

        configJoint.xMotion = UnityEngine.ConfigurableJointMotion.Locked; 
        configJoint.yMotion = UnityEngine.ConfigurableJointMotion.Locked; 
        configJoint.zMotion = UnityEngine.ConfigurableJointMotion.Locked;

        configJoint.angularXMotion = UnityEngine.ConfigurableJointMotion.Locked;
        configJoint.angularZMotion = UnityEngine.ConfigurableJointMotion.Locked;

        UnityEngine.SoftJointLimit limits = new UnityEngine.SoftJointLimit
        {
            limit = 45f,
            bounciness = 0,
            contactDistance = 0
        };

        configJoint.angularYLimit = limits; 
    }

    private void FixedUpdate()
    {

        if (Math.Abs(Input.GetAxis("Vertical")) > 0)
        {
            moveVector.x = speed * Input.GetAxis("Vertical");
            moveVector.y = GetComponent<Rigidbody>().velocity.y;
            moveVector.z = GetComponent<Rigidbody>().velocity.z;
            Debug.Log("speed" + speed);

            //rb.velocity = moveVector;
            rb.AddRelativeForce(moveVector.x, 0, 0);

   /*          if (!transmiAudioSource.isPlaying)
            {
                //transmiAudioSource.volume =0.4f;
                //transmiAudioSource.PlayOneShot(accelerateAudioClip);
                //isPlaying = true;
            } */

        }
        if (Math.Abs(Input.GetAxis("Horizontal")) > 0)
        {
            angularVector.x = GetComponent<Rigidbody>().angularVelocity.x;
            angularVector.y = rotationSpeed * Input.GetAxis("Horizontal");
            angularVector.z = GetComponent<Rigidbody>().angularVelocity.z;
            Debug.Log("roation" + rotationSpeed);

            rb.angularVelocity = angularVector;
/* 
            if (!transmiAudioSource.isPlaying)
            {
                transmiAudioSource.PlayOneShot(accelerateAudioClip);
                isPlaying = true;
            } */
        }
    }

}
