using UnityEngine;

public class Fireball : MonoBehaviour 
{
    [SerializeField]private float speed;
    private bool hit;
    private float direction;

    private Animator anim;
    private BoxCollider2D boxCollider;

    private float lifeTime;

    private void Awake()
    {
        anim = GetComponent<Animator>();    
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (hit) { return; }
        float movementspeed = Time.deltaTime * speed * direction;
        transform.Translate(movementspeed, 0, 0);

        lifeTime += Time.deltaTime;

        if (lifeTime > 7) { 
        gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("explode");
    }

    public void SetDirection(float _direction) {
        lifeTime = 0;
        direction = _direction;

        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;

        if (Mathf.Sign(localScaleX) != _direction) 
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate() { 
        gameObject.SetActive(false);   

    }
}
