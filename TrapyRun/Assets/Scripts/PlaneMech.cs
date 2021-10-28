using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMech : MonoBehaviour
{
    public Animator playerAnim;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private Material pressedMat;
    public PlayerMovement playerMovement;


    private void Update()
    {
        if(gameObject.transform.position.y < -1f)
        {
            //falling down
            playerAnim.SetBool("isFallingDown", true);
            playerMovement.speed = 0;
            playerMovement.leftRightSpeed = 0;
            GameManager.Instance.Fail();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "PlanePart")
        {
            collision.gameObject.GetComponent<MeshRenderer>().material = pressedMat;
            collision.gameObject.GetComponent<Rigidbody>().useGravity = true;
            Destroy(collision.gameObject,3f);
        }
        if (collision.gameObject.tag == "Finish")
        {
            playerAnim.SetBool("isLevelFinish", true);
            GameManager.Instance.Success();
            playerMovement.speed = 0;
            playerMovement.leftRightSpeed = 0;            
        }
        if (collision.gameObject.tag == "Enemy")
        {
            playerAnim.SetBool("isFalling", true);
            playerMovement.speed = 0;
            playerMovement.leftRightSpeed = 0;
            GameManager.Instance.Fail();
        }
    }
}
