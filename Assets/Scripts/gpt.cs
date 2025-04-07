using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade máxima do movimento do jogador
    public float acceleration = 5f; // Aceleração do jogador
    public float maxSpeed = 5f; // Velocidade máxima que o jogador pode atingir

    private Rigidbody2D rb; // Referência ao Rigidbody2D do jogador
    private Vector2 currentVelocity; // A velocidade atual do jogador, usada para aplicar aceleração

    void Start()
    {
        // Obtém o Rigidbody2D associado ao player
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Captura os inputs para as teclas W (cima), A (esquerda), S (baixo) e D (direita)
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.W)) // Tecla W (para cima)
        {
            moveY = 1f;
        }
        if (Input.GetKey(KeyCode.S)) // Tecla S (para baixo)
        {
            moveY = -1f;
        }
        if (Input.GetKey(KeyCode.A)) // Tecla A (para esquerda)
        {
            moveX = -1f;
        }
        if (Input.GetKey(KeyCode.D)) // Tecla D (para direita)
        {
            moveX = 1f;
        }

        // Cria o vetor de direção
        Vector2 targetVelocity = new Vector2(moveX, moveY).normalized * moveSpeed;

        // Aplica a aceleração para alcançar a velocidade máxima gradualmente
        currentVelocity = Vector2.MoveTowards(currentVelocity, targetVelocity, acceleration * Time.deltaTime);

        // Atualiza a velocidade do Rigidbody2D
        rb.velocity = currentVelocity;
    }
}
