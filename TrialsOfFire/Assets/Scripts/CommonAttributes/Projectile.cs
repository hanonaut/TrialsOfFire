using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public bool fired;
    private string tagToHit;
    private Vector3 direction;
    private float damage;
    private float speed;

    public void Fire(Vector3 direction, string targetTag, float dmg, float speed)
    {
        tagToHit = targetTag;
        fired = true;
        damage = dmg;
        this.speed = speed;
        this.direction = direction;
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);

    }

    void Update()
    {
        if (fired)
        {
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == tagToHit)
        {
            Health health = other.GetComponent<Health>();
            if (health != null)
            {
                health.Damage(damage);
            }
        }
        if (other.tag != "Projectile")
        {
            Destroy(gameObject);
        }
    }

    
}
