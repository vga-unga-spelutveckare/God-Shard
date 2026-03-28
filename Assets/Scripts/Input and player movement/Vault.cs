using UnityEngine;

/*
 * This class contains the implementation of the vaulting mechanic
 * by checking if the player is airborne and if they are colliding with a ledge. 
 * 
 * This is done using two raycasts. The top one is used to check is the player is at the right height in relation to the wall, 
 * and the bottom one checks whether or not the player is colliding with the wall
 */
public class Vault : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private InputSystem inputSystem;
    [SerializeField] private PlayerGroundCheck groundCheck;
    [SerializeField] private string groundTag;
    [SerializeField] private float rayDistance;
    [SerializeField] private float bottomRayHeight, topRayHeight;
    [SerializeField] private float vaultSpeed, vaultHeight;
    [SerializeField] private bool canVault;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canVault = false;
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

        if (Physics.Raycast(ray, out hit, rayDistance) && hit.transform.gameObject.tag == groundTag)
        {
            canVault = true;

        }
        else
        {
            canVault = false;
        }
    }
    private void TopCheck()
    {
        RaycastHit hit;
        Ray ray = new Ray(new Vector3(transform.position.x, transform.position.y + topRayHeight, transform.position.z), player.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.green);

        if (Physics.Raycast(ray, out hit, rayDistance) && hit.transform.gameObject.tag == groundTag)
        {
            canVault = false;

        }
        else
        {
            canVault = true;
        }
    }
    private void VaultOverLedge()
    {
        if (canVault == true && Input.GetKey(inputSystem.getJump()) && !Input.GetKey(inputSystem.getCrouch()) && Input.GetKey(inputSystem.getForward()))
        {
            //player.transform.position = Vector3.Lerp(player.transform.position, new Vector3( player.transform.position.x, player.transform.position.y + vaultHeight, player.transform.position.z + 0.3f), vaultSpeed);
            player.GetComponent<Rigidbody>().AddForce(player.transform.up* vaultHeight);
            player.GetComponent<Rigidbody>().AddForce(player.transform.forward * vaultSpeed);
        }
        else
        {
            Debug.Log("can't Vault");
        }

    }
}
