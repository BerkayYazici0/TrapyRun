using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField] private float maxRange;
    [SerializeField] private float minRange;
    [SerializeField] private float obstacleMovementSpeed;
    [SerializeField] private bool isMovingLeft;

    private void Update()
    {
        if(transform.position.x > maxRange)
        {
            isMovingLeft = false;
        }
        if (transform.position.x < minRange)
        {
            isMovingLeft = true;
        }
        if(isMovingLeft == true)
        {
            transform.Translate(obstacleMovementSpeed * Time.deltaTime, 0, 0);
        }
        if (isMovingLeft == false)
        {
            transform.Translate(-obstacleMovementSpeed * Time.deltaTime, 0, 0);
        }

    }
}
