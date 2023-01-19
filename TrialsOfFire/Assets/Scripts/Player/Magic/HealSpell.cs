using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealSpell : Spell
{
    public override void CastSpell(Transform castPoint, float chargeRatio)
    {
        base.CastSpell(castPoint, chargeRatio);
        Player.Instance.health.Heal(effectivePotency);
    }
}
