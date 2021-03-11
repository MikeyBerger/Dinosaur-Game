using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public bool IsDucking;
    public bool IsJumping;
    public bool IsGrounded;
    public float Timer;
    public float JumpForce;
    private Animator Anim;
    private Rigidbody2D RB;

    IEnumerator StopJumping()
    {
        yield return new WaitForSeconds(Timer);
        IsJumping = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animator>();
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDucking)
        {
            Anim.SetBool("IsDucking", true);
        }
        else
        {
            Anim.SetBool("IsDucking", false);
        }

        if (IsJumping)
        {
            RB.velocity = new Vector2(0, JumpForce * Time.deltaTime);
            //transform.Translate(0, JumpForce, 0);
            //RB.AddForce(new Vector2(0, JumpForce));
            Anim.SetBool("IsJumping", true);
            StartCoroutine(StopJumping());
        }
        else
        {
            Anim.SetBool("IsJumping", false);
        }
    }

    #region InputActions
    //Code for duck input
    public void OnDuck(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            IsDucking = true;
        }

        if (ctx.phase == InputActionPhase.Canceled)
        {
            IsDucking = false;
        }
    }

    //Code for jump input
    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            IsJumping = true;
        }
    }
    #endregion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsGrounded = true;
        IsJumping = false;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        IsGrounded = false;
        IsJumping = true;
    }
}
