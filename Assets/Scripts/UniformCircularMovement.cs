using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniformCircularMovement : MonoBehaviour
{
    public float PushForce = 1.0f;
    public float Radius = 1.0f;
    public float StartDegree = 270.0f;
    public GameObject RotatePoint;

    Rigidbody PhysicsSystem;
    bool onConnection = true;

    void Start()
    {
        PhysicsSystem = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            onConnection = false;
            float V = Mathf.Sqrt((PushForce * Radius) / PhysicsSystem.mass);
            PhysicsSystem.velocity = gameObject.transform.right * V;
        }
        */
    }

    private void FixedUpdate()
    {
        if (onConnection == true)
        {
            // Find Velocity =>  Velocity = SquareRoot( Force * Radius ) / Mass.
            float V = Mathf.Sqrt((PushForce * Radius) / PhysicsSystem.mass);

            // Find T  =>  T = ( 2 * PI * Radius ) / Velocity
            float T = (2 * Mathf.PI * Radius) / V;

            // Find Radian  =>  ChangedRadian = ( 2 * PI * t ) / T
            float CurrentTime = Time.timeSinceLevelLoad;
            float ChangedRadian = (2 * Mathf.PI * CurrentTime) / T;

            // Convert ChangedRadian to ChangedDegree
            float ChangedDegree = ChangedRadian * 180.0f / Mathf.PI;
            float FinalDegree = StartDegree + ChangedDegree;

            // Convert FinalDegree to FinalRadian
            float FinalRadian = FinalDegree * Mathf.PI / 180.0f;

            // Calculate Changed Position
            float ChangedPos_X = Radius * Mathf.Cos(FinalRadian);
            float ChangedPos_Y = Radius * Mathf.Sin(FinalRadian);

            // Apply Changed Position to this Object.
            gameObject.transform.position = RotatePoint.transform.position + new Vector3(ChangedPos_X, ChangedPos_Y, 0);

            // Apply Angle Z -> 90 Degree from Degree to Center.
            gameObject.transform.eulerAngles = new Vector3(0, 0, FinalDegree + 90.0f);
        }
    }
}