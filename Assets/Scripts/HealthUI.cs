using UnityEngine;
using TMPro; // Nhớ dùng TextMeshPro

public class HealthUI : MonoBehaviour
{
    [Header("Dependencies")]
    public PlayerHealth playerHealth; // Kéo script PlayerHealth vào đây
    public TextMeshProUGUI healthText;

    // Đăng ký sự kiện khi Object bật
    void OnEnable()
    {
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged += UpdateHealthText;
        }
    }

    // Hủy đăng ký khi Object tắt (RẤT QUAN TRỌNG để tránh lỗi Memory Leak)
    void OnDisable()
    {
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged -= UpdateHealthText;
        }
    }

    // Hàm này phải khớp signature với Action<int>
    void UpdateHealthText(int currentHealth)
    {
        healthText.text = $"HP: {currentHealth}";
        
        // Đổi màu text dựa theo máu
        if (currentHealth < 30) healthText.color = Color.red;
        else healthText.color = Color.green;
    }
}