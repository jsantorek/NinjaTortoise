//#if UNITY_EDITOR
using UnityEngine;
//#endif
using UnityEngine.UI;
using System.Collections;

public class CharacterStatus : MonoBehaviour
{
    public Text GUI_Objectives;
    public Text GUI_Exposition;
    public Text GUI_EndGame;

    private float e_min = 0.0f;
    private float e_max = 100.0f;
    public float exposition;
    private int objectives_all;
    public int objectives_completed = 0;

    private ArrayList enemies;

    void Start()
    {
        exposition = 50.0f;
        objectives_all = GameObject.FindGameObjectsWithTag("Objective").Length;
        GUI_Objectives.text = objectives_completed.ToString() + "/" + objectives_all.ToString();
        GUI_Exposition.text = exposition.ToString() + "%";
        GameObject[] enemiess = GameObject.FindGameObjectsWithTag("Enemy");
        enemies = new ArrayList();
        foreach (GameObject enemy in enemiess)
            enemies.Add(enemy.GetComponent<EnemyAI>());
    }

    public bool isExposed()
    {
        return (exposition == e_max);
    }

    public void Expose(float e)
    {
        exposition += e;
        exposition = Mathf.Clamp(exposition, e_min, e_max);
        GUI_Exposition.text = exposition.ToString() + " %";
        foreach (EnemyAI enemy in enemies)
            enemy.Resize(exposition);
    }

    public void ObjectiveReached()
    {
        objectives_completed++;
        GUI_Objectives.text = objectives_completed.ToString() + " / " + objectives_all.ToString();
        if (objectives_completed >= objectives_all)
            GAMEOVER();
    }

    public void Caught()
    {
        GAMEOVER();
    }

    private void GAMEOVER()
    {
        gameObject.GetComponent<CharacterMotor>().enabled = false;
        GUI_EndGame.enabled = true;
        if(objectives_completed >= objectives_all)
        {
            GUI_EndGame.color = Color.green;
            GUI_EndGame.text = "YOU WIN";
        }
        else
        {
            GUI_EndGame.color = Color.red;
            GUI_EndGame.text = "YOU LOOSE";
        }
    }
}
