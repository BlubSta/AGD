using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float speed = 0.3f;
    public float sprintspeed = 0.5f;
	public float cameraH = 2f;
	public float cameraV = 3f;
	public GameObject camera;

	private float horizontal;
	private float vertical;
	private float mouseHorizontal;
	private float mouseVertical;
    private float privateSpeed;
	private Rigidbody rb;
    private Vector3 movement;


	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            privateSpeed = sprintspeed;
            print("sprinting");
        }
        else
        {
            privateSpeed = speed;
        }

        if (!PlayerControler.pause) {
			horizontal = Input.GetAxisRaw ("Horizontal") * privateSpeed; //ad
			vertical = Input.GetAxisRaw ("Vertical") * privateSpeed; //ws

			mouseHorizontal = Input.GetAxis ("Mouse X") * cameraH;
			mouseVertical = Input.GetAxis ("Mouse Y") * cameraV;


			camera.transform.Rotate (-mouseVertical, 0, 0);
            movement = new Vector3(horizontal, 0, vertical);
            transform.Translate(movement);
            transform.Rotate(0, mouseHorizontal, 0);
		}

	}
}
