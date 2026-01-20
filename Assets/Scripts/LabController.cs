using UnityEngine;

public class LabController : MonoBehaviour
{
    public GameObject prefabToTest; // Kéo Prefab chứa LifecycleDebugger vào đây
    private GameObject currentInstance;

    void Update()
    {
        // Nhấn phím I để tạo Object (Instantiate)
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (currentInstance == null)
            {
                Debug.Log("--- BẮT ĐẦU INSTANTIATE ---");
                currentInstance = Instantiate(prefabToTest, Vector3.zero, Quaternion.identity);
                currentInstance.name = "TestObject_Clone";
            }
        }

        // Nhấn phím D để hủy Object (Destroy)
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (currentInstance != null)
            {
                Debug.Log("--- BẮT ĐẦU DESTROY ---");
                Destroy(currentInstance);
            }
        }
        
        // Nhấn phím Space để bật/tắt (Toggle Active)
        if (Input.GetKeyDown(KeyCode.Space))
        {
             if (currentInstance != null)
             {
                 bool isActive = currentInstance.activeSelf;
                 Debug.Log($"--- TOGGLE ACTIVE: {(!isActive)} ---");
                 currentInstance.SetActive(!isActive);
             }
        }
    }
}