using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private DetectorController detectorController;
    [SerializeField] private WallsController wallsController;
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float JumpForce;
    private bool DJump;
    private float Dirx;
    private Rigidbody2D Rigidbody2D;
    private BoxCollider2D BoxCollider2D;
    public GameObject Player;

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        BoxCollider2D = GetComponent<BoxCollider2D>();
        DJump = false;
    }

    private void OnEnable()
    {
        EventBus.Movements += MoveHorizontal;
        EventBus.Movements += Jump;
        EventBus.Movements += SlidingWalls;
        EventBus.Movements += Accelerate;
        EventBus.Movements += Crawling;
        EventBus.Movements += DoubleJump;

    }

    private void OnDisable()
    {
        EventBus.Movements -= MoveHorizontal;
        EventBus.Movements -= Jump;
        EventBus.Movements -= SlidingWalls;
        EventBus.Movements -= Accelerate;
        EventBus.Movements -= Crawling;
        EventBus.Movements -= DoubleJump;
    }


    private void MoveHorizontal()
    {
        Dirx = Input.GetAxisRaw("Horizontal");
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            Rigidbody2D.velocity = new Vector2(Dirx * MoveSpeed, Rigidbody2D.velocity.y);
        }
    } // Движение по горизонтали

    private void Jump()
    {
        if (detectorController)
        {
            if (Input.GetButtonDown("Jump") & !Input.GetKey(KeyCode.LeftControl))
            {
                Rigidbody2D.AddForce(Vector2.up * JumpForce);
                DJump = true;
            }
            if (Input.GetButtonDown("Jump") & Input.GetKey(KeyCode.LeftControl))
            {
                Rigidbody2D.AddForce(Vector2.up * JumpForce * 0.5f);

            }
        }
    } // Прыжок

    private void DoubleJump()
    {
        if (DJump & Input.GetButtonDown("Jump") & !detectorController.IsFlag)
        {
            Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, 0f);
            Rigidbody2D.AddForce(Vector2.up * JumpForce);
            DJump = false;
        }
    } // Двойной прыжок

    private void SlidingWalls()
    {
        if (Input.GetButton("Horizontal") && wallsController.WallsFlag)
        {
            Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, -0.5f);
        }
    } // Слайдинг по стенам

    private void Crawling()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.localScale = new Vector2(1f, 0.5f);
            Rigidbody2D.velocity = new Vector2(Dirx * MoveSpeed * 0.5f, Rigidbody2D.velocity.y);
            BoxCollider2D.size = new Vector2(1f, .5f);
        }
        else
        {
            BoxCollider2D.size = new Vector2(1f, 1f);
            transform.localScale = new Vector2(1f, 1f);
        }
    } // Ползание

    private void Accelerate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Rigidbody2D.velocity = new Vector2(Dirx * MoveSpeed * 2, Rigidbody2D.velocity.y);
        }
    } // Ускорение

}
