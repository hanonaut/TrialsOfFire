using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpell : Spell
{
    private bool fired;
    private string tagToHit;
    private Vector3 direction;

    private ProjectileSpellSO baseProjectile;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (fired)
        {
            transform.position += direction * baseProjectile.speed * Time.deltaTime;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == tagToHit)
        {
            // damage stuff
        }
        if (other.tag != "Spell")
        {
            Destroy(gameObject);
        }
    }

    public void Fire(Vector3 direction)
    {
        baseProjectile = baseStats as ProjectileSpellSO;
        fired = true;
        this.direction = direction;
    }

    public override void CastSpell(Transform castPoint)
    {
        ProjectileSpell spell = Instantiate(this, castPoint.position, castPoint.rotation).GetComponent<ProjectileSpell>();
        spell.Fire(Player.Instance.mainCamera.transform.forward);
    }

}
