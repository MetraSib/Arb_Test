using UnityEngine;

public class PlayerController : MonoBehaviour

{
    [SerializeField] private float force;

    private Rigidbody2D playerRb;
    private Animator playerAnimator;

    private bool isOnGround = true;

    private static string ground = "Ground";
    private static string enemy = "Enemy";

    public static PlayerController Singleton { get; private set; }

    public delegate void PlayerDelegate();

    public event PlayerDelegate DieEvent;

    private void Awake()
    {
        Singleton = this;
    }

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
#if UNITY_EDITOR

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }

#endif

#if UNITY_ANDROID

        if (Input.touchCount > 0 && isOnGround)
        {
            Vector2 startPos=Vector2.zero;

            Vector2 finishPos=Vector2.zero;

            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    break;

                case TouchPhase.Ended:
                    finishPos = touch.position;

                    if (finishPos.y > startPos.y)
                    {
                        playerRb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
                    }
                    break;
            }
        }

#endif
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(ground))
        {
            isOnGround = true;
            playerAnimator.SetBool("IsJumping", false);
            playerAnimator.SetBool("IsRunning", true);
        }

        else if (collision.gameObject.CompareTag(enemy))
        {
            DieEvent?.Invoke();
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOnGround = false;
        playerAnimator.SetBool("IsJumping", true);
        playerAnimator.SetBool("IsRunning", false);
    }
}
