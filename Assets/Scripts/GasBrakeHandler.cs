using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GasBrakeHandler: MonoBehaviour
{
    public float Acceleration
    {
        get { return m_Acceleration; }
    }

    public float Steering
    {
        get { return m_Steering; }
    }

    public InputActionReference accRef;
    public InputActionReference decRef;
    public InputActionReference steerRef;

    float m_Acceleration;
    float m_Steering;

    private bool accelerating = false;

    /*
    private bool breaking = false;
    private bool turningLeft = false;
    private bool turningRight = false;

    */

    public float wheelDampening;

    public void Update()
    {
        if(accRef.action.ReadValue<float>() != 0f)
        {
            m_Acceleration = (accRef.action.ReadValue<float>() * -1f) * 5f;
            wheelDampening = 200f;
            accelerating = true;
} 
        else if(decRef.action.ReadValue<float>() != 0f)
        {
            m_Acceleration = decRef.action.ReadValue<float>();
            wheelDampening = 600f;
            accelerating = false;
        }
        else
        {
            m_Acceleration = 0f;
            wheelDampening = 5f;
            accelerating = true;
        }

        if(steerRef.action.ReadValue<float>() < 0f)
        {
            if (accelerating)
            {
                m_Steering = steerRef.action.ReadValue<float>() - 0.5f;
            }
            else
            {
                m_Steering = (steerRef.action.ReadValue<float>() - 0.5f) * -1f;
            }
        }
        else if(steerRef.action.ReadValue<float>() > 0f)
        {
            if (accelerating)
            {
                m_Steering = steerRef.action.ReadValue<float>() + 0.5f;
            }
            else
            {
                m_Steering = (steerRef.action.ReadValue<float>() + 0.5f) * -1f;
            }
        }
        else
        {
            m_Steering = 0f;
        }
    }

    /*
    void Update()
    {
        GetPlayerInput();
        if (accelerating)
        {
            m_Acceleration = -2f;
            wheelDampening = 350f;

        }
        else if (reversing)
        {
            m_Acceleration = 1f;
            wheelDampening = 700f;
        }
        else if (breaking)
        {
            m_Acceleration = 0f;
            wheelDampening = 10000f;

        }
        else
        {
            m_Acceleration = 0f;
            wheelDampening = 5f;
        }

        if (turningLeft)
        {
            if (accelerating)
            {
                m_Steering = 1.5f;
            }
            else if (!accelerating)
            {
                m_Steering = -1.5f;
            }
        }
        else if (!turningLeft && turningRight)
        {
            if (accelerating)
            {
                m_Steering = -1.5f;
            }
            else if (!accelerating)
            {
                m_Steering = 1.5f;
            }
        }
        else
        {
            m_Steering = 0f;
        }
    }

    private void GetPlayerInput()
    {
        if (Input.GetKey("w"))
        {
            accelerating = true;
        }
        else
        {
            accelerating = false;
        }

        if (Input.GetKey("s"))
        {
            reversing = true;
        }
        else
        {
            reversing = false;
        }
        if (Input.GetKey("space"))
        {
            breaking = true;
        }
        else
        {
            breaking = false;
        }
        if (Input.GetKey("a"))
        {
            turningLeft = true;
        }
        else
        {
            turningLeft = false;
        }
        if (Input.GetKey("d"))
        {
            turningRight = true;
        }
        else
        {
            turningRight = false;
        }
    } */
}
