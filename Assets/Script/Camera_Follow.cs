using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform Player;

    [Range(0, 1)]
    public float Smooth_Time; // Điều chỉnh độ trễ của Camera khi di chuyển theo Player

    public Vector3 Position_Offset;

    Vector3 Velocity = Vector3.zero;

    [Header ("Map Limits")] // Điều chỉnh giới hạn bản đồ
    public Vector2 X_Limit;
    public Vector2 Y_Limit;

    private void LateUpdate()
    {
        Vector3 Target_Position = Player.position + Position_Offset;
        Target_Position = new Vector3(Mathf.Clamp(Target_Position.x, X_Limit.x, X_Limit.y), Mathf.Clamp(Target_Position.y, Y_Limit.x, Y_Limit.y), -10);
        transform.position = Vector3.SmoothDamp(transform.position, Target_Position, ref Velocity, Smooth_Time);
    }


}
