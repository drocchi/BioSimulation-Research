using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour {

	Vector3 rot = Vector3.zero;
	public float rot_speed = 40f;
	public float move_speed = 40f;
	Animator anim;

	// Use this for initialization
	void Awake()
	{
		anim = gameObject.GetComponent<Animator>();
		gameObject.transform.eulerAngles = rot;
	}

	// Update is called once per frame
	void Update()
	{
		CheckKey();
		gameObject.transform.eulerAngles = rot;

		float moveVertical = Input.GetAxis("Vertical");
		float moveHorizontal = Input.GetAxis("Horizontal");

		Vector3 newPosition = new Vector3(moveHorizontal, 0.0f, moveVertical);
		transform.LookAt(newPosition + transform.position);
		transform.Translate(newPosition * move_speed * Time.deltaTime, Space.World);

	}

	void WalkStraight()
	{
		transform.position += Vector3.forward * Time.deltaTime * move_speed;
		anim.SetBool("Walk_Anim", true);
	}

	void WalkBackward()
	{
		transform.position -= Vector3.forward * Time.deltaTime * move_speed;
		anim.SetBool("Walk_Anim", true);
	}

	void WalkRight()
	{
		transform.position += Vector3.right * Time.deltaTime * move_speed;
		anim.SetBool("Walk_Anim", true);
	}

	void WalkLeft()
	{
		transform.position -= Vector3.right * Time.deltaTime * move_speed;
		anim.SetBool("Walk_Anim", true);
	}

	void CheckKey()
	{
		// Walk
		if (Input.GetKey(KeyCode.W))
		{
			WalkStraight();
		}
		else if (Input.GetKeyUp(KeyCode.W))
		{
			anim.SetBool("Walk_Anim", false);
		}

		// Rotate Left
		if (Input.GetKey(KeyCode.A))
		{
			WalkLeft();
		}

		// Rotate Right
		if (Input.GetKey(KeyCode.D))
		{
			WalkRight();
		}

		// Rotate Right
		if (Input.GetKey(KeyCode.S))
		{
			WalkBackward();
		}

		// Roll
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (anim.GetBool("Roll_Anim"))
			{
				anim.SetBool("Roll_Anim", false);
			}
			else
			{
				anim.SetBool("Roll_Anim", true);
			}
		}

		// Close
		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			if (!anim.GetBool("Open_Anim"))
			{
				anim.SetBool("Open_Anim", true);
			}
			else
			{
				anim.SetBool("Open_Anim", false);
			}
		}
	}
}
