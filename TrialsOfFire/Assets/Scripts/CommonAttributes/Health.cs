using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHP, currentHP;

    /// <summary>
    /// Delegate for on health change event.
    /// </summary>
    /// <param name="amount">Amount changed by. Since damage is more common, negative values represent healing.</param>
    /// <param name="changedBy">The transform of the entity that caused the change.</param>
    public delegate void OnHealthChange(float amount, Transform changedBy = null);
    public event OnHealthChange onHealthChange;

    public void Damage(float amount, Transform dealtBy = null)
    {
        currentHP -= amount;
        if(currentHP < 0f)
        {
            currentHP = 0f;
        }
        if(onHealthChange != null)
            onHealthChange(amount, dealtBy);
    }
    public void Heal(float amount, Transform causedBy = null)
    {
        currentHP += amount;
        if(currentHP > maxHP) currentHP = maxHP;
        if (onHealthChange != null)
            onHealthChange(-amount, causedBy);
    }

    public bool Dead
    {
        get { return currentHP <= 0f; }
    }
}
