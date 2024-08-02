using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : MonoBehaviour
{
    private Vector2 Start_Position; // Vecto lưu vị trí bắt đầu

    public float Move_Speed; // Tốc độ di chuyển

    public float Move_Space; // Khoảng cách di chuyển

    private bool IsFacingRight;// Kiểm tra nhìn bên phải

    

    private void Start()
    {
        Move_Speed = 0.7f;
        Start_Position = transform.position;
    }

    void Update()
    {
        float New_Position_X = Mathf.PingPong(Time.time * Move_Speed, Move_Space);
        Vector2 New_Position = new Vector2(Start_Position.x + New_Position_X, Start_Position.y);
        if (New_Position.x > transform.position.x && !IsFacingRight)
        {
            IsFacingRight = true;
            transform.localScale = new Vector2(-1, 1);
        }
        else if (New_Position.x < transform.position.x && IsFacingRight)
        {
            IsFacingRight = false;
            transform.localScale = new Vector2(1, 1);
        }
        transform.position = New_Position;
    }   
}
