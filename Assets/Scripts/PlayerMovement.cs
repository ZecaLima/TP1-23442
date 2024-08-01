using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    bool alive = true;

    public float speed = 5;
    public Rigidbody rb;

    float horizontalInput;
    public float HorizontalMultiplier = 2;

    public float speedIncreasePerPoint = 0.1f;

    // FixedUpdate é chamado em tempos fixos de intervalos, no caso, 50 vezes por segundo
    private void FixedUpdate()
    {
        if(!alive) return;

        Vector3 foewardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * HorizontalMultiplier;
        rb.MovePosition(rb.position + foewardMove + horizontalMove);
    }

    // Update is called once per frame
    private void Update()
    {
        // Controlos defaut, setas ou a e d
        horizontalInput = Input.GetAxis("Horizontal");

        // Se o jogador cair, morre
        if(transform.position.y < -2)
        {
            Die();
        }
    }

    public void Die()
    {
        alive = false;

        // Game Over, recomeçar o jogo depois de 2 segundos
        Invoke("Restart", 2);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
