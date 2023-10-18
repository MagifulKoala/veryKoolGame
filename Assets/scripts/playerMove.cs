using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class playerMove : MonoBehaviour
{
    [SerializeField] float movementSpeed;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (Mathf.Abs(horizontalInput) > 0)
        {
            transform.position = new UnityEngine.Vector3(
                transform.position.x,
                transform.position.y,
                transform.position.z + horizontalInput * movementSpeed * Time.deltaTime * -1
            );
        }

    }

    private void FixedUpdate()
    {

    }

}
