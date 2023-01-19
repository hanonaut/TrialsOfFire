using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpell : Spell
{
    protected ProjectileSpellSO baseProjectile;
    [SerializeField] protected Projectile projectile;

    public override void CastSpell(Transform castPoint, float chargeRatio)
    {
        base.CastSpell(castPoint, chargeRatio);
        ProjectileSpell spell = Instantiate(this, castPoint.position, castPoint.rotation).GetComponent<ProjectileSpell>();
        spell.SetEffectivePotency(chargeRatio);
        spell.baseProjectile = baseStats as ProjectileSpellSO;
        spell.projectile.Fire(Player.Instance.mainCamera.transform.forward, "Enemy", spell.effectivePotency, spell.baseProjectile.speed);
    }

}
