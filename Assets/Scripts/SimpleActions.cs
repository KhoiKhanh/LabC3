using UnityEngine;

public class SimpleActions : MonoBehaviour
{
    // Hàm 1: Đổi màu ngẫu nhiên
    public void ChangeRandomColor()
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV();
    }

    // Hàm 2: Phóng to vật thể
    public void ScaleUp()
    {
        transform.localScale *= 1.2f;
    }

    // Hàm 3: Reset kích thước
    public void ResetScale()
    {
        transform.localScale = Vector3.one;
    }
}