using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField]
    float jumpForce = 10f;
    [SerializeField]
    float moveForce = 10f;

    [SerializeField]
    Transform groundTest;

    [SerializeField]
    LayerMask groundMask;

    [SerializeField]
    float groundTestRadius;

    Rigidbody2D rb;
    Vector2 moveAxis;
    bool doJump;
    InputAction move;
    InputAction jump;

    // Esto se ejecuta al crear el objeto
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        move = InputSystem.actions.FindAction("Move");
        jump = InputSystem.actions.FindAction("Jump");
    }

    // Esto se ejecuta cada fotograma, lo ideal aqui es recoger el input del usuario
    void Update()
    {
        moveAxis = move.ReadValue<Vector2>();
        if (jump.WasPressedThisFrame())
        {
            if (Physics2D.OverlapCircle(groundTest.position, groundTestRadius, groundMask))
            {
                doJump = true;
            }            
        }
    }

    // Esto se ejecuta en cada fotograma de fisica
    private void FixedUpdate()
    {
        rb.AddForceX(moveAxis.x * moveForce);
        //rb.linearVelocityX = moveAxis.x * moveForce;

        if (doJump)
        {
            rb.AddForceY(jumpForce, ForceMode2D.Impulse);
            doJump = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(groundTest.position, groundTestRadius);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject moneda = collision.gameObject.transform.parent.gameObject;
        if (moneda.tag == "Coin")
        {
            Destroy(moneda);
        }
    }

    //if (jump.WasPressedThisFrame())
    //    print("Salto pulsado");

    //if (jump.WasReleasedThisFrame())
    //    print("Salto soltado");

    //if (jump.IsPressed())
    //    print("Se esta pulsando el botón de salto");
}
