using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    
    public float speed = 5f;
    public Rigidbody2D rd;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public Vector2 moveVector;

    public int count = 1;
    public int score = 0;
    public float horizontal;
    public Joystick joystick;
    public Button btn;

    public Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        //dkzhfdsknada
        //Button btn = Player.GetComponent<Button>();
        btn.onClick.AddListener(Jump);
        rd = GetComponent<Rigidbody2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = joystick.Horizontal;
        moveVector.x = horizontal;
        //moveVector.y = Input.GetAxis("Vertical");
        rd.velocity = new Vector2(moveVector.x * speed, rd.velocity.y);
        //rd.AddForce(moveVector * speed);
        //
        /*if()Jump;*/
        CheckingGround();
        if(transform.position.y < -7f)
        {
            SceneManager.LoadScene(0);
        }
    }
    public float jumpForce = 6f;


    void Jump()
    {
        if (onGround)
        {
            rd.velocity = new Vector2(rd.velocity.x, jumpForce);
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Coin")
        {
            AddCoid();
            Destroy(coll.gameObject);

        }
        if (coll.gameObject.tag == "enemy")
        {
            Debug.Log(coll.GetComponent<Collider>().GetType());
            /*if (coll.GetComponent<Collider>().GetType() == typeof(BoxCollider2D)){
                SceneManager.LoadScene(0);
            }
            if (coll.GetComponent<Collider>().GetType() == typeof(CircleCollider2D))
            {
                AddCoid();
                Destroy(coll.gameObject);
            }*/

            //SceneManager.LoadScene(0);
            
        }
        /*if (coll.gameObject.tag == "Destroy")
        {
            SceneManager.LoadScene(0);
            
        }*/
    }
    public void AddCoid()
    {
        score += count;
        ScoreText.text = score.ToString();
    }
    public bool onGround;
    public Transform GroundCheck;
    public float checkRadius = 0.5f;
    public LayerMask Ground;

    void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, Ground);
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            SceneManager.LoadScene(0);
        }
    }*/

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
        }
    }*/
}