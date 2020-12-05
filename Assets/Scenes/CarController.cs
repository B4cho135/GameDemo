using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    public float currentSteerAngle;
    private float currentbreakForce;
    private bool isBreaking;

    public float currentSpeed;


    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;
    [SerializeField] private float topSpeed;
    [SerializeField] private float minSpeed;
    [SerializeField] private float slowDownBreakForce;


    [SerializeField] private Rigidbody rb;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheeTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;

    private void Start()
    {
        rb.centerOfMass = new Vector3(0, 0, 0);

        rb.velocity = new Vector3(25f, 0, 0);
        Input.gyro.enabled = true;
    }

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }


    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);

        if(Input.GetKey("r"))
        {
            ResetCar();
        }


    }

    private void HandleMotor()
    {
        currentSpeed = 2 * Mathf.PI * rearLeftWheelCollider.radius * rearLeftWheelCollider.rpm * 60 / 1000;

        if (currentSpeed < minSpeed)
        {
            rearLeftWheelCollider.motorTorque = 10000 * Time.deltaTime;
            rearRightWheelCollider.motorTorque = 10000 * Time.deltaTime;

        }

        //if (verticalInput == 0 && currentSpeed > minSpeed)
        //{
        //    ApplyBreaking(slowDownBreakForce);
        //}



        if (currentSpeed > topSpeed)
        {
            rearLeftWheelCollider.motorTorque = 0f;
            rearRightWheelCollider.motorTorque = 0f;
        }
        else
        {
            if (verticalInput > 0)
            {
                rearLeftWheelCollider.motorTorque = verticalInput * motorForce * Time.deltaTime;
                rearRightWheelCollider.motorTorque = verticalInput * motorForce * Time.deltaTime;
            }
        }

        
        currentbreakForce = isBreaking && currentSpeed > minSpeed ? breakForce : 0f;
        if (isBreaking)
        {
            ApplyBreaking(currentbreakForce);
        }

        else if (Input.GetKeyUp(KeyCode.Space))
        {
            ResetWheels();
        }
    }

    private void ApplyBreaking(float currentBreakForce)
    {
        frontRightWheelCollider.brakeTorque = currentBreakForce * Time.deltaTime;
        frontLeftWheelCollider.brakeTorque = currentBreakForce * Time.deltaTime;
        rearLeftWheelCollider.brakeTorque = currentBreakForce * Time.deltaTime;
        rearRightWheelCollider.brakeTorque = currentBreakForce * Time.deltaTime;
    }

    private void ResetWheels()
    {
        frontRightWheelCollider.brakeTorque = 0f;
        frontLeftWheelCollider.brakeTorque = 0f;
        rearLeftWheelCollider.brakeTorque = 0f;
        rearRightWheelCollider.brakeTorque = 0f;
    }

    private void HandleSteering()
    {
        if (currentSpeed > 40)
        {
            currentSteerAngle = (4 * horizontalInput) / (currentSpeed / 100);
        }
        else
        {
            currentSteerAngle = maxSteerAngle * horizontalInput;
        }
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheeTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot; 
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }


    private void ResetCar()
    {
        transform.position = new Vector3(0f, 0.5f, 60.7f);

        Quaternion quaternion = Quaternion.Euler(0, 90, 0);

        transform.rotation = quaternion;

        
        rb = gameObject.GetComponent<Rigidbody>();

        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

    }
}

