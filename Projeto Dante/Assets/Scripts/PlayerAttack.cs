using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform attackPoint1;
    public Transform attackPoint2;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;
    public float jumpingPower;
    public Rigidbody2D rb;

    public bool isFacingRight;
    
    public float horizontal;

    public Player_moviment player_Moviment;

    void Start()
    {
        
    }

    void Update()
    {
        isFacingRight = player_Moviment.isFacingRight1;
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
       

    }

    void Attack()
    {

        if (isFacingRight == false)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint1.position, attackRange, enemyLayer);

            foreach(Collider2D enemy in hitEnemies)
            {
                Debug.Log("hit" + enemy.name);
                rb.velocity= new Vector2(rb.velocity.x, jumpingPower);
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            } 

            foreach(Collider2D enemy in hitEnemies)
            {
            if(enemy.gameObject.CompareTag("Soul2"))
            {
                Destroy(enemy.gameObject);
            }

            }
        }
        else
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint2.position, attackRange, enemyLayer);

            foreach(Collider2D enemy in hitEnemies)
            {
                Debug.Log("hit" + enemy.name);
                rb.velocity= new Vector2(rb.velocity.x, jumpingPower);
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            } 

            foreach(Collider2D enemy in hitEnemies)
            {
            if(enemy.gameObject.CompareTag("Soul2"))
            {
                Destroy(enemy.gameObject);
            }

            }
        }
        


    }

    

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(attackPoint1.position, attackRange);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPoint2.position, attackRange);
    }

    public void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {

        }
    }
   

}

