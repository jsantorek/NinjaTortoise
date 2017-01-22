using UnityEngine;
using System.Collections;

public class Region : MonoBehaviour
{
    public float exposition = 0.0f;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            other.gameObject.GetComponent<CharacterStatus>().Expose(exposition);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
            other.gameObject.GetComponent<CharacterStatus>().Expose(-exposition);
    }
}
