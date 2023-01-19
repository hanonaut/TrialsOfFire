using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private CharacterController mageCharacter;

    [SerializeField]
    private Camera eyes;

    [SerializeField]
    private float speed;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float mouse_x = Input.GetAxis("Mouse X");

        Vector3 move = transform.forward * vertical + transform.right * horizontal;

        mageCharacter.Move(move * speed * Time.deltaTime);
        transform.Rotate(0f, mouse_x, 0f);
    }
}
