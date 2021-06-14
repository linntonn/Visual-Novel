using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontalMove;
    Vector3 movement;
    public float speed;
    bool right;
    public Animator animator;
    public bool canMove;
    private SpriteRenderer mySpriteRenderer;

    public static PlayerMovement instance;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        speed *= Time.deltaTime;
        right = true;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
        if(!canMove)
        {
            horizontalMove = 0;
        }
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }

    void FixedUpdate()
    {
        if(horizontalMove > 0 && !right)
        {
            right = true;
            mySpriteRenderer.flipX = false;
        }
        else if(horizontalMove < 0 && right)
        {
            right = false;
            mySpriteRenderer.flipX = true;
        }
        movement = new Vector3(horizontalMove, 0f, 0f);
        movement *= speed;
        transform.position += movement;
    }

    public void toggleMove()
    {
        canMove = !canMove;
    }
}
