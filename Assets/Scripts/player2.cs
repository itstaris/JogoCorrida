using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class player2 : MonoBehaviour
{
    private Rigidbody2D rb; // Referência ao Rigidbody2D do jogador
    
    //movement
    public float maxSpeed;
    public float moveSpeed;
    public float acceleration;
    private Vector2 currentVelocity;

    //checkpoints
    public GameObject[] checkpoints;
    private int checkpointAtual = 0;
    private int laps = 0;

    //laps counter
    public TMP_Text lapsLabel;

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
        float moveX = 0f;
        float moveY = 0f;
        
        if (Input.GetKey(KeyCode.A)) moveX = -1f;
        if (Input.GetKey(KeyCode.D)) moveX = 1f;
        if (Input.GetKey(KeyCode.W)) moveY = 1f;
        if (Input.GetKey(KeyCode.S)) moveY = -1f;

        //vetor de direção
        Vector2 targetVelocity = new Vector2(moveX, moveY).normalized * moveSpeed;
        
        //aceleração gradual
        currentVelocity = Vector2.MoveTowards(currentVelocity, targetVelocity, acceleration * Time.deltaTime);
        
        //atualização da velocidade
        rb.velocity = currentVelocity;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == checkpoints[checkpointAtual])
        {

            checkpointAtual++;
            Debug.Log("passou por um checkpoint");

            // Se passou todos os checkpoints...
            if (checkpointAtual == checkpoints.Length)
            {
                // Volta completa!
                checkpointAtual = 1;
                Debug.Log("Volta completada!");
                laps++;
                Debug.Log(laps);
                lapsLabel.text = "Player 2: " + laps.ToString() + " laps";
            }
        }

    }
}
