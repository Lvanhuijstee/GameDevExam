using UnityEngine;

public class PlayyerAttack : MonoBehaviour {

    private Animator anim;
    private playerMovement playerMovement;

    [SerializeField]private Transform firePoint;
    [SerializeField] private GameObject[] fireBalls;

    [SerializeField]private float AttackCooldown;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<playerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer >= AttackCooldown && playerMovement.canAttack()) {
            Attack();
        }

        cooldownTimer += Time.deltaTime;
       
    }

    private void Attack() {
        cooldownTimer = 0;
        anim.SetTrigger("attack");

        //object pooling
        fireBalls[findFireBall()].transform.position = firePoint.position;
        fireBalls[findFireBall()].GetComponent<Fireball>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int findFireBall() {
        for (int i = 0; i < fireBalls.Length; i++) {
            if (!fireBalls[i].activeInHierarchy) { 
            return i;
            }
        }
        
        return 0;
    }
}
