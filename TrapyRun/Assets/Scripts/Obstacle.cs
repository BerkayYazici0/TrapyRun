using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;

    private void Update()
    {
        //gameObject.transform.RotateAround(transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
        gameObject.GetComponent<Rigidbody>().AddTorque(Vector3.up * rotationSpeed);
    }
}
