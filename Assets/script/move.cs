using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {

    public GameObject man;

    public float speed = 15f;
    public float vertical_move=15f;
    public float horiziontal_move;
    public bool isground = true;

    public bool drump = false;

    public bool num1 = false;
    public bool num2 = false;
    public bool num3 = false;
    public bool num4 = false;
    public bool num5 = false;
    public bool num6 = false;
    public bool num7 = false;
    public bool win = false;

    public GameObject s1;
    public GameObject s2;
    public GameObject s3;
    public GameObject s4;
    public GameObject s5;
    public GameObject s6;
    public GameObject s7;
    void star()
    {
        man = GetComponent<GameObject>();
     }
    void Update()
    {      
        float fx;
        float horiziontal_move = Input.GetAxisRaw("Horizontal");
        if (horiziontal_move > 0.5 || horiziontal_move < -0.5)
        {
            if (horiziontal_move < 0) fx = -1f;
            else
            {
                fx = 1f;
            }           
                if(isground)
                man.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, 0) *fx);          
        }

        //if (drump)
        //{
        //    vertical_move = 20f;
        //    if (isground)
        //    {
        //        man.getcomponent<rigidbody2d>().addforce(new vector2(0, vertical_move) * 24f);
        //        isground = false;
        //    }
        //    drump = false;
        //}
        if (Input.GetKeyDown(KeyCode.Space))
        {
            vertical_move = 20f;
            if (isground)
            {
                man.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, vertical_move) * 24f);
                isground = false;
            }
            drump = false;
        }
        if (num1 && num2 && num3 && num4 && num5 && num6 && num7)
        {
            win = true;
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.name == "die")
        {
            if (win == false)
            {
                Application.LoadLevel("gameover");
            }
            else Application.LoadLevel("win");
        }
        if (col.collider.name != "shu1")
        {
            isground = true;

        }
        if (col.collider.name == "s1")
        {
            s1.SetActive(true);
            num1 = true;
            
        }
        if (col.collider.name == "s2")
        {
            s2.SetActive(true);
            num2 = true;
        }
        if (col.collider.name == "s3")
        {
            s3.SetActive(true);
            num3 = true;
        }
        if (col.collider.name == "s4")
        {
            s4.SetActive(true);
            num4 = true;
        }
        if (col.collider.name == "s5")
        {
            s5.SetActive(true);
            num5 = true;
        }
        if (col.collider.name == "s6")
        {
            s6.SetActive(true);
            num6 = true;
        }
        if (col.collider.name == "s7")
        {
            s7.SetActive(true);
            num7 = true;
        }
    }
    public void OnCollisionExit2D(Collision2D col)
    {
        if (col.collider.name != "shu1")
         isground = false;    
    }
  
}
