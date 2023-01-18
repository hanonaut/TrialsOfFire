using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    public SpellSO baseStats;

    public abstract void CastSpell(Transform castPoint);
}
