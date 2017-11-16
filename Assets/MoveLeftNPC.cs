using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftNPC : MonoBehaviour {

	public GameObject npcSprite;
	public Animator anim;
	public string axisName = "Horizontal";
	public float speed = 1.0f;
	public bool startRotate;
	public bool movingTime;
	public Sprite rightFacingSprite;
	public SpriteRenderer sptr;
	private bool moveBack;
	private float startingPositionX;
	private int counter;
	public int waitTime;
	// Use this for initialization
	void Start () {
//		anim = gameObject.GetComponent<Animator> ();
		sptr = GetComponent<SpriteRenderer> ();
		startRotate = false;
		movingTime = true;

		sptr.sprite = rightFacingSprite;
		moveBack = false;
		startingPositionX = transform.position.x;
		counter = 0;
	}

	protected void Move(int xDir, int yDir, out RaycastHit2D hit){
		//store the start position to move from
		Vector2 start = transform.position;

		//Calculate end position
		Vector2 end = start + new Vector2(xDir, yDir);

		hit = Physics2D.Linecast (start, end);


	}
		
	// Update is called once per frame
	void Update () {
		
		//store the start position to move from

		if (movingTime) {
			Vector2 start = transform.position;
			Vector2 end = transform.position += transform.right * 1 * speed * Time.deltaTime;

			sptr.sprite = rightFacingSprite;
				

			if (end.x >= 07) {
				transform.position = start;
				anim = gameObject.GetComponent<Animator> ();
				anim.SetBool ("timeToRotate", true);
				movingTime = false;
			} else {
				transform.position = end;
					
			}
		} else {
			//when movingTime is false, count to 5 then move the character to the starting position

			if (counter < waitTime) {
				counter++;
			} else {
				moveBack = true;
				anim.SetBool ("timeToRotate", false);

				if (moveBack) {
					Vector2 end = transform.position -= transform.right * 1 * speed * Time.deltaTime;
					if (end.x > startingPositionX)
						transform.position = end;
					else {
						end.x = startingPositionX;
						transform.position = end;
						movingTime = true;
						counter = 0;
					}
						

				}
			}
		}


//		Debug.Log("Current Position: " + transform.position.ToString ());
//		Debug.Log ("Moving Time: " + movingTime.ToString ());
		Debug.Log ("Current Sprite: " + GetComponent<SpriteRenderer> ().sprite.name);

	}
}
