using UnityEngine;

/*
 * This script is the parent script that all other weapon scripts will inherit from
 */
public class Weapon : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AnimationClip fireAnimation1;
    [SerializeField] private int animationLayer;

    [SerializeField] private InputSystem inputSystem;
    [SerializeField] private CountingMethod countingMethod;

    [SerializeField] private float damage;
    [SerializeField] private float cooldownTime;
    [SerializeField] private float fireDelay;
    private float counter;

    private bool cooldown;
    enum CountingMethod
    {
        Frames,
        Coroutine,
        Invoke
    }
    public void Start()
    {
        cooldown = false;
        counter = 0;
        animationLayer = 0;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Fire1();
        if (cooldown == true)
        {
            StartCooldown();
        }
    }
    public void Fire1()
    {
        if (Input.GetKey(inputSystem.getFire1()) && cooldown == false)
        {
            animator.Play(fireAnimation1.name, animationLayer, 0.0f);
            cooldown = true;
        }

    }
    public void StartCooldown()
    {
        cooldown = true;

        if (countingMethod == CountingMethod.Frames)
        {
            if (counter < cooldownTime)
            {
                counter += Time.deltaTime;
                Debug.Log("Cooldown " + cooldown);

                if (counter > cooldownTime)
                {
                    cooldown = false;
                    counter = 0;
                    animator.StopPlayback();
                    Debug.Log("Cooldown " + cooldown);
                }
            }

        }
    }
    public void SetAnimatorEnabled(bool enabled)
    {
        animator.enabled = enabled;
    }

    #region Getters and Setters
    public bool GetCooldownActive()
    {
        return cooldown;
    }
    public float GetDamageDelt()
    {
        return damage;
    }
    #endregion
}
