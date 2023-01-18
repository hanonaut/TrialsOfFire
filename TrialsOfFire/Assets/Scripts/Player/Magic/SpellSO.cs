using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spells/BaseSpell")]
public class SpellSO : ScriptableObject
{
    /// <summary>
    /// Mana cost of the spell.
    /// </summary>
    public float cost;
    /// <summary>
    /// How long it takes to prepare the spell.
    /// </summary>
    public float chargeTime;
    /// <summary>
    /// The time between casts.
    /// </summary>
    public float chargeDelay;
    /// <summary>
    /// Base potency of spell. This should effect damage, healing, or buff/debuff strength.
    /// </summary>
    public float potency;
}
