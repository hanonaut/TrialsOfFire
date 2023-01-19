using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public static HUDController instance;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than one instance of HUDController");
        }
        instance = this;
    }

    [SerializeField] Slider rightCharge;
    [SerializeField] Slider leftCharge;



    // Start is called before the first frame update
    void Start()
    {
        UpdateHUD();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void UpdateHUD()
    {
        UpdateRightCharge();
        UpdateLeftCharge();
    }

    public void UpdateRightCharge()
    {
        Hand hand = Player.Instance.Magic.rightHand;
        rightCharge.maxValue = hand.equipSpell.baseStats.chargeTime;
        rightCharge.value = hand.chargeTime;
    }
    public void UpdateLeftCharge()
    {
        Hand hand = Player.Instance.Magic.leftHand;
        leftCharge.maxValue = hand.equipSpell.baseStats.chargeTime;
        leftCharge.value = hand.chargeTime;
    }


}
