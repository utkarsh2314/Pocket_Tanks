using System;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 10f;
    public GameObject projectilePrefab;

    public int playerNumber;
    public int score;

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal" + playerNumber);
        float verticalInput = Input.GetAxis("Vertical" + playerNumber);

        // Rotate the tank
        transform.Rotate(0f, horizontalInput * rotateSpeed * Time.deltaTime, 0f);

        // Move the tank
        transform.Translate(Vector3.forward * verticalInput * moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Fire" + playerNumber))
        {
            FireProjectile();
        }
    }

    private void FireProjectile()
    {
        // Instantiate a projectile
        GameObject projectile = Instantiate(projectilePrefab, transform.position + transform.forward, transform.rotation);

        // Apply force to the projectile
        Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();
        projectileRigidbody.AddForce(transform.forward * 1000f);
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Player " + playerNumber + " score: " + score);
    }
}

public class GameManager : MonoBehaviour
{
    public Tank player1Tank;
    public Tank player2Tank;

    private void Start()
    {
        // Initialize the game
        SetupTanks();
    }

    private void SetupTanks()
    {
        // Set the starting positions for the tanks
        player1Tank.transform.position = new Vector3(-5f, 0f, 0f);
        player2Tank.transform.position = new Vector3(5f, 0f, 0f);
    }

    public void EndGame()
    {
        // Compare the scores and display the winner
        if (player1Tank.score > player2Tank.score)
        {
            Debug.Log("Player 1 wins!");
        }
        else if (player1Tank.score < player2Tank.score)
        {
            Debug.Log("Player 2 wins!");
        }
        else
        {
            Debug.Log("It's a tie!");
        }

        // Restart the game or perform other actions as needed
    }
}

public class Projectile : MonoBehaviour
{
    public int damageAmount = 10;

    private void OnCollisionEnter(Collision collision)
    {
        // Check for collision with tanks or terrain
        if (collision.gameObject.CompareTag("Tank"))
        {
            Tank tank = collision.gameObject.GetComponent<Tank>();
            if (tank != null)
            {
                // Deal damage to the tank
            }
        }

        // Destroy the projectile
        Destroy(gameObject);
    }
}