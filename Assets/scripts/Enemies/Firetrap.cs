using System.Collections;
using UnityEngine;

public class Firetrap : MonoBehaviour
{
    [SerializeField] private float damage;

    [Header("Firetrap Timers")]
    [SerializeField] private float activationDelay;
    [SerializeField] private float activationTime;
    private Animator anim;
    private SpriteRenderer spriteRend;

    private bool trigggered; // when the trap gets triggered
    private bool active; // when the trap is on

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {

            if (!trigggered) { 
            // triggers the trap
                StartCoroutine(ActivateFiretrap());
            }
            if (active)
            {
                // takes damage
                collision.GetComponent<Health>().TakeDamage(damage);
            }


        }
    }

    private IEnumerator ActivateFiretrap() { 
        trigggered = true;
        spriteRend.color = Color.red;

        // Waiting for trap to trigger
        yield return new WaitForSeconds(activationDelay);
        active = true;
        spriteRend.color = Color.white;
        anim.SetBool("activated", true);

        //Waiting for trap to deactivate
        yield return new WaitForSeconds(activationTime);
        active = false;
        trigggered = false;
        anim.SetBool("activated", false);
    }
}
