using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerV2 : MonoBehaviour
{
    Vector2 Movement; //Vector for player movement
    public float Speed; //Movement speed
    public float DashSpeed; //Dash speed
    public float DashTimer; //Dash cooldown
    public bool IsDashing; //Boolean variable to indicate a dash
    public bool FacingRight = true; //Indicates whether the player is facing right or not
    private Rigidbody2D RB; //Allows player to collide
    //private Animator Anim;

    IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(DashTimer);
        RB.velocity = Vector2.zero;
        IsDashing = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>(); //Assigns a value to RB
    }

    // Update is called once per frame
    void Update()
    {
        RB.velocity = new Vector2(Movement.x, 0) * Time.deltaTime * Speed; //Movement code

        if (IsDashing && FacingRight)
        {
            RB.AddForce(new Vector2(DashSpeed, 0) * Time.deltaTime); //Dash to the right
            //RB.velocity = Vector2.zero;
            //IsDashing = false; //Stop dashing
            StartCoroutine(StopDashing());
        }
        else if (IsDashing && !FacingRight)
        {
            RB.AddForce(new Vector2(DashSpeed, 0) * Time.deltaTime * -1);
            //RB.velocity = Vector2.zero;
            //IsDashing = false; //Stop dashing
            StartCoroutine(StopDashing());
        }

        Flip(); //Calls the Flip function
    }

    //Flips the player in the direction he's moving
    void Flip()
    {
        //Flips the player in the right direction
        if (Movement.x > 0 && !FacingRight || Movement.x < 0 && FacingRight)
        {
            FacingRight = !FacingRight;

            Vector3 Scale;
            Scale = transform.localScale;

            Scale.x *= -1;

            transform.localScale = Scale;
        }
    }

    #region InputActions
    //Input for movement
    public void OnMove(InputAction.CallbackContext ctx)
    {
        Movement = ctx.ReadValue<Vector2>();
    }
    //Input for dashing
    public void OnDash(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            IsDashing = true;
        }
    }
    #endregion
}
