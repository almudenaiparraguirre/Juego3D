using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
	[SerializeField] float moveSpeed = 10;
	[SerializeField] float Jump = 5;
    bool isGrounded;
    [SerializeField] Transform cam;
    public LayerMask capaSuelo;

    // Start is called before the first frame update
    void Start()
	{
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update()
	{
        // Inputs
        float horInput = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float verInput = Input.GetAxisRaw("Vertical") * moveSpeed;

        // Verifica si el jugador está en el suelo
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f, capaSuelo);
        //Debug.Log("Is Grounded: " + isGrounded);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * Jump, ForceMode.Impulse);
        }

        // Camera dir
        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;

        camForward.y = 0;
        camRight.y = 0;

        // Creating relate cam direction
        Vector3 forwardRelative = verInput * camForward;
        Vector3 rightRelative = horInput * camRight;

        // Movement
        Vector3 moveDir = forwardRelative + rightRelative;
        rb.velocity = new Vector3(moveDir.x, rb.velocity.y, moveDir.z);

        transform.forward = new Vector3(rb.velocity.x, 0, rb.velocity.z);
    }
}
