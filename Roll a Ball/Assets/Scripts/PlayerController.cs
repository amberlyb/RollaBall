using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text scoreText;
    public Text winText;
    public Text livesText;
    public Text loseText;

    private Rigidbody rb;
    private int count;
    private int score;
    private int lives;
    private Vector3 spherePosition;
    private float xPosition;
    private float increaseXPosition;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        lives = 3;
        SetAllText ();
        winText.text = "";
        loseText.text = "";
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * speed);

        if (Input.GetKey("escape"))
            Application.Quit();
    }
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ("Pick Up")) {
            other.gameObject.SetActive (false);
            count = count + 1;
            score = score + 1;
            SetAllText ();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            lives = lives - 1;
            SetAllText ();
        }
        if (lives <= 0)
        {
            Destroy(this);
            loseText.text = "You Lose!";
        }
        if (score == 12) {
            transform.position = new Vector3 (32.50f, transform.position.y, 0.0f);
        }
    }
    void SetAllText ()
    {
         livesText.text = "Lives: " + lives.ToString ();
         countText.text = "Count: " + count.ToString ();
         scoreText.text = "Score: " + score.ToString ();
         if (score >= 20)
         {
             winText.text = "You Win!";
         }
        
    }
}
