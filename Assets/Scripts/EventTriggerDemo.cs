using UnityEngine;
using UnityEngine.Events; // Bắt buộc phải có để dùng UnityEvent

public class EventTriggerDemo : MonoBehaviour
{
    // Khai báo UnityEvent sẽ hiện ra trong Inspector
    [Header("Sự kiện tùy chỉnh")]
    public UnityEvent onSpacePressed;

    void Update()
    {
        // Khi nhấn Space, kích hoạt tất cả các hàm đã gắn trong Inspector
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Đã nhấn Space -> Kích hoạt UnityEvent!");
            onSpacePressed?.Invoke();
        }
    }
}