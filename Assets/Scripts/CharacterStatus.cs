using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CharacterStatus : MonoBehaviour
{
    public Text GUI_exposition;



    private float e_min = 0.0f;
    private float e_max = 100.0f;
    public float exposition;
    private int objectives_all;
    public int objectives_completed = 0;

    void Start()
    {
        exposition = e_min;
        objectives_all = GameObject.FindGameObjectsWithTag("Objective").Length;
        GUI_exposition.text = objectives_completed.ToString() + " / " + objectives_all.ToString();
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

    public void ObjectiveReached()
    {
        objectives_completed++;
        GUI_exposition.text = objectives_completed.ToString() + " / " + objectives_all.ToString();
        if (objectives_completed >= objectives_all)
            Debug.Log("END GAME");
    }

}
