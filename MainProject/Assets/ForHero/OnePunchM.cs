using UnityEngine;
using System.Collections;

public class OnePunchM : MonoBehaviour {

    public double CDkoef;
    public double WaitKoef;

    private double attackWait = 2;
    private double attackWaitTime;
    private double attackCD = 2;
    private double attackCDTime;

    bool attacking = false;

    public Collider2D attackCol;
    private Animator anim;
    public GameObject sprite;
    void Awake()
    {
        anim = sprite.GetComponent<Animator>();

    }
	

	void Update () {
        if (Input.GetKeyDown(KeyCode.D))
        {
           // if (anim.GetBool("fight_pose") == false)
           anim.SetBool("fight_pose", true);
            
        }
        if (Input.GetKeyUp(KeyCode.D))
        {

        }
        
        if (Input.GetKeyDown(KeyCode.S) && !attacking)
        {
            attackWaitTime = attackWait;
            attackCDTime = attackCD;
            anim.SetBool("attacking", true);
            attacking = true;
        }

        if (attacking)
        {
            //if (attackWaitTime > 0)
            //{
            //    attackWaitTime -= Time.deltaTime * WaitKoef;
            //}
            //else
            //{
                attackCol.enabled = true;
                
                if (attackCDTime > 0)
                {
                    attackCDTime -= Time.deltaTime * CDkoef;
                }
                else
                {
                    attacking = false;
                }


               
            //}
        }
    }
}
