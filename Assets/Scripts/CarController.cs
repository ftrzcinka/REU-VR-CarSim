using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private GasBrakeHandler inputManager;
    public List<WheelCollider> throttleWheels;
    public List<WheelCollider> steeringWheels;
    public float strengthCoefficient = 500000f;
    public float maxTurn = 20f;

    void Start()
    {
        inputManager = GetComponent<GasBrakeHandler>();
    }

    void FixedUpdate()
    {
        foreach (WheelCollider wheel in throttleWheels)
        {
            wheel.motorTorque = strengthCoefficient * Time.deltaTime * inputManager.Acceleration;
            wheel.wheelDampingRate = inputManager.wheelDampening;
        }

        foreach (WheelCollider wheel in steeringWheels)
        {
            wheel.steerAngle = maxTurn * inputManager.Steering;
            wheel.wheelDampingRate = inputManager.wheelDampening;
        }
    }
}
