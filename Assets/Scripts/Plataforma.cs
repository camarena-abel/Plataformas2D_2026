using Unity.VisualScripting;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    [SerializeField]
    float speed = 1f; // unidades/segundo

    Transform sprite;
    Transform puntoA;
    Transform puntoB;
    Rigidbody2D rb;

    bool adelante = true;

    void Start()
    {
        sprite = transform.Find("Sprite");
        rb = sprite.GetComponent<Rigidbody2D>();
        puntoA = transform.Find("PuntoA");
        puntoB = transform.Find("PuntoB");
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 diff;
        if (adelante)
        {
            diff = puntoB.position - sprite.position;
        } 
        else
        {
            diff = puntoA.position - sprite.position;
        }

        if (diff.magnitude < 0.01f)
        {
            adelante = !adelante;
        } 
        else
        {
            Vector2 dir = diff.normalized;
            Vector2 movimiento = dir * speed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + movimiento);
        }

    }
}
