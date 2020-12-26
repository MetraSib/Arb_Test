using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float force;

    private Rigidbody2D playerRb;
    private Animator playerAnimator;

    private bool isOnGround = true;

    private static string ground = "Ground";
    private static string enemy = "Enemy";

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround) 
        {
            playerRb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            playerAnimator.SetBool("IsRunning", true);
        }
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
