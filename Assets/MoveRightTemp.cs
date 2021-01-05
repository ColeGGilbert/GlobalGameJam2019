using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveRightTemp : MonoBehaviour {

	private Rigidbody2D rb;
	public float jumpForce;
	private bool grounded;
	public LayerMask ground;
	public float speed;
	private Vector2 normalScale;
	private bool doubleJumpUsed;
	private Vector2 crouchScale;
	public float minSpeed;
	public float maxSpeed;
    public float Accel = 0.15f;
    public Image speedDisplay;
    private GameObject gameEngine;

    private void OnEnable()
    {
        ResetLevelScene.OnReset += ResetPlayer;
    }

    // Use this for initialization
    void Start ()
    {
		rb = GetComponent<Rigidbody2D>();
		normalScale = transform.localScale;
		crouchScale = new Vector2(transform.localScale.x, transform.localScale.y / 2);
        gameEngine = GameObject.FindGameObjectWithTag("GameEngine");
        minSpeed = gameEngine.GetComponent<PermanantUpgrades>().minSpeed;
        maxSpeed = gameEngine.GetComponent<PermanantUpgrades>().maxSpeed;
        speed = minSpeed + gameEngine.GetComponent<PermanantUpgrades>().startSpeed;
    }

    void ResetPlayer()
    {
        transform.position = new Vector3(-9f, -3f, 0f);
        minSpeed = gameEngine.GetComponent<PermanantUpgrades>().minSpeed;
        maxSpeed = gameEngine.GetComponent<PermanantUpgrades>().maxSpeed;
        speed = minSpeed + gameEngine.GetComponent<PermanantUpgrades>().startSpeed;
    }

	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
		rb.velocity = new Vector2(speed, rb.velocity.y);
		grounded = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - transform.localScale.y / 2), Vector2.down, 0.2f, ground);
		if (Input.GetButtonDown("Jump") && grounded)
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
		}
		else if(Input.GetButtonDown("Jump") && !grounded && !doubleJumpUsed)
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
			doubleJumpUsed = true;
		}
		if (Input.GetButtonDown("Crouch"))
		{
			transform.localScale = crouchScale;
			GetComponent<CapsuleCollider2D>().size = new Vector2(0.5f, 1);
		}
		else if (Input.GetButtonUp("Crouch"))
		{
			transform.localScale = normalScale;
			GetComponent<CapsuleCollider2D>().size = new Vector2(1, 1);
		}
		if (grounded)
		{
			doubleJumpUsed = false;
		}
		if(speed < maxSpeed && !(Input.GetButton("Crouch")))
		{
            if (speed + Accel * Time.deltaTime < maxSpeed)
            {
                speed += Accel * Time.deltaTime;
            }
            else
            {
                speed = maxSpeed;
            }
		}
        speedDisplay.fillAmount = (float) speed / (float)maxSpeed;
	}

	public void SlowPlayer()
	{
		speed = minSpeed;
	}

	private void LateUpdate()
	{
		Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - transform.localScale.y/2, transform.position.z), Vector3.down, Color.green);
	}
}
