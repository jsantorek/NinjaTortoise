using UnityEngine;
using System.Collections;

public class Catch : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            other.gameObject.GetComponent<CharacterStatus>().Caught();
    }
}
