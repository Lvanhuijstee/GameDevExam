using System.Collections;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private Behaviour[] components;

    [Header ("Health")] 
    [SerializeField] private float startingHealth;
    public float currentHealth;
    private Animator anim;
    private bool dead;

    [Header("iFrames")]
    [SerializeField]private float iFrameDuration;
    [SerializeField] private int counter;
    private SpriteRenderer spriteRend;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float _damage)
    {

        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            //player hurt
            anim.SetTrigger("hurt");
            //iframes
            StartCoroutine(invunerability());
        }
        else
        {
            if (!dead) {

                //Deactivate all attached component classes
                foreach (Behaviour component in components) {
                    component.enabled = false;

                    anim.SetBool("grounded", true);
                    anim.SetTrigger("die");

                    dead = true;
                }
                   
            }
        }
    }

    public void addHealth(float _value) {
        currentHealth = Mathf.Clamp(currentHealth +_value, 0, startingHealth);
    }

    private IEnumerator invunerability() {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        // duration
        for (int i = 0; i < counter; i++) {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFrameDuration / (counter * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFrameDuration / (counter * 2));
        }
        Physics2D.IgnoreLayerCollision(8, 9, false);
    }

    public void RespawnSet() {
        dead = false;
        addHealth(startingHealth);
        anim.ResetTrigger("die"); 
        anim.Play("idle");

        // reactivate all attached components
        foreach (Behaviour component in components)
        {
            component.enabled = true;

        }

    }
}
