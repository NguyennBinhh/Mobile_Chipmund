using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    public Rigidbody2D Player_Rb; 

    public float Player_Speed; // Tốc độ của người chơi

    public float Player_PowerJump; // Lực nhảy

    public Animator Player_Anim; // Điều khiển chuyển động của người chơi

    public Transform Ground_Contact; // Kiểm tra người chơi có chạm đất 

    public LayerMask Ground; // Khai báo Game Object có kiểu layer là "Ground"

    private float Check_Move; // Kiểm tra hướng di chuyển của người chơi

    private bool IsFacingRight;// Kiểm tra người chơi có xoay bên phải không

    private bool Check_Jump; // Kiểm tra người chơi có chạm layer tên "Ground", nếu có cho phép người chơi nhảy

    public bool Jump_PointerDown; // Kiểm tra nút nhảy có được nhấn không

    private bool Double_Jump; // Kiểm tra điều kiện người chơi thực hiện nhảy đôi

    private void Start()
    {
        Player_Speed = 2f;
        IsFacingRight = true;
        Player_PowerJump = 3.5f;
    }

    private void Update()
    {
        Move();
        Player_Jump();
        Player_Anim.SetFloat("Move",Mathf.Abs(Check_Move));
    }

    private void Move()
    {
        Player_Rb.velocity = new Vector2(Player_Speed * Check_Move, Player_Rb.velocity.y);
    }

    public void MoveLeft()
    {
        Check_Move = -1;
        if (IsFacingRight == true)
        {
            Player_Rb.transform.localScale = new Vector3(-1,1,1);
            IsFacingRight = false;
        }
    }

    public void MoveRight()
    {
        Check_Move = 1;
        if (IsFacingRight == false)
        {
            Player_Rb.transform.localScale = new Vector3(1, 1, 1);
            IsFacingRight = true;
        }
    }

    public void Player_Idle()
    {
        Check_Move = 0;
    }

    public void Player_Jump()
    {
        Check_Jump = Physics2D.OverlapCircle(Ground_Contact.position, 0.2f, Ground);
        if (Check_Jump && !Jump_PointerDown)
        {
            Double_Jump = false; 
        }
        Player_Anim.SetBool("Jump", Check_Jump);
        if (Jump_PointerDown)
        {
            if (Check_Jump || !Double_Jump)
            {
                Player_Rb.velocity = new Vector2(Player_Rb.velocity.x, Player_PowerJump);
                Audio_Manage.Instance.Play_SFX("Jump");
                if (!Check_Jump)
                {
                    Double_Jump = true; 
                }
                Jump_PointerDown = false;
            }
        }
    }
      
    public void Player_Jump_PointerDown()
    {
        Jump_PointerDown = true;
    }

    public void Player_Jump_PointerUp()
    {
        Jump_PointerDown = false;
    }
}
