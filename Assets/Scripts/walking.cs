using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class walking : MonoBehaviour
{
    //Lo hago publico para poderlo modificar en el inspector del sprite
public float moveSpeed = 2f;
public float jump;
private float Move;
public Rigidbody2D rb;
public SpriteRenderer spriteRenderer;
public bool isJumping;
public Animator animator;
public UnityEvent myEventes;

    void Update()
    { 
    //Mover el Sprite horizontalmente
    Move = Input.GetAxis("Horizontal");
    rb.velocity = new Vector2(moveSpeed * Move, rb.velocity.y);

    //Voy a la variable Speed definida en el Animator Controler
    animator.SetFloat("Speed",Mathf.Abs(Move));
    Flip(Move);
    Jump();
    }

     //Flip el Sprite
    void Flip(float Mo)
    {
              if (Mo < 0)
      {
        spriteRenderer.flipX = true;
      }else if(Mo > 0 )
      {
        spriteRenderer.flipX = false;
      }
    }


    //Saltar com el Sprite
    void Jump()
    {
    if(Input.GetButtonDown("Jump") && isJumping == false)
    {
        rb.AddForce(new Vector2(rb.velocity.x,jump), ForceMode2D.Impulse);
    }
    }

    //Contacto con el entorno
    private void OnCollisionEnter2D(Collision2D other)
    {

        if(other.gameObject.CompareTag("piedra"))
        {
            animator = GetComponent<Animator>();
            animator.SetBool("muerto",true);

         }


        if(other.gameObject.CompareTag("suelo"))
        {
            isJumping = false;
        }
        
        
    }

        private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("suelo"))
        {
            isJumping = true;
        }
    }
}
