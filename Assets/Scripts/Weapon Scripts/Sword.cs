using UnityEngine;

/*
 * This class inherits from the weapon class and is used for swords
 */
public class Sword : Weapon
{
    [SerializeField] private Collider bladeCollider;
    [SerializeField] private string enemyTag;

    protected override void Update()
    {
        base.Update();
        BladeCollision();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Enemy hit;
        if(collision.gameObject.GetComponent<Enemy>())
        {
            Debug.Log("Enemy Hit for" + GetDamageDelt() + " Damage");
            hit = collision.gameObject.GetComponent<Enemy>();
            hit.TakeDamage(GetDamageDelt());
        }
        
    }
    public void BladeCollision()
    {
        if (GetCooldownActive() == true)
        {
            bladeCollider.enabled = true;
        }
        else
        {
            bladeCollider.enabled = false;
        }

    }
   
}
