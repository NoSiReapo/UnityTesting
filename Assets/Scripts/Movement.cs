using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private DetectorController detectorController;
    [SerializeField] private WallsController wallsController;
    [SerializeField] public float MoveSpeed;
    [SerializeField] private float JumpForce;
    [SerializeField] private bool DJump;
    private float Dirx;
    private Rigidbody2D Rigidbody2D;
    private BoxCollider2D BoxCollider2D;
    public GameObject Player;
    public float xSize = 1f;
    public float ySize = 1f;

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
        EventBus.Movements += ScaleChange;

    }

    private void OnDisable()
    {
        EventBus.Movements -= MoveHorizontal;
        EventBus.Movements -= Jump;
        EventBus.Movements -= SlidingWalls;
        EventBus.Movements -= Accelerate;
        EventBus.Movements -= Crawling;
        EventBus.Movements -= DoubleJump;
        EventBus.Movements -= ScaleChange;
    }
    private void Update()
    {
        MoveHorizontal();
        Jump();
        DoubleJump();
        Crawling();
        Accelerate();
        SlidingWalls();
        ScaleChange();

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
            if (Input.GetButtonDown("Jump") & Input.GetKey(KeyCode.LeftControl) & !DJump)
            {
                Rigidbody2D.AddForce(Vector2.up * JumpForce * 0.5f);

            }
        }
        //if (DJump & Input.GetButtonDown("Jump") & !detectorController.IsFlag)
        //{
        //    Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, 0f);
        //    Rigidbody2D.AddForce(Vector2.up * JumpForce);
        //    DJump = false;
        //}
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
            transform.localScale = new Vector2(xSize, ySize * .5f);
            Rigidbody2D.velocity = new Vector2(Dirx * MoveSpeed * .5f, Rigidbody2D.velocity.y);
            BoxCollider2D.size = new Vector2(xSize, ySize * .5f);
        }
        else
        {
            BoxCollider2D.size = new Vector2(xSize, ySize);
            transform.localScale = new Vector2(xSize, ySize);
        }
    } // Ползание

    private void Accelerate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Rigidbody2D.velocity = new Vector2(Dirx * MoveSpeed * 2, Rigidbody2D.velocity.y);
        }
    } // Ускорение
    private void ScaleChange()
    {
        if (!Input.GetKey(KeyCode.LeftControl))
        {
            transform.localScale = new Vector2(xSize, ySize);
        }
    }
}
