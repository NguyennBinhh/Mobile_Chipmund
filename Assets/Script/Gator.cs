using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gator : MonoBehaviour
{
    private Vector2 Start_Position; // Vecto lưu vị trí bắt đầu

    public float Move_Speed; // Tốc độ di chuyển

    public float Move_Space; // Khoảng cách di chuyển


    private void Start()
    {
        Move_Speed = 0.7f;
        Start_Position = transform.position;
    }

    void Update()
    {
        float New_Position_Y = Mathf.PingPong(Time.time * Move_Speed, Move_Space);
        transform.position = new Vector2(Start_Position.x, Start_Position.y + New_Position_Y);
    }
}
