using UnityEngine;
using System.Collections;

public class CharacterStatus : MonoBehaviour
{
    private float e_min = 0.0f;
    private float e_max = 100.0f;
    public float exposition;

    void Start()
    {
        exposition = e_min;
    }

    public bool isExposed()
    {
        return (exposition == e_max);
    }

    public void Expose(float e)
    {
        exposition += e;
        exposition = Mathf.Clamp(exposition, e_min, e_max);
        Debug.Log(exposition);
    }

}
