using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float leftRightSpeed;
    private float startPos;
    private float currentPos;
    private void Update()
    {
        gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            startPos = Camera.main.ScreenToViewportPoint(Input.mousePosition).x;
        }
        if (Input.GetMouseButton(0))
        {
            leftRightSpeed = 3f;
            currentPos = Camera.main.ScreenToViewportPoint(Input.mousePosition).x;
        }
        if (Input.GetMouseButtonUp(0))
        {
            leftRightSpeed = 0f;
        }
        

        if(currentPos > startPos && gameObject.transform.position.x < 2.25f)
        {
            // move right
            gameObject.transform.Translate(Vector3.right * leftRightSpeed * Time.deltaTime);
        }
        else if (currentPos < startPos && gameObject.transform.position.x > -2.25f)
        {
            //move left
            gameObject.transform.Translate(Vector3.left * leftRightSpeed * Time.deltaTime);
        }
    }


}
