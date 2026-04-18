using UnityEngine;

/*
 * This class handles player movement i.e Walking, jumping, crouching and more.
 * Also plays movement related audio
 */
public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Camera playerCamera;
    [SerializeField] private Rigidbody playerRB;
    [SerializeField] private InputSystem inputSystem;
    [SerializeField] private PlayerGroundCheck groundCheck;

    [SerializeField] private float movementSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private float topSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float gravitationalForce;

    void Start()
    {

    }
    void Update()
    {
        rotatePlayerWithCamera();
        Walk();
        Jump();
        crouch();
        ApplyGravity();
    }
    private void rotatePlayerWithCamera()
    {
        transform.eulerAngles = new Vector3(0, playerCamera.transform.eulerAngles.y, 0);
    }

    private void Walk()
    {
        if (Input.GetKey(inputSystem.getSprint()))
        {
            topSpeed = sprintSpeed;
        }
        else
        {
            topSpeed = walkSpeed;
        }

        if ((playerRB.linearVelocity.magnitude / 3.6) < topSpeed)
        {
            //forwards
            if (Input.GetKey(inputSystem.getForward()))
            {
                playerRB.AddForce(transform.forward * movementSpeed);

            }
            else if (!Input.GetKey(inputSystem.getForward()))
            {
                //playerRB.AddForce(transform.forward * 0);
            }

            //Backwards
            if (Input.GetKey(inputSystem.getBack()))
            {
                playerRB.AddForce(transform.forward * -movementSpeed);
            }
            //Right
            if (Input.GetKey(inputSystem.getRight()))
            {
                playerRB.AddForce(transform.right * movementSpeed);
            }
            //Left
            if (Input.GetKey(inputSystem.getLeft()))
            {
                playerRB.AddForce(transform.right * -movementSpeed);
            }


        }
        if (Input.anyKey == false && groundCheck.getIsGrounded() == true)
        {
            playerRB.linearDamping = 100;
        }
        else
        {
            playerRB.linearDamping = 0;
        }


    }
    private void Jump()
    {
        if (Input.GetKeyDown(inputSystem.getJump()) && groundCheck.getIsGrounded() == true)
        {
            playerRB.AddForce(transform.up * jumpSpeed);
        }


    }
    private void crouch()
    {
        if (Input.GetKey(inputSystem.getCrouch()))
        {
            transform.localScale = new Vector3(transform.localScale.x, 0.5f, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
    private void ApplyGravity()
    {
        if(groundCheck.getIsGrounded() == false)
        {
            playerRB.AddForce(transform.up * gravitationalForce);
        }
        
    }
}
