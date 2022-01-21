using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _player : MonoBehaviour
{
    float playerMoveSpeed, playerJumpVelocity, playerScore;

    bool playerIsGrounded;

    public _gameManager gameManagerReference;

    void Start()
    {
        playerScore = 0f;

        playerMoveSpeed = 5f;
        playerJumpVelocity = 3.5f;
    }

    void Update()
    {
        m_playerControl();
        //print(playerScore);
    }

    void m_playerControl()
    {
        if(Input.GetKey(KeyCode.A))
        {
            this.transform.Translate(Vector2.left * playerMoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(Vector2.right * playerMoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            if(playerIsGrounded)
            {
                this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerJumpVelocity , ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.name == "enemyBullet" || collision.collider.tag == "enemyBullet")
        {
            gameManagerReference.m_gameOver();
        }

        if(collision.collider.tag == "lavaBoard")
        {
            gameManagerReference.m_gameOver();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.name == "Ground" || collision.collider.tag == "Platform")
        {
            playerIsGrounded = true;
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
            playerIsGrounded = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Coin")
        {
            collision.gameObject.SetActive(false);
            gameManagerReference.m_updateScore(10f);
        }
    }
}
