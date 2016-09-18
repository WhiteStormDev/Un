
using UnityEngine;
using System.Collections;


public class CharacterControl : MonoBehaviour {

    float timerTime;


    public bool canMove = true;

    //АНИМАЦИИ_____________________________________

    
    public double waitTime = 1f;  //rolling
    private double helpWait;
    private double helpWait1;
    private bool isRolling;
    public bool isLeftOr = false;

   // public GameObject AttackHitBox1;
   // public static BoxCollider2D AttackHit;
    public float  TimerTime;
    
    Animator animator;
    AnimatorStateInfo currentBaseState;
    //_____________________________________________

    public Behaviour currentState;
    //Movement__________________________________________
    private static bool RollStaminaFreeze;
    private static bool LfreezeMoveAfterRoll;
    private static bool RfreezeMoveAfterRoll;
    public bool freezeRotarion;
    public bool impuls1 = true;

    public GameObject sprite;
	
	public float CharacterLookWriteThenMinOne = 0;
	
	public float jumpStrench = 20f;
	public float speed = 7f;
    
	public float boostSpeed = 10f;
	
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;
	
	private bool doubleJumped;
    //______________________________________________________
    static int fight_poseSt = Animator.StringToHash("weapon_get");
    static int run_finSt = Animator.StringToHash("run_fin");
    static int idle_combatSt = Animator.StringToHash("Base Layer.idle_combat");
    static int idleSt = Animator.StringToHash("idle");
	// Use this for initialization
	void Start () {
        RollStaminaFreeze = false;
        LfreezeMoveAfterRoll = false;
        RfreezeMoveAfterRoll = false;
        isLeftOr = false;
        freezeRotarion = false;
        //AttackHit = gameObject.GetComponentInChildren<BoxCollider2D>();    
        //ANIMATIONS_________________________________________________________
        animator = sprite.GetComponent<Animator>();
       // currentState = animator.GetBehaviour<>
        currentBaseState = animator.GetCurrentAnimatorStateInfo(0);
        timerTime = 0;
        //_____________________________________________________________________

    }
	
   

	void FixedUpdate() {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
        
	}
	
