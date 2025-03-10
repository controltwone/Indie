using Unity.Mathematics;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovementScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public float moveSpeed = 5;
    public float jumpForce = 5f;
    bool isGrounded ;
    public Vector3 firstPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        firstPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localScale.x > 0 && Input.GetAxis("Horizontal") < 0)
        {
            FlipFace();
        }
        else if(transform.localScale.x < 0 && Input.GetAxis("Horizontal") > 0)
        {
            FlipFace();
        }

        HorizontalMove();
        
        if(Input.GetAxis("Vertical")> 0 && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
            isGrounded = false;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            restartPlayer();

        }
        
    }

    void HorizontalMove(){
        rb.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.linearVelocityY);
        anim.SetFloat("playerSpeed" , Mathf.Abs(rb.linearVelocityX));

    }
    
     void FlipFace()
     {
         Vector3 scaleX = transform.localScale;
            scaleX.x *= -1;
            transform.localScale = scaleX;
     }

     // Karakterin zeminde olup olmadığını kontrol et
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("Jump", isGrounded);
            Debug.Log("yerde");
            
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
         if (collision.gameObject.CompareTag("Ground"))
    {
        isGrounded = false;
        anim.SetBool("Jump", isGrounded);
        Debug.Log("havada");
    }
    }

    void restartPlayer()
    {
        transform.position = firstPosition; // Karakteri başlangıç konumuna taşı
        // rb.linearVelocity = Vector2.zero; // Hızı sıfırla, yoksa karakter uçabilir!
        Debug.Log("Karakter respawn oldu!");
    }
        
    
}
