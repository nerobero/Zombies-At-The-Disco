using System;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class ZombieAI : MonoBehaviour
{
    private enum State
    {
        Chill,
        Walk,
        Run,
        Die
    }

    [SerializeField] private State currentState;
    private bool transitionActive;

    [SerializeField] private Vector3 currentDestination;

    [SerializeField] private float runSpeed;
    private float walkSpeed = 5f;

    private float viewAngle = 5f;
    private float viewDistance = 50f;

    private GameObject bryce;
    private Animator zombieAnimator;

    [SerializeField] private float zombieHealth = 15f;

    private bool isBryceDead = false;

    // Start is called before the first frame update
    private void Start()
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

    private void OnDisable()
    {
        CancelInvoke("SwitchToWalk");
        CancelInvoke("CheckForDeath");
        SwitchToState(State.Run);
        
    }
    
    void SwitchToState(State newState)
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "Bryce")//or tag
        {
            collision.gameObject.GetComponent<PlayerController>().PlayerHpSystem.TakeDamage(15f);
            isBryceDead = true;
        }
    }
}