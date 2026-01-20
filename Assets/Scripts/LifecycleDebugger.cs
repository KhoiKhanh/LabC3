using UnityEngine;

public class LifecycleDebugger : MonoBehaviour
{
    // Dùng để lọc log Update vì nó chạy quá nhiều
    public bool showUpdateLogs = false;

    void Awake()
    {
        Debug.Log($"<color=green>[{gameObject.name}] Awake</color> - Được gọi khi script instance được tải.");
    }

    void OnEnable()
    {
        Debug.Log($"<color=cyan>[{gameObject.name}] OnEnable</color> - Được gọi khi object được enable.");
    }

    void Start()
    {
        Debug.Log($"<color=yellow>[{gameObject.name}] Start</color> - Được gọi trước frame update đầu tiên.");
    }

    void FixedUpdate()
    {
        if(showUpdateLogs)
            Debug.Log($"[{gameObject.name}] FixedUpdate - Chạy theo chu kỳ vật lý cố định.");
    }

    void Update()
    {
        if (showUpdateLogs)
            Debug.Log($"[{gameObject.name}] Update - Chạy mỗi frame.");
    }

    void LateUpdate()
    {
        if (showUpdateLogs)
            Debug.Log($"[{gameObject.name}] LateUpdate - Chạy sau khi Update hoàn tất.");
    }

    void OnDisable()
    {
        Debug.Log($"<color=orange>[{gameObject.name}] OnDisable</color> - Được gọi khi object bị disable.");
    }

    void OnDestroy()
    {
        Debug.Log($"<color=red>[{gameObject.name}] OnDestroy</color> - Được gọi khi object bị hủy hoàn toàn.");
    }
}