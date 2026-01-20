using UnityEngine;
using TMPro; // Thư viện cho TextMeshPro

public class SignedAngleRotator : MonoBehaviour
{
    [Header("UI References")]
    public TextMeshProUGUI angleDisplay; // Kéo UI Text vào đây

    [Header("Settings")]
    public float rotationSpeed = 5f;
    public bool useMouseAsTarget = true;
    public Transform manualTarget; // Dùng cái này nếu không muốn dùng chuột

    void Update()
    {
        Vector3 targetPosition = Vector3.zero;

        // 1. Xác định vị trí mục tiêu (Chuột hoặc Object)
        if (useMouseAsTarget)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                targetPosition = hit.point;
            }
        }
        else if (manualTarget != null)
        {
            targetPosition = manualTarget.position;
        }

        // Giữ độ cao y bằng nhau để tính góc phẳng (Top-down)
        targetPosition.y = transform.position.y;

        // 2. Tính Vector hướng tới mục tiêu
        Vector3 directionToTarget = targetPosition - transform.position;

        // 3. Tính SignedAngle (Cốt lõi của bài Lab)
        // Tham số: (Hướng mặt hiện tại, Hướng muốn tới, Trục xoay)
        float angle = Vector3.SignedAngle(transform.forward, directionToTarget, Vector3.up);

        // 4. Hiển thị lên UI
        if (angleDisplay != null)
        {
            angleDisplay.text = $"Angle: {angle:F1}°";
            
            // Đổi màu chữ: Trái (Âm) = Đỏ, Phải (Dương) = Xanh
            angleDisplay.color = angle < 0 ? Color.red : Color.green;
        }

        // 5. Xoay nhân vật dựa trên góc tính được
        // Nếu góc > 0: Cần xoay phải. Góc < 0: Cần xoay trái.
        // Dùng chính giá trị angle để làm tốc độ xoay -> Càng gần càng chậm (Ease-out)
        transform.Rotate(Vector3.up, angle * rotationSpeed * Time.deltaTime);
    }

    // Vẽ Gizmos để dễ hình dung trong Scene
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.forward * 3f); // Hướng mặt

        if (Application.isPlaying) 
        {
            // Vẽ hướng tới chuột (chỉ vẽ khi Play)
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 targetPos = hit.point;
                targetPos.y = transform.position.y;
                
                Gizmos.color = Color.yellow;
                Gizmos.DrawLine(transform.position, targetPos);
            }
        }
    }
}