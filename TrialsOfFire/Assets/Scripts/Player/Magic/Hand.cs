using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public Spell equipSpell;
    public bool isCharging = false;
    Transform castPoint;
    // Start is called before the first frame update
    void Start()
    {
        castPoint = Player.Instance.Magic.castPoint;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // called when button is no longer held
    public void OnRelease()
    {
        equipSpell.CastSpell(castPoint);
    }
}
