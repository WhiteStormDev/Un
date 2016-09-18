using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour
{
    private bool attacking = false;

    private double attackCoolDTime = 0;
    public double attackCoolD = 0.3f;

    public double attackWait = 1f;
    private double attackWaitTime = 0;
    private double helpWait = 0;
    private double attackTypeWait;
    private bool attackTypeBool;

    public GameObject sprite;
    Animator anim;
    public Collider2D attackHitBox;

    void Awake()
    {
        attackTypeBool = false;
        anim = sprite.GetComponent<Animator>();
        //attackHitBox.enabled = false;
    }
    void Update()
    {
       

        if (Input.GetKeyDown(KeyCode.A))
            if (anim.GetBool("fight_pose") == true)
            {
                anim.SetBool("attacking", true);
                attacking = true;
            }
        if (Input.GetKeyUp(KeyCode.A))
            if (anim.GetBool("fight_pose") == true)
            {
                anim.SetBool("attacking", false);
                attacking = false;
            }

        if (Input.GetKeyDown(KeyCode.S)/* && !anim.GetBool("fight_pose")*/)
        {
            if (anim.GetBool("fight_pose") == true)
            {
                anim.SetBool("fight_pose", false);
            }
            else
            {
                anim.SetBool("fight_pose", true);
            }
        }
        #region trash
        //if (Input.GetKeyUp(KeyCode.S))
        //{
        //    if (attacking)
        //    {
        //        if (attackTypeWait > 0)
        //        {
        //            if (helpWait > 0)
        //            {
        //                helpWait -= Time.deltaTime * 1.5;
        //            }
        //            else
        //                attackHitBox.enabled = true;
        //        }
        //    }
        //    attacking = false;
        //    attackHitBox.enabled = false;
        //    anim.SetBool("attacking", false);
        //    attackWaitTime = attackWait;

        //}        


        //if (attacking)
        //{


        //    if (attackWaitTime > 0)
        //    {
        //        attackWaitTime -= Time.deltaTime * 1.7;
        //    }
        //    else
        //    {
        //        attackHitBox.enabled = true;


        //        //// ЗАДЕРЖКА НА КУЛДАУН
        //        //if (attackCoolDTime > 0)
        //        //{
        //        //    attackCoolDTime -= Time.deltaTime;
        //        //}
        //        //else
        //        //{
        //        //    //attacking = false;
        //        //    attackHitBox.enabled = false;
        //        //    //anim.SetBool("attacking", false);
        //        //}
        //    }
        //}
        //else
        //{
        //    anim.SetBool("attacking", false);

        //    attackHitBox.enabled = false;
        //}
        #endregion

    }
}
