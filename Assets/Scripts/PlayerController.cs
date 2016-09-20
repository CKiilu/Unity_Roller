using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
    private int score;
    public Text scoreText;
    public Text winText;

    void Start () {
		rb = GetComponent<Rigidbody> ();
        score = 0;
        setScoreText();
        winText.text = "";
	}
    
	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            score++;
            setScoreText();
            if (score == 8)
            {
                winText.text = "You Win!";
            }
        }
    }

    void setScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}