using UnityEngine;
using System.Collections;

public class Region : MonoBehaviour
{
    private CharacterStatus status;
    public float exposition = 0.0f;

	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            status = other.gameObject.GetComponent<CharacterStatus>();
            status.Expose(exposition);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            status.Expose(-exposition);
            status = null;
        }
    }
}
