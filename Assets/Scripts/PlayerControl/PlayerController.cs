using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    
    private Rigidbody2D rb;
    private Vector2 moveDirection;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0f; // Отключаем гравитацию для движения в 2D пространстве
        }
    }
    
    private void Update()
    {
        // Получаем ввод от клавиш WASD через Input Manager
        float horizontalInput = Input.GetAxisRaw("Horizontal"); // A и D
        float verticalInput = Input.GetAxisRaw("Vertical");     // W и S
        
        // Создаем вектор направления движения
        moveDirection = new Vector2(horizontalInput, verticalInput).normalized;
    }
    
    private void FixedUpdate()
    {
        // Перемещаем персонажа физически в FixedUpdate для более стабильной физики
        rb.linearVelocity = moveDirection * moveSpeed;
    }
}
