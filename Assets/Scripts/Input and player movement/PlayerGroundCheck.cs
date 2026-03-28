using UnityEngine;

/*
 * This class checks whether or not the player is grounded.
 * This is done using a raycast. the child object should be placed at the Characters center
 */
public class PlayerGroundCheck : MonoBehaviour
{

    [SerializeField] private string groundTag;
    [SerializeField] private float rayDistance;
    [SerializeField] private float outerOffset;
    private bool isGrounded;

    public void Update()
    {
        getIsGrounded();
    }
    public bool getIsGrounded()
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, Vector3.down);
        Ray rayFront = new Ray(new Vector3(transform.position.x, transform.position.y, transform.position.z + outerOffset), Vector3.down);
        Ray rayBack = new Ray(new Vector3(transform.position.x, transform.position.y, transform.position.z - outerOffset), Vector3.down);
        Ray rayLeft = new Ray(new Vector3(transform.position.x - outerOffset, transform.position.y, transform.position.z), Vector3.down);
        Ray rayRight = new Ray(new Vector3(transform.position.x + outerOffset, transform.position.y, transform.position.z), Vector3.down);
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);
        Debug.DrawRay(rayFront.origin, rayFront.direction * rayDistance, Color.red);
        Debug.DrawRay(rayBack.origin, rayBack.direction * rayDistance, Color.red);
        Debug.DrawRay(rayLeft.origin, rayLeft.direction * rayDistance, Color.red);
        Debug.DrawRay(rayRight.origin, rayRight.direction * rayDistance, Color.red);
        //Center ray
        if (Physics.Raycast(ray, out hit, rayDistance) && hit.transform.gameObject.tag == groundTag)
        {
            isGrounded = true;

        }
        else
        {
            isGrounded = false;
        }
        //Front ray
        if (Physics.Raycast(rayFront, out hit, rayDistance) && hit.transform.gameObject.tag == groundTag)
        {
            isGrounded = true;

        }
        else
        {
            isGrounded = false;
        }
        //Back ray
        if (Physics.Raycast(rayBack, out hit, rayDistance) && hit.transform.gameObject.tag == groundTag)
        {
            isGrounded = true;

        }
        else
        {
            isGrounded = false;
        }
        //Right ray
        if (Physics.Raycast(rayRight, out hit, rayDistance) && hit.transform.gameObject.tag == groundTag)
        {
            isGrounded = true;

        }
        else
        {
            isGrounded = false;
        }
        //left ray
        if (Physics.Raycast(rayLeft, out hit, rayDistance) && hit.transform.gameObject.tag == groundTag)
        {
            isGrounded = true;

        }
        else
        {
            isGrounded = false;
        }
        return isGrounded;
    }
}
