using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    private float c_min = 3, c_max = 18;
    public float searchingTurnSpeed = 160f;
    public float searchingDuration = 8f;
    public float sightRange = 200.0f;
    public Transform[] wayPoints;
    public Transform eyes;
    public Vector3 offset = new Vector3(0, .5f, 0);
    public MeshRenderer spriteRenderer;


    [HideInInspector]
    public Transform chaseTarget;
    [HideInInspector]
    public IEnemyState currentState;
    [HideInInspector]
    public ChaseState chaseState;
    [HideInInspector]
    public AlertState alertState;
    [HideInInspector]
    public PatrolState patrolState;
    [HideInInspector]
    public UnityEngine.AI.NavMeshAgent navMeshAgent;

    private void Awake()
    {
        chaseState = new ChaseState(this);
        alertState = new AlertState(this);
        patrolState = new PatrolState(this);

        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    
    public void Resize(float exposition)
    {
        GetComponent<SphereCollider>().radius = (c_min - c_max) * exposition / 100;
    }

    void Start()
    {
        currentState = patrolState;
    }
    
    void Update()
    {
        currentState.UpdateState();
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }

    private void OnTriggerExit(Collider other)
    {
        currentState.OnTriggerExit(other);
    }
}