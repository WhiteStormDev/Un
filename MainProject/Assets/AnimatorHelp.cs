using UnityEngine;
using System.Collections;

public class AnimatorHelp : MonoBehaviour
{
    private Animator anim;
    private CharacterControl charController;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        charController = FindObjectOfType<CharacterControl>();
    }
    public Collider2D IdleHitBox;
    public Collider2D rollHitBox;
    public Collider2D attackHitBoxR;
    CharacterControl Char;
    public void unTrue()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("rolling", false);
        anim.SetBool("attacking", false);
        anim.SetBool("running", false);
        anim.SetBool("jumping", false);
        anim.SetBool("jump_down", false);
        anim.SetBool("fight_pose", false);
        anim.SetBool("pinoking", false);
        anim.SetBool("healing", false);
        anim.SetBool("damaged", false);
        anim.SetBool("taking_rest", false);
        anim.SetBool("blinking", false);
        anim.SetBool("dead", false);

    }
    public void RollHitBoxOn()
    {
        rollHitBox.enabled = true;
        IdleHitBox.enabled = false;
        StartCoroutine(RollHitOF());
    }
    public IEnumerator RollHitOF()
    {
        yield return new WaitForSeconds(0.3f);
        IdleHitBox.enabled = true;
        rollHitBox.enabled = false;
    }
    public void AttackHitBoxOn()
    {        
        attackHitBoxR.enabled = true;
    }
    public void AttackHitBoxOff()
    {
        attackHitBoxR.enabled = false;   
    }
    public void MoveStanLockOn()
    {
        anim.SetBool("running", false);
        charController.canMove = false;
    }
    public void MoveStanLockOf()
    {
        charController.canMove = true;
    }



}
