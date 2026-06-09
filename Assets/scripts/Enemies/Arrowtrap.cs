using Unity.Mathematics;
using UnityEngine;

public class Arrowtrap : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] arrows;
    [SerializeField] private float startDelay;
    
    private float CompleteCooldown;
    private float cooldownTimer;
    private void Attack() {
        cooldownTimer = 0;
        // find an inactive arrow in the pool and activate it
        arrows[FindArrow()].transform.position = firePoint.position;
        arrows[FindArrow()].GetComponent<EnemyProjectile>().ActivateProjectile();
    }
    private int FindArrow() 
    {
        for (int i = 0; i < arrows.Length; i++) {
            if (!arrows[i].activeInHierarchy) {
                return i;
            }
        }
        return 0;
    }

    private void Update()
    { 
        cooldownTimer += Time.deltaTime;
        
        CompleteCooldown = attackCooldown + startDelay;
        if (cooldownTimer > CompleteCooldown)
        {
            Attack();
            startDelay = 0;
        }       
    }
}
