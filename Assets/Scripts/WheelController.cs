using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WheelController : MonoBehaviour
{
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider backLeft;
    [SerializeField] WheelCollider backRight;
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelOnGround;

    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform frontRightTransform;
    [SerializeField] Transform backLeftTransform;
    [SerializeField] Transform backRightTransform;

    [SerializeField] public float horsePower = 0f;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] float speed;
    [SerializeField] float rpm;

    public float acceleration = 500f;
    [SerializeField] public float speedUp = 0f;
    public float breakingForce = 300f;
    public float maxTurnAngle = 15f;

    public Rigidbody playerRb;

    private float currentAcceleration;
    private float currentBreakingForce;
    private float currentTurnAngle;


    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();


    }
    void Update()
    {

    }
    private void FixedUpdate()
    {
        if (IsOnGround())
        {
            // set hien toc do cua xe
            speed = Mathf.Round(playerRb.velocity.magnitude * 2.237f);

            speedometerText.SetText("Speed : " + speed + "mph"); // 3.6 for kph

            // Rpm
            rpm = Mathf.Round((speed % 30) * 40);
            rpmText.SetText("RPM : " + rpm);
            TurnLeftRight();
            BreakingTheCar();
            SpeedUptheCar();
            // the car can move strangth in the street
            currentAcceleration = Input.GetAxis("Vertical") * acceleration;
        }
        // tang toc cho muot hon:::
        //currentAcceleration = Mathf.Lerp(currentAcceleration,)
        //apply acceleration to front wheel in player

        frontLeft.motorTorque = currentAcceleration;
        frontRight.motorTorque = currentAcceleration;

        frontLeft.brakeTorque = currentBreakingForce;
        frontRight.brakeTorque = currentBreakingForce;
        backLeft.brakeTorque = currentBreakingForce;
        backRight.brakeTorque = currentBreakingForce;



        // updateWheel
        UpdateWheel(frontLeft, frontLeftTransform);
        UpdateWheel(frontRight, frontRightTransform);
        UpdateWheel(backRight, backRightTransform);
        UpdateWheel(backLeft, backLeftTransform);
    }

    bool IsOnGround()
    {
        wheelOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelOnGround++;
            }
        }
        if (wheelOnGround == 4)
        {
            return true;

        }
        else
        {
            return false;
        }
    }



    // tang toc cho nguoi choi neu an shifttrai
    public void SpeedUptheCar()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentAcceleration = speedUp * acceleration;



        }
        else
        {
            currentAcceleration = 0f;
        }
    }

    public void BreakingTheCar()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            currentBreakingForce = breakingForce;
        }
        else
        {
            currentBreakingForce = 0f;
        }
    }

    public void TurnLeftRight()
    {
        //Take care the stearing
        currentTurnAngle = Input.GetAxis("Horizontal") * maxTurnAngle;

        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;

    }

    // creat the 
    void UpdateWheel(WheelCollider col, Transform trans)
    {
        //Get Wheelconlider stage
        Vector3 position;
        Quaternion rotation;

        col.GetWorldPose(out position, out rotation);

        //
        trans.position = position;
        trans.rotation = rotation;
    }
}
