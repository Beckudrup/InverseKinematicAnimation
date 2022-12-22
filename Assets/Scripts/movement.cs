using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class movement : MonoBehaviour
{
    private Vector2 bevaegelse;
    private Rigidbody2D myBody;
    private Animator myAnimator;
    [SerializeField] private int speed = 5;

    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    private void OnMovement(InputValue value)
    {
        bevaegelse = value.Get<Vector2>();
        
        if (bevaegelse.x !=0 || bevaegelse.y != 0)
        {
            
            myAnimator.SetBool("walking", true);
        }
        else
        {
            myAnimator.SetBool("walking", false);
        }
        if (Input.GetKeyDown(KeyCode.W) == true || Input.GetKeyDown(KeyCode.Space) == true)
        {
            myAnimator.SetTrigger("hop");
        }
      
    }
    private void FixedUpdate()
    {
        myBody.velocity = bevaegelse * speed;
    }

    private void restartGame(){

           if(Input.GetKeyDown("r")==true){
            Debug.Log("Hej jeg virker :)");
            this.gameObject.SetActive(true);

    }

    }
}
