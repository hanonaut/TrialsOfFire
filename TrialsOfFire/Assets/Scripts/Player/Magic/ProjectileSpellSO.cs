using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Spell", menuName = "Spells/ProjectileSpell")]
public class ProjectileSpellSO : SpellSO
{
    /// <summary>
    /// How fast the projectile travels.
    /// </summary>
    public float speed;
}