	// Update is called once per frame
	void Update () {

        //timerTime += Time.deltaTime;
        //if (timerTime >= 4) timerTime = 0;
        if (!canMove) return;
       

		Movement ();
        
        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.ClearDeveloperConsole();
           // Debug.Log(currentBaseState.IsTag("idle"));
            Debug.Log(currentBaseState.tagHash +"   " + idle_combatSt) ;
        }
          
    }	
	

	void Movement()
	{
        //Debug.Log();
        
        
        
        if (grounded) {
			doubleJumped = false;
		}

        if (Input.GetKeyDown(KeyCode.LeftShift) && !isRolling && !RollStaminaFreeze)
        {
            animator.SetBool("running", false);
            animator.SetBool("rolling", true);
            freezeRotarion = true;
            isRolling = true;
            helpWait = waitTime;
            
            
            if (!isLeftOr)
            {
              
                GetComponent<Rigidbody2D>().velocity = new Vector2(16, GetComponent<Rigidbody2D>().velocity.y);
                StartCoroutine(ImpulsR());
                StartCoroutine(LFreezeRotLeft());
               
            }
                
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-16, GetComponent<Rigidbody2D>().velocity.y);
                StartCoroutine(ImpulsL());
                StartCoroutine(RFreezeRotLeft());
            }
            StartCoroutine(RollStamina());   
            
        }
        if (isRolling)
        {
            if (helpWait > 0)
            {
                helpWait -= Time.deltaTime * 3;
            }
            else
            {
                animator.SetBool("rolling", false);
                freezeRotarion = false;
                isRolling = false;
            }
                
        }
        if (Input.GetKeyDown (KeyCode.Space) && grounded) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpStrench);
			
			//rigidbody2D.AddForce(Vector2.up * jumpStrench); 		
		}
		
		if (Input.GetKeyDown (KeyCode.Space) && !doubleJumped && !grounded) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpStrench);
			doubleJumped = true;
			//rigidbody2D.AddForce(Vector2.up * jumpStrench); 		
		}
		
        //if ()
		if (Input.GetKey (KeyCode.RightArrow) && !freezeRotarion && !RfreezeMoveAfterRoll && !animator.GetBool("attacking"))
		{
            

            if (!(currentBaseState.tagHash == run_finSt) && !(currentBaseState.tagHash == fight_poseSt))
            {
                isLeftOr = false;
                //    if (Input.GetKeyDown(KeyCode.LeftShift))
                //    {
                //        speed += boostSpeed;
                //        transform.Translate(Vector2.right * speed * Time.deltaTime);
                //        animator.SetBool("rolling", true);
                //    }
                //    else
                //    {
                //        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
                //        //transform.Translate (Vector2.right * speed * Time.deltaTime);
                //        sprite.transform.eulerAngles = new Vector2(0, CharacterLookWriteThenMinOne);
                //        //animator.SetBool("idle", false);
                //        //animator.StopPlayback();
                //        animator.SetBool("running", true);
                //    }
                GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
                //transform.Translate (Vector2.right * speed * Time.deltaTime);
                sprite.transform.eulerAngles = new Vector2(0, CharacterLookWriteThenMinOne);
                //animator.SetBool("idle", false);
                //animator.StopPlayback();
                animator.SetBool("running", true);
            }
			
            
		}

        if (Input.GetKey(KeyCode.LeftArrow) && !freezeRotarion && !LfreezeMoveAfterRoll && !animator.GetBool("attacking")) 
		{
            //if (!isLeftOr)
            //{
            //    helpWait1 = waitTime;
            //    if (helpWait1 > 0)
            //        helpWait1 -= Time.deltaTime * 1.3;
            //    else
            //    {
            //        if (!(currentBaseState.tagHash == run_finSt) && !(currentBaseState.tagHash == fight_poseSt))
            //        {
            //            isLeftOr = true;
            //            sprite.transform.eulerAngles = new Vector2(0, CharacterLookWriteThenMinOne + 180);
            //            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
            //            //transform.Translate (Vector2.right * speed * Time.deltaTime);
            //            animator.SetBool("running", true);
            //        }
            //    }
            //}
            //else
            if (!(currentBaseState.tagHash == run_finSt) && !(currentBaseState.tagHash == fight_poseSt))
            {
                isLeftOr = true;
                sprite.transform.eulerAngles = new Vector2(0, CharacterLookWriteThenMinOne + 180);
                GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
                //transform.Translate (Vector2.right * speed * Time.deltaTime);
                animator.SetBool("running", true);
            }
        }
		//if (Input.GetKeyDown (KeyCode.Space)) 
		//{
		//	transform.Translate (Vector2.up * jumpStrench);
		//}
		//if (Input.GetKeyDown(KeyCode.LeftShift)) {
		//	speed += boostSpeed;
		//}
		//if (Input.GetKeyUp (KeyCode.LeftShift)) {
		//	speed -= boostSpeed;
		//}
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetBool("running", false);
        }
        

        //else
        //    if (Input.GetKeyDown(KeyCode.D) && animator.GetBool("fight_pose") == true)
        //{
        //    animator.SetBool("fight_pose", false);
        //}



        //if (Input.GetKeyUp(KeyCode.S) && animator.GetBool("attacking") == true)
        //{
        //    //AttackHitBox1.SetActive(false);
        //    animator.SetBool("attacking", false);
        //}
    }





    public IEnumerator ImpulsL()
    {
        yield return new WaitForSeconds(0.1f);
        GetComponent<Rigidbody2D>().velocity = new Vector2(-12, GetComponent<Rigidbody2D>().velocity.y);
        yield return new WaitForSeconds(0.1f);
        GetComponent<Rigidbody2D>().velocity = new Vector2(-10, GetComponent<Rigidbody2D>().velocity.y);
        yield return new WaitForSeconds(0.1f);
        GetComponent<Rigidbody2D>().velocity = new Vector2(-8, GetComponent<Rigidbody2D>().velocity.y);
        yield return new WaitForSeconds(0.1f);
        GetComponent<Rigidbody2D>().velocity = new Vector2(-4, GetComponent<Rigidbody2D>().velocity.y);
        yield return new WaitForSeconds(0.1f);
        GetComponent<Rigidbody2D>().velocity = new Vector2(-2, GetComponent<Rigidbody2D>().velocity.y);

    }
    public IEnumerator ImpulsR()
    {
        yield return new WaitForSeconds(0.1f);
        GetComponent<Rigidbody2D>().velocity = new Vector2(12, GetComponent<Rigidbody2D>().velocity.y);
        yield return new WaitForSeconds(0.1f);
        GetComponent<Rigidbody2D>().velocity = new Vector2(10, GetComponent<Rigidbody2D>().velocity.y);
        yield return new WaitForSeconds(0.1f);
        GetComponent<Rigidbody2D>().velocity = new Vector2(8, GetComponent<Rigidbody2D>().velocity.y);
        yield return new WaitForSeconds(0.1f);
        GetComponent<Rigidbody2D>().velocity = new Vector2(4, GetComponent<Rigidbody2D>().velocity.y);
        yield return new WaitForSeconds(0.1f);
        GetComponent<Rigidbody2D>().velocity = new Vector2(2, GetComponent<Rigidbody2D>().velocity.y);

    }
    public IEnumerator RollStamina()
    {
        RollStaminaFreeze = true;

        yield return new WaitForSeconds(0.7f);
        RollStaminaFreeze = false;
    }
    public IEnumerator LFreezeRotLeft()
    {
        LfreezeMoveAfterRoll = true;
        yield return new WaitForSeconds(0.6f);

        LfreezeMoveAfterRoll = false;
    }
    public IEnumerator RFreezeRotLeft()
    {
        RfreezeMoveAfterRoll = true;
        yield return new WaitForSeconds(0.6f);

        RfreezeMoveAfterRoll = false;
    }

    //public static IEnumerator MyTimer(float WaitTime)
    //{
    //    yield return new WaitForSeconds(WaitTime);

    //}

}
