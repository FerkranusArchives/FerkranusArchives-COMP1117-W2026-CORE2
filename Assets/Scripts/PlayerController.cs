using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float initialSpeed = 5;
    [SerializeField] private int initialHealth = 100;

    public Slider healthBar;
    private PlayerStats stats;
    private Vector2 moveInput;

    // Components
    private Rigidbody2D rBody;

    void Awake()
    {
        // Initialize
        rBody = GetComponent<Rigidbody2D>();
        

        stats = new PlayerStats(initialSpeed, initialHealth);
        stats = new PlayerStats();
        stats.MoveSpeed = initialSpeed;
        stats.MaxHealth = initialHealth;
        stats.CurrentHealth = initialHealth;
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        ApplyMovement();
        healthBar.value = stats.CurrentHealth;
        if (healthBar.value <= 0) { healthBar.image.color = Color.clear; }
        else if (healthBar.value <= 50 && healthBar.value > 0)
        {
            healthBar.image.color = Color.red;
        }
        
        if (stats.IsDead)
        {
            Debug.Log("Player has perished.");
        }
    }


    private void ApplyMovement()
    {
        float velocityX = moveInput.x * stats.MoveSpeed;

        rBody.linearVelocity = new Vector2(velocityX, rBody.linearVelocity.y);
    }

    public void TakeDamage(int damageAmount)
    {
        stats.CurrentHealth -= damageAmount;
        Debug.Log($"Player took damage. Health left: {stats.CurrentHealth}");
    }

    }
