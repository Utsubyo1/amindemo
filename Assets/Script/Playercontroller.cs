using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    float movespeed = 5.0f;
    float jumpforce = 5.0f;
    bool Ground;
    bool death = false ;
    int hp =10 ;
    public Rigidbody playerRb;
    public Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W) && death == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * movespeed);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            playerAnim.SetBool("ismove", true);
        }
       else if (Input.GetKey(KeyCode.S) && death == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * movespeed);
            transform.rotation = Quaternion.Euler(0, 180, 0);
            playerAnim.SetBool("ismove", true);
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            playerAnim.SetBool("ismove", false);
        }


        if (Input.GetKey(KeyCode.A) && death == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * movespeed);
            transform.rotation = Quaternion.Euler(0, -90, 0);
            playerAnim.SetBool("ismove", true);
        }
        else if (Input.GetKey(KeyCode.D) && death == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * movespeed);
            transform.rotation = Quaternion.Euler(0, 90, 0);
            playerAnim.SetBool("ismove", true);
        }
       if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            playerAnim.SetBool("ismove", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Ground == false)
        {
            playerRb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            playerAnim.SetTrigger("trigflip");
            Ground = true;
        }

        if(Input.GetKeyDown(KeyCode.K))
        {
            hp = hp - 1;

            if (hp <= 0 )
            { 
                playerAnim.SetTrigger("trigdeath");
                death = true;
            }
            
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            Ground = false;
        }
    }
}
