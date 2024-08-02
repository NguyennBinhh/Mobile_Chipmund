using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Backgr_Move : MonoBehaviour
{
  
    public Transform Back_Ground1;
    public Transform Back_Ground2;
    public float Speed = 2f;
    public float End_X;

    private Vector2 Start_Position1;
    private Vector2 Start_Position2;

    void Start()
    {
        Start_Position1 = Back_Ground1.transform.position;
        Start_Position2 = Back_Ground2.transform.position;
    }

    void Update()
    {
        Back_Ground1.position = new Vector2(Back_Ground1.position.x - Speed * Time.deltaTime, Back_Ground1.position.y);
        Back_Ground2.position = new Vector2(Back_Ground2.position.x - Speed * Time.deltaTime, Back_Ground2.position.y);
        if (Back_Ground1.position.x <= End_X)
        {
            Back_Ground1.position = Start_Position2;
        }
        if (Back_Ground2.position.x <= End_X)
        {
            Back_Ground2.position = Start_Position2;
        }
    }
}
