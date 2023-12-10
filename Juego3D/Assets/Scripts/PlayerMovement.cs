using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
	[SerializeField] float moveSpeed = 10;
	[SerializeField] float Jump = 5f;
    bool isGrounded;
    [SerializeField] Transform cam;
    public LayerMask capaSuelo;
    private Vector3 puntoReaparicion;
    private bool juegoGanado = false;

    // Start is called before the first frame update
    void Start()
	{
        isGrounded = false;
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update()
	{
        // Inputs
        float horInput = Input.GetAxisRaw("Horizontal") * moveSpeed;
        float verInput = Input.GetAxisRaw("Vertical") * moveSpeed;        

        if (transform.position.y < -2)
        {
            RestablecerPosicion();
        }

        saltar();
        ganar();

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

    private void RestablecerPosicion()
    {
        transform.SetPositionAndRotation(RestablecerPuntoPosicion(), Quaternion.Euler(0, 0, 0));
    }

    private Vector3 RestablecerPuntoPosicion()
    {
        if (transform.position.z <= 111 || juegoGanado == true)
        {
            puntoReaparicion = new Vector3(3.655f, 3.8f, 0.41f);
            juegoGanado = false;
        }
        else if (transform.position.z > 111)
        {
            puntoReaparicion = new Vector3(0.73f, 3.8f, 111.1f);
        }

        return puntoReaparicion;
    }

    private void saltar()
    {
        Vector3 suelo = transform.TransformDirection(Vector3.down);

        if (Physics.Raycast(transform.position, suelo, 1.03f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(0, Jump, 0), ForceMode.Impulse);
        }
    }

    private void ganar()
    {
        if (transform.position.z >= 212 && transform.position.z <= 222)
        {
            SceneManager.LoadScene("JuegoGanado");
            juegoGanado = true;
        }
    }
}
