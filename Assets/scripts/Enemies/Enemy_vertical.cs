using UnityEngine;

public class Enemy_vertical : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    [SerializeField] private bool movingDown; // can make them start moving up on start or down
    private float highEdge;
    private float lowEdge;
    


    private void Awake()
    {
        highEdge = transform.position.y - movementDistance;
        lowEdge = transform.position.y + movementDistance;
    }

    private void Update()
    {
        //checking what direction its going
        if (movingDown)
        {
            if (transform.position.y > highEdge)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
            }
            else
            {
                movingDown = false;
            }
        }
        else
        {
            if (transform.position.y < lowEdge)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
            }
            else
            {
                movingDown = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }



}

