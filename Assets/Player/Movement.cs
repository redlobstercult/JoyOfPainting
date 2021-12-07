using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    
    float horiz;
    float vert;
    [SerializeField] float _speed = 1f;
    [SerializeField] float _howHigh = 20f;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] SpriteRenderer shadowSpriteRenderer;
    private Vector2 movementVector;
    public AnimationCurve jumpCurve;
        
    bool _jumping = false;
    bool faceRight;
    
    BoxCollider2D _boxCollider;
    Vector2 jumpVelocity = new Vector2(10, 0);
    float jumpHeightScale = 2.0f;
    float jumpPushScale = 2.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        _boxCollider = GetComponent<BoxCollider2D>();
        
        
    }

    
    void Update()
    {
        WhichWayYouMovingDawg();
        
        if (Input.GetButtonDown("Jump")) 
            Jump(jumpHeightScale, jumpPushScale);
       
        ChangeDirection();
        
    }
    private void FixedUpdate()
    {

        Move();
        
    }

    private void Move()
    {
       
        movementVector.x = horiz * Time.fixedDeltaTime;
        movementVector.y = vert * Time.fixedDeltaTime;
        
        rb.MovePosition(rb.position + movementVector);
        Vector3 imSureTheresaBetterWayToDoThis = transform.position;
        imSureTheresaBetterWayToDoThis.x = Mathf.Clamp(transform.position.x, -8.5f, 8.5f);

        imSureTheresaBetterWayToDoThis.y = Mathf.Clamp(transform.position.y, -7.5f, 9);
        transform.position = imSureTheresaBetterWayToDoThis;




    }
    

    void WhichWayYouMovingDawg()
    {
        horiz = Input.GetAxis("Horizontal") * _speed;
        vert = Input.GetAxis("Vertical") * _speed;
        
    }

    void ChangeDirection() {
        if (horiz > 0 && faceRight == true)
        {
            transform.Rotate(0, 180, 0);
            faceRight = false;
            
        }
        else if (horiz < 0 && faceRight == false) {
            transform.Rotate(0, 180, 0);
            faceRight = true;
        }
       
    }

    void Jump(float jumpHeightScale, float jumpPushScale)
    {
        if (!_jumping)
            StartCoroutine(JumpCo(jumpHeightScale, jumpPushScale));
           
    }

    /* ###############################################################################################################################################
     
     Algorithm used in JumpCo taken from: Pretty Fly Games: https://www.youtube.com/watch?v=wrMaEG14BOg&list=PLyDa4NP_nvPfmvbC-eqyzdhOXeCyhToko&index=4

    ################################################################################################################################################ */
    private IEnumerator JumpCo(float jumpHeightScale, float jumpPushScale)
    {
        _jumping = true;

        float jumpStartTime = Time.time;
        float jumpDuration = 1;

        jumpHeightScale = jumpHeightScale * rb.velocity.magnitude * 0.05f;
        jumpHeightScale = Mathf.Clamp(jumpHeightScale, 0.0f, 1.0f);

        _boxCollider.enabled = false;
        rb.AddForce(rb.velocity.normalized * jumpPushScale * 20000, ForceMode2D.Impulse);

        while (_jumping)
        {
            
            float jumpCompletedPercentage = (Time.time - jumpStartTime) / jumpDuration;
            jumpCompletedPercentage = Mathf.Clamp01(jumpCompletedPercentage);

            spriteRenderer.transform.localScale = jumpCurve.Evaluate(jumpCompletedPercentage) * Vector3.one + Vector3.one; 
            //Debug.Log(jumpCompletedPercentage);
            //Debug.Log(jumpCurve.Evaluate(jumpCompletedPercentage) * Vector3.one + Vector3.one);
            
            shadowSpriteRenderer.transform.localScale = new Vector3(.75f, .5625f, .75f);


            //shadowSpriteRenderer.transform.localPosition =  jumpCurve.Evaluate(jumpCompletedPercentage) *  new Vector3(1, -1, 0.0f);
                       
            if (jumpCompletedPercentage == 1.0f)
                break;

            yield return null;
        }

        spriteRenderer.transform.localScale = Vector3.one;

        //shadowSpriteRenderer.transform.localPosition = new Vector3(transform.position.x, transform.position.y - 1.24f, transform.position.z);
        shadowSpriteRenderer.transform.localScale = new Vector3(1, .65f, 1);

        _boxCollider.enabled = true;
        spriteRenderer.sortingLayerName = "Default";
        _jumping = false;
    }

  
}
