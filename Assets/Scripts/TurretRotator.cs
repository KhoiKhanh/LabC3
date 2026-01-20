using UnityEngine;

public class TurretRotator : MonoBehaviour
{
    // Enum để tạo dropdown list trong Inspector
    public enum RotationMode
    {
        Instant_LookAt,      // Xoay ngay lập tức
        Smooth_RotateTowards, // Xoay đều (cơ khí/robot)
        Smooth_Slerp        // Xoay mượt (có giảm tốc khi gần đích)
    }

    [Header("Settings")]
    public Transform target;          // Kéo object Target vào đây
    public RotationMode currentMode;  // Chọn chế độ xoay
    public float rotationSpeed = 90f; // Tốc độ xoay (độ/giây) cho RotateTowards
    public float slerpSpeed = 5f;     // Tốc độ nội suy cho Slerp (thấp hơn vì tính theo t)

    void Update()
    {
        // Nếu không có target thì không làm gì cả
        if (target == null) return;

        // 1. Tính toán vector hướng từ Turret đến Target
        Vector3 directionToTarget = target.position - transform.position;

        // Xử lý riêng từng chế độ
        switch (currentMode)
        {
            case RotationMode.Instant_LookAt:
                // CÁCH 1: LookAt (Xoay ngay lập tức)
                // Nhược điểm: Giật cục, không có quán tính
                transform.LookAt(target); 
                break;

            case RotationMode.Smooth_RotateTowards:
                // CÁCH 2: RotateTowards (Xoay đều đặn)
                // Ưu điểm: Tốc độ không đổi, giống chuyển động cơ khí thực tế
                if (directionToTarget != Vector3.zero)
                {
                    // Tính góc quay đích đến (Quaternion)
                    Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
                    
                    // Xoay từng bước về phía đích
                    transform.rotation = Quaternion.RotateTowards(
                        transform.rotation, 
                        targetRotation, 
                        rotationSpeed * Time.deltaTime
                    );
                }
                break;

            case RotationMode.Smooth_Slerp:
                // CÁCH 3: Slerp (Spherical Linear Interpolation)
                // Ưu điểm: Mượt mà, nhanh ở đầu và chậm dần khi tới đích
                if (directionToTarget != Vector3.zero)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
                    
                    // Nội suy giữa góc hiện tại và góc đích
                    transform.rotation = Quaternion.Slerp(
                        transform.rotation, 
                        targetRotation, 
                        slerpSpeed * Time.deltaTime
                    );
                }
                break;
        }
    }

    // Vẽ đường line để dễ debug trong Scene view
    void OnDrawGizmos()
    {
        if (target != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, target.position);
        }
        
        // Vẽ tia hướng mặt của Turret (trục Z xanh dương)
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, transform.forward * 3f);
    }
}