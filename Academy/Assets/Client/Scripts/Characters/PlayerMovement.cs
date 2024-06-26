using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] Animator anim;
    [SerializeField] float moveSpeed;

    [SerializeField] float x, y;

    private Vector2 input;
    private bool moving;

    [SerializeField] VectorValue position;

    [SerializeField] GameObject dialogueWindow;
    [SerializeField] GameObject skipAnim;

    private void Start()
    {
        transform.position = position.initialValue;
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(dialogueWindow.activeInHierarchy || skipAnim.activeInHierarchy || moveSpeed <= 0 )
        {
            input = Vector2.zero;
            Animate();
        }
        else
        {
            GetInput();
            Animate();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = input * moveSpeed;
    }

    private void GetInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        input = new Vector2(x, y);
        input.Normalize();
    }

    private void Animate()
    {
        if(input.magnitude > 0.1f || input.magnitude < - 0.1f)
            moving = true;
        else
            moving = false;

        if(moving)
        {
            anim.SetFloat("X", x);
            anim.SetFloat("Y", y);
        }

        anim.SetBool("IsMoving", moving);
    }
}
