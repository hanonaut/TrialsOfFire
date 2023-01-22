using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    public SpellSO baseStats;

    public float effectivePotency;

    public virtual void CastSpell(Transform castPoint, float chargeRatio) 
    {
        SetEffectivePotency(chargeRatio);
        AudioManager.instance.Play("Spell Sound");
    }

    public virtual void SetEffectivePotency(float chargeRatio)
    {
        effectivePotency = baseStats.potency * chargeRatio;
    }
}
