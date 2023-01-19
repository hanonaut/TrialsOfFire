using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public string leftOrRight;
    public Spell equipSpell;
    public bool isCharging = false;
    public bool delaying = false;
    Transform castPoint;

    public float chargeTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        castPoint = Player.Instance.Magic.castPoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (!delaying && isCharging)
        {
            chargeTime += Time.deltaTime;
            if (chargeTime > equipSpell.baseStats.chargeTime)
            {
                chargeTime = equipSpell.baseStats.chargeTime;
            }
            if(leftOrRight == "Right")
            {
                HUDController.instance.UpdateRightCharge();
            }
            if (leftOrRight == "Left")
            {
                HUDController.instance.UpdateLeftCharge();
            }
        }
        if (delaying)
        {
            chargeTime = 0f;
        }
    }

    // called when button is no longer held
    public void OnRelease()
    {
        isCharging = false;
        if (delaying) return;
        float chargeRatio = chargeTime / equipSpell.baseStats.chargeTime;
        if(chargeRatio < 0.15f) 
        {
            chargeRatio = 0.15f; // minimum potency ratio
        }

        equipSpell.CastSpell(castPoint, chargeRatio);
        chargeTime = 0f;
        HUDController.instance.UpdateHUD();
        StartCoroutine(Delaying());
    }

    IEnumerator Delaying()
    {
        delaying = true;
        yield return new WaitForSeconds(equipSpell.baseStats.chargeDelay);
        delaying = false;
    }

    public void OnPress()
    {
        isCharging = true;
    }
}
