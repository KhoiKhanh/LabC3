using UnityEngine;

public class VectorMovement : MonoBehaviour
{
    [Header("Settings")]
    public float moveSpeed = 5f;
    public bool useNormalization = true; // Tick vào để bật chuẩn hóa vector

    private Vector3 movementInput;

    void Update()
    {
        // 1. Lấy input từ bàn phím (WASD hoặc Arrow Keys)
        float horizontal = Input.GetAxisRaw("Horizontal"); // Trả về -1, 0, hoặc 1
        float vertical = Input.GetAxisRaw("Vertical");

        // 2. Tạo vector hướng di chuyển
        // Lưu ý: Dùng trục Z cho chuyển động tiến/lùi trong không gian 3D
        movementInput = new Vector3(horizontal, 0f, vertical);

        // 3. Xử lý chuẩn hóa (Normalize)
        if (useNormalization && movementInput.magnitude > 1f)
        {
            // .normalized trả về vector cùng hướng nhưng độ dài bằng 1
            movementInput = movementInput.normalized;
        }

        // 4. Di chuyển nhân vật
        // Nhân với Time.deltaTime để tốc độ không phụ thuộc vào FPS
        transform.Translate(movementInput * moveSpeed * Time.deltaTime, Space.World);
    }

    // 5. Vẽ Gizmos để hiển thị hướng di chuyển trong Scene view
    void OnDrawGizmos()
    {
        // Chỉ vẽ khi game đang chạy và có input
        if (Application.isPlaying && movementInput != Vector3.zero)
        {
            Gizmos.color = Color.yellow;
            
            // Vẽ tia từ vị trí nhân vật theo hướng di chuyển
            // Nhân thêm 2f để tia dài ra dễ nhìn
            Gizmos.DrawRay(transform.position, movementInput * 2f);
            
            // Vẽ thêm hình cầu ở đầu mút để dễ thấy hướng
            Gizmos.DrawWireSphere(transform.position + movementInput * 2f, 0.2f);
        }
    }
}