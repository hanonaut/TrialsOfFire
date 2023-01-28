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

    private bool canDash;
    public float dashTime;
    public float dashSpeed;
    public float dashDelay = 0.5f;
    private Vector3 moveDirection;



    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        canDash = true;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float mouse_x = Input.GetAxis("Mouse X");
		float mouse_y = Input.GetAxis("Mouse Y");

		Vector3 move = transform.forward * vertical + transform.right * horizontal;
        moveDirection = move;

        mageCharacter.Move(move * speed * Time.deltaTime);
        transform.Rotate(0f, mouse_x, 0f);
        eyes.transform.Rotate(-mouse_y, 0f, 0f);

        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash){
            StartCoroutine(Dash());
            StartCoroutine(ReloadDash());
        }
    }

    IEnumerator ReloadDash(){
        canDash = false;
        yield return new WaitForSeconds(dashDelay);
        canDash = true;

    }
    IEnumerator Dash()
    {
        float timer = 0f;
        while (timer < dashTime)
        {
            mageCharacter.Move(moveDirection.normalized * dashSpeed * Time.deltaTime);
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
