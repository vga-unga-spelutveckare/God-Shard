using UnityEngine;
/*
 * This is the base class that all other enemy classes will inherit from
 */
public class Enemy : MonoBehaviour
{

    [SerializeField] private float health;
    [SerializeField] private Rigidbody enemyRB;
    [SerializeField] private bool playerDetected;
    [SerializeField] private GameObject player;

    void Start()
    {
        playerDetected = false;
    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }
    public void UseWeapon()
    {

    }
    #region Setters and Getters
    public bool GetPlayerDetected()
    {
        return playerDetected;
    }
    public void SetPlayerDetected(bool detected)
    {
        playerDetected = detected;
    }
    public float GetHealth()
    {
        return health;
    }
    public void SetHealth(float newHealth)
    {
        health = newHealth;
    }
    #endregion

    public void Die()
    {
        if(health <= 0)
        {
            Debug.Log("Enemy Dead");
            //Disables the constraints on the rigidbody. Adding (~) before the function disables the constraint 
            enemyRB.constraints &= ~RigidbodyConstraints.FreezeRotationX;
            enemyRB.constraints &= ~RigidbodyConstraints.FreezeRotationZ;
            enemyRB.AddExplosionForce(20f, transform.up, 20);
        }
    }
    public void TakeDamage(float damageTaken)
    {
        health = health - damageTaken;
        Debug.Log("Damage taken" + damageTaken);

    }

}
