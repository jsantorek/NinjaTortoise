using UnityEngine;
using System.Collections;

public class CharacterController2D : MonoBehaviour {
    private Rigidbody2D rigidbody;
    public float v_walk = 5.0f;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input.Normalize();
        rigidbody.velocity = input * v_walk;
	}
}
