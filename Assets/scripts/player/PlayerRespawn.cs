using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Transform currentCeckpoint;
    private Health playerHealth;
    private UIManager uiManager;
   
    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        uiManager = FindObjectOfType<UIManager>();

    }
    public void Respawn()
    {
        if (currentCeckpoint == null) {
            uiManager.GameOver();
            return; //no checkpoint reached yet
        }

        // move player to checkpoint
        transform.position = currentCeckpoint.position;

        // restore health and animations to default
        playerHealth.RespawnSet();

        //moveving camera back to the checkpoint
      

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Checkpoint"))
        {
            currentCeckpoint = collision.transform; //store checkpoint

            collision.GetComponent<Collider2D>().enabled = false; 
            collision.GetComponent<Animator>().SetTrigger("activate"); //play checkpoint animation
        }
    }
}
