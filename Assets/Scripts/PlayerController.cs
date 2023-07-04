using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] public float speed = 20.0f;
    [SerializeField] public float xRange = 20;
    [SerializeField] public float horsePower = 0f;
    public GameObject projectilePrefab;

    private Rigidbody playerRb;
    private float horizontalInput;
    private float verticalInput;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //horizontalInput = Input.GetAxis("Horizontal");
        //verticalInput = Input.GetAxis("Vertical");

        //playerRb.AddRelativeForce(Vector3.forward * verticalInput * horsePower);

    }
}
