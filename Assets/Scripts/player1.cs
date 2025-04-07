using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1 : MonoBehaviour
{
    private Rigidbody2D rb; // Referência ao Rigidbody2D do jogador
    public float maxSpeed;
    public float moveSpeed;
    public float acceleration;
    private Vector2 currentVelocity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        
        //vetor de direção
        Vector2 targetVelocity = new Vector2(moveX, moveY).normalized * moveSpeed;
        
        //aceleração gradual
        currentVelocity = Vector2.MoveTowards(currentVelocity, targetVelocity, acceleration * Time.deltaTime);
        
        //atualização da velocidade
        rb.velocity = currentVelocity;
    }
}
