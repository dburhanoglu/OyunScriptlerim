using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScPlayerControllerr : MonoBehaviour
    
{private  Rigidbody2D playerRB;
 private float movementSpeet = 5.0f;
 private float  h_Input;
    private float v_Input;
   // private bool isWeaponEquipped;
   private GameObject WeaponObj;
    [SerializeField] private float movementSpeed = 5.0f;
    [SerializeField] private float weaponAwayRadius = 0.2f;
    private float weaponAngle = 0f;
    private bool isWeaponEquipped;
    Animator p_Animator;
    private bool isIdle;
    private bool isWalkingX;
    private bool isWalkingY;
    private bool isWalking;
    // Start is called before the first frame update

    void Awake()
    {
        playerRB = this.GetComponent<Rigidbody2D>();
        p_Animator = this.GetComponent<Animator>();
        isWeaponEquipped = false;
        isIdle = true;
        isWalkingX=false;
        isWalkingY=false;
        isWalking = false;

    }
    void Start()
    {
   

    }

    // Update is called once per frame
    void Update()
    {
        //kullanýcý giriþi
        CheckInput();

        
    }
    void FixedUpdate()
    {
        playerRB.velocity = new Vector2(h_Input * movementSpeed, v_Input * movementSpeed);
      
        //ApplyMovement();
    }
    //void ApplyMovement()
    //{
    //    playerRB.velocity = new Vector2(h_Input*movementSpeet,v_Input*movementSpeet);
    //}

    void CheckInput()
    {
       h_Input=Input.GetAxis("Horizontal");
        //  Debug.Log("Input" + h_Input);
        v_Input = Input.GetAxis("Vertical");
        if (h_Input > 0.01f || h_Input < -0.01f)
        {
            isIdle = false;
            isWalkingX=true;
            isWalking=true;
            p_Animator.SetBool("Bool_isidle", isIdle);
            p_Animator.SetBool("Bool_isWalking", isWalking);
            //p_Animator.SetBool("Bool_MovementX", isWalkingX);
            p_Animator.SetFloat("MovX", h_Input);
        }
        if (v_Input > 0.01f || v_Input < -0.01f)
        {
            isIdle = false;
            isWalkingY =true;
            isWalking = true;
            p_Animator.SetBool("Bool_isidle", isIdle);
            p_Animator.SetBool("Bool_isWalking", isWalking);
            //p_Animator.SetBool("Bool_MovementY", isWalkingY);
            p_Animator.SetFloat("MovY", v_Input);
        }
        if ((h_Input < 0.01f && h_Input > -0.01f)) 
        {   isWalkingX = false;
            //isWalking = true;
           // p_Animator.SetBool("Bool_MovementX", isWalkingX);
        }

        if ((v_Input < 0.01f && v_Input > -0.01f))
        {
            isWalkingY = false;
           // p_Animator.SetBool("Bool_MovementY", isWalkingY);

        }  
        if(isIdle==false && isWalkingX==false && isWalkingY==false)
        {   isWalking=false;
            isIdle = true;
            p_Animator.SetBool("Bool_isWalking", isWalking);
            p_Animator.SetBool("Bool_isidle", isIdle);
            StartCoroutine(WaitForIdleAnimation());
           
        }
        if (WeaponObj != null && isWeaponEquipped==true)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = mousePos - WeaponObj.transform.position;
            float angle = Vector2.SignedAngle(Vector2.right, direction);
            weaponAngle = angle;
            Vector2 newWeaponPos = new Vector2(weaponAwayRadius * Mathf.Cos(angle * Mathf.PI / 180), weaponAwayRadius * Mathf.Sin(angle * Mathf.PI / 180));
            //Vector2 newWeaponPos=new Vector2(weaponAwayRadius*Math.cos.angle)
            // Debug.Log("Angle" + angle);
            //  WeaponObj.transform.eulerAngles = new Vector3();
            // WeaponObj.transform.localPosition = newWeaponPos;
            WeaponObj.transform.localPosition = newWeaponPos;
            WeaponObj.transform.eulerAngles = new Vector3(0, 0, angle);
           if (isWeaponEquipped == true && Input.GetButtonDown("Fire1"))
            {
                if (WeaponObj != null)
                {
                    WeaponObj.GetComponent<ScHandGun>().shoot(weaponAngle);
                    
                }else
                    {
                        Debug.LogError("error" + WeaponObj);
                    }
                //Debug.Log("fire"+Input.mousePosition);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (isWeaponEquipped == false && col.CompareTag("Weapon"))
        {
           // Debug.Log("Triggered Weapon Trigger");
            //Debug.Log(col.gameObject.name + ":" + gameObject.name + ":" + Time.time);

            WeaponObj=col.gameObject;
            col.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x + 1.0f, this.gameObject.transform.position.y - 1.1f);
            col.gameObject.transform.parent = this.gameObject.transform;
            
            //col.gameObject.transform.position = new Vector2(this.gameObject.transform.position.x + 0.8f, this.gameObject.transform.position.y-0.15f);
            //col.gameObject.transform.parent = this.gameObject.transform;
            isWeaponEquipped = true;


        }


    }
    IEnumerator WaitForIdleAnimation ()
    {
        
            yield return new WaitForSeconds(0.1f);
        Debug.Log("2 sec");
        p_Animator.SetBool("Bool_isidle", false);
        }
    
}
