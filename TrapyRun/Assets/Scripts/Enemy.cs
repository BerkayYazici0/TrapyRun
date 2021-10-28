using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{    
    public float speed;
    [SerializeField] private Animator playerAnim;
    private void Start()
    {
        
    }
    private void Update()
    {
        gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            speed = 0;
            playerAnim.SetBool("isFalling", true);
        }
    }
}
