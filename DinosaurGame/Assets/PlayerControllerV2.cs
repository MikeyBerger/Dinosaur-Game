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

    //Delayed function that stops the dash movement
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
            StartCoroutine(StopDashing()); //Calls "StopDashing"
        }
        else if (IsDashing && !FacingRight)
        {
            RB.AddForce(new Vector2(DashSpeed, 0) * Time.deltaTime * -1);
            //RB.velocity = Vector2.zero;
            //IsDashing = false; //Stop dashing
            StartCoroutine(StopDashing()); //Calls "StopDashing"
        }

        Flip(); //Calls the Flip function
    }

    //Flips the player in the direction he's moving
    void Flip()
    {
        //Flips the player in the right direction
        if (Movement.x > 0 && !FacingRight || Movement.x < 0 && FacingRight)
        {
            FacingRight = !FacingRight; //"FacingRight" is false

            Vector3 Scale; //A Size
            Scale = transform.localScale; //The size above equals the size of the player

            Scale.x *= -1; //The player's scale is multiplied by -1, causing the player to change directions

            transform.localScale = Scale; //Sets the size to the direction above
        }
    }

    #region InputActions
    //Input for movement
    public void OnMove(InputAction.CallbackContext ctx)
    {
        Movement = ctx.ReadValue<Vector2>(); //Assigns a value to Movement
    }
    //Input for dashing
    public void OnDash(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            IsDashing = true;
        }
    }
    //Resets the High Score
    public void OnDeletePlayerPrefs(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            PlayerPrefs.DeleteAll(); //Deletes high score
        }
        #endregion
    }
}
