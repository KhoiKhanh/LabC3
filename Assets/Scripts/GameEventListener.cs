using UnityEngine;

public class GameEventListener : MonoBehaviour
{
    public PlayerHealth playerHealth;
    
    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip hurtSound;

    [Header("Game Over UI")]
    public GameObject gameOverPanel; // Panel hiện chữ Game Over

    void OnEnable()
    {
        if (playerHealth != null)
        {
            // Lắng nghe 2 sự kiện khác nhau
            playerHealth.OnHealthChanged += PlayHurtSound;
            playerHealth.OnPlayerDeath += HandleGameOver;
        }
    }

    void OnDisable()
    {
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged -= PlayHurtSound;
            playerHealth.OnPlayerDeath -= HandleGameOver;
        }
    }

    // Hàm xử lý âm thanh: Cần tham số int để khớp Action<int>, dù ta không dùng biến đó
    void PlayHurtSound(int health)
    {
        if (audioSource != null && hurtSound != null && health > 0)
        {
            audioSource.PlayOneShot(hurtSound);
        }
    }

    // Hàm xử lý Game Over
    void HandleGameOver()
    {
        Debug.Log("--- GAME OVER ---");
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); // Hiện bảng Game Over
        }
    }
}