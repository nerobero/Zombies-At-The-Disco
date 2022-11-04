using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class ZombieAIBase : MonoBehaviour
{
    protected enum State
    {
        Chill,
        Walk,
        Run,
        Die
    }
    
    //The Coin to be dropped
    [SerializeField] public GameObject drop;

    [SerializeField] private State currentState;
    protected bool transitionActive;

    [SerializeField] protected Vector3 currentDestination;

     protected float runSpeed = 15f; 
    protected float walkSpeed;

    protected float viewAngle = 5f;
    protected float viewDistance = 50f;

    protected GameObject bryce;
    protected Animator zombieAnimator;

    protected float zombieHealth = 15f;

    protected bool isBryceDead = false;

    // Start is called before the first frame update
    public void Start()
    {
        bryce = GameObject.Find("Bryce");
        walkSpeed = GetComponent<NavMeshAgent>().speed;
        zombieAnimator = GetComponent<Animator>();
        SwitchToState(State.Chill);
    }

    // Update is called once per frame
    void Update()
    {
        
            switch (currentState)
            {
                case State.Chill:
                    if (transitionActive)
                    {
                        currentDestination = transform.position;
                        GetComponent<NavMeshAgent>().destination = currentDestination;
                        Invoke("SwitchToWalk", Random.Range(5.0f, 6.0f));
                        UpdateZombieAnimator(false, false, false);
                        GetComponent<NavMeshAgent>().speed = 0f;
                        transitionActive = false;
                    }

                    if (InView(bryce, viewAngle, viewDistance))
                    {
                        SwitchToState(State.Run);
                    }

                    break;
                case State.Walk:
                    if (transitionActive)
                    {
                        currentDestination = ValidDestination();
                        GetComponent<NavMeshAgent>().destination = currentDestination;
                        UpdateZombieAnimator(true, false, false);
                        GetComponent<NavMeshAgent>().speed = walkSpeed;
                        transitionActive = false;
                    }

                    if ((transform.position - currentDestination).magnitude < 2.5f)
                    {
                        SwitchToState(State.Chill);
                    }

                    if (InView(bryce, viewAngle, viewDistance))
                    {
                        SwitchToState(State.Run);
                    }
                    
                    break;
                case State.Run:
                    if (transitionActive)
                    {
                        CancelInvoke("SwitchToWalk");
                        Invoke("CheckForDeath", 10.0f);
                        UpdateZombieAnimator(false, true, false);
                        GetComponent<NavMeshAgent>().speed = runSpeed;
                        transitionActive = false;
                    }
                    
                    currentDestination = bryce.transform.position;
                    GetComponent<NavMeshAgent>().destination = currentDestination;

                    if ((transform.position - currentDestination).magnitude < 2.5f)
                    {
                        CancelInvoke("CheckForDeath");
                        CheckForDeath();
                    }

                    if ((transform.position - bryce.transform.position).magnitude > 60f)
                    {
                        SwitchToState(State.Chill);
                    }
                    break;
                case State.Die:
                    if (transitionActive)
                    {
                        currentDestination = transform.position;
                        GetComponent<NavMeshAgent>().speed = 0f;
                        UpdateZombieAnimator(false, false, true);
                    }
                    break;
            
        }

            if (isBryceDead)
            {
                bryce = GameObject.Find("Zombie 1");
            }

        
    }
    
    void CheckForDeath()
    {
        if (zombieHealth - 10f <= 0.01)
        {
            SwitchToState(State.Die);
        } 
    }

    public void DeadCompleted()
    {
        Destroy(gameObject);
    }
    
    private void OnDestroy() //called, when enemy will be destroyed
    {
        //TODO: need to implement random drop
        Instantiate(drop, transform.position, drop.transform.rotation); //dropped coin
    }
    
    

    protected void OnDisable()
    {
        CancelInvoke("SwitchToWalk");
        CancelInvoke("CheckForDeath");
        SwitchToState(State.Run);
        
    }
    
    protected void SwitchToState(State newState)
    {
        transitionActive = true;
        currentState = newState;
    }

    void UpdateZombieAnimator(bool walk, bool run, bool die)
    {
        zombieAnimator.SetBool("IsWalking", walk);
        zombieAnimator.SetBool("IsRunning", run);
        zombieAnimator.SetBool("IsDead", die);
    }

    void SwitchToWalk()
    {
        SwitchToState(State.Walk);
    }

    bool InView(GameObject target, float viewingAngle, float viewingDistance)
    {
        float dotProduct = Vector3.Dot(transform.forward,
            Vector3.Normalize(target.transform.position - transform.position));
        float view = 1.0f - viewingAngle;
        float distance = (transform.position - target.transform.position).magnitude;
        return dotProduct >= view && distance < viewingDistance;
    }

    Vector3 ValidDestination()
    {
        float[,] boundaries = { { 200f, 300f }, { 100f, 200f } };
        float x = Random.Range(boundaries[0, 0], boundaries[0, 1]);
        float z = Random.Range(boundaries[1, 0], boundaries[1, 1]);
        Vector3 destination = new Vector3(x,
            Terrain.activeTerrain.SampleHeight(new Vector3(x, 0.0f, z)), z);
        return destination;
    }

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Bryce")//or tag
        {
            collision.gameObject.GetComponent<PlayerController>().PlayerHpSystem.TakeDamage(15f);
            isBryceDead = true;
        }
    }
}