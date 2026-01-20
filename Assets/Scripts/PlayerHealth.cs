using UnityEngine;
using System; // Cần thiết để dùng Action

public class PlayerHealth : MonoBehaviour
{
    // 1. Khai báo sự kiện (Events)
    // Sự kiện khi máu thay đổi (trả về máu hiện tại để UI cập nhật)
    public event Action<int> OnHealthChanged;
    
    // Sự kiện khi chết (không cần tham số)
    public event Action OnPlayerDeath;

    [Header("Settings")]
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        // Báo cáo trạng thái ban đầu ngay khi vào game
        OnHealthChanged?.Invoke(currentHealth);
    }

    void Update()
    {
        // Nhấn H để tự làm đau mình (Test)
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10);
        }
    }

    void TakeDamage(int damage)
    {
        if (currentHealth <= 0) return;

        currentHealth -= damage;
        Debug.Log($"Player bị đánh! Máu còn: {currentHealth}");

        // 2. Kích hoạt sự kiện (Notify Observers)
        // Dấu ? để kiểm tra null (có ai lắng nghe không)
        OnHealthChanged?.Invoke(currentHealth);

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player đã chết!");
        OnPlayerDeath?.Invoke();
        // Có thể disable player hoặc animation chết ở đây
    }
}