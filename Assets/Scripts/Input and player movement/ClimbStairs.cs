using UnityEngine;
using System.Collections;

/*
 * This class is basically the same as the vault class, except this class is used for climbing stairs and 
 */
public class ClibStairs : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private InputSystem inputSystem;
    [SerializeField] private PlayerGroundCheck groundCheck;
    [SerializeField] private string stairTag;
    [SerializeField] private float rayDistance;
    [SerializeField] private float bottomRayHeight, topRayHeight;
    [SerializeField] private float climbSpeed, climbHeight, radius;
    [SerializeField] private float cooldownTime;
    [SerializeField] private bool canClimb, topCollisionDetected, bottomCollisionDetected, cooldownActive;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ClimbCooldown());
        canClimb = false;
    }
    IEnumerator ClimbCooldown()
    {
        while (true)
        {
            Debug.Log("Corutine Test. Cooldown = " + cooldownActive);
            yield return new WaitForSeconds(cooldownTime);
            if (cooldownActive == true)
            {
                cooldownActive = false;
            }
            Debug.Log("Corutine Test. Cooldown = " + cooldownActive );

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        TopCheck();
        BottomCheck();
        VaultOverLedge();

    }
    private void BottomCheck()
    {
        RaycastHit hit;
        Ray ray = new Ray(new Vector3(transform.position.x, transform.position.y + bottomRayHeight, transform.position.z), player.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);

        if (Physics.Raycast(ray, out hit, rayDistance) && hit.transform.gameObject.tag == stairTag)
        {
            bottomCollisionDetected = true;

        }
        else
        {
            bottomCollisionDetected = false;
        }
    }
    private void TopCheck()
    {
        RaycastHit hit;
        Ray ray = new Ray(new Vector3(transform.position.x, transform.position.y + topRayHeight, transform.position.z), player.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.green);

        if (Physics.Raycast(ray, out hit, rayDistance) && hit.transform.gameObject.tag == stairTag)
        {
            topCollisionDetected = true;

        }
        else
        {
            topCollisionDetected = false;
        }
    }
    private void VaultOverLedge()
    {
        if(topCollisionDetected == false && bottomCollisionDetected == true)
        {
            canClimb = true;
        }
        else
        {
            canClimb = false;
        }
        if (cooldownActive == false && canClimb == true && !Input.GetKey(inputSystem.getJump()) && Input.GetKey(inputSystem.getForward()))
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + climbHeight, player.transform.position.z + climbSpeed);
            cooldownActive = true;
            //player.transform.position = Vector3.Lerp(player.transform.position, new Vector3(player.transform.position.x, player.transform.position.y + climbHeight, player.transform.position.z ), climbSpeed);
            //player.GetComponent<Rigidbody>().AddExplosionForce(climbHeight, new Vector3(player.transform.position.x, player.transform.position.y - 1f, player.transform.position.z), radius);
            //player.GetComponent<Rigidbody>().AddForce(player.transform.forward * climbSpeed);
        }
        else
        {
            Debug.Log("can't Vault");
        }

    }
}
