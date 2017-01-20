using UnityEngine;
using System.Collections;

public class CharacterController2D : MonoBehaviour {
    private Rigidbody2D rigidbody2d;
    public float v_walk = 5.0f;

	// Use this for initialization
	void Start ()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        input.Normalize();
        rigidbody2d.velocity = input * v_walk;
	}
}
