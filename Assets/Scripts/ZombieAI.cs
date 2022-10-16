using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class ZombieAI : MonoBehaviour
{
    
    private enum State
    {
        Chill, Walk, Run, Die
    }

    [SerializeField]
    private State currentState;
    private bool transitionActive;

    [SerializeField]
    private Vector3 currentDestination;

    [SerializeField] 
    private float runSpeed;
    private float walkSpeed;
    
    private float viewAngle = 0.25f;
    private float viewDistance = 5f;

    private GameObject megan;
    private Animator zombieAnimator;

    private HPSystem meganHP;
    

    
    // Start is called before the first frame update
    private void Start()
    {
        GameObject megan = GameObject.Find("Megan");
        walkSpeed = GetComponent<NavMeshAgent>().speed;
        zombieAnimator = GetComponent<Animator>();
        switchToState(State.Chill);
        meganHP = new GameObject().AddComponent<HPSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case State.Chill:
                if (transitionActive)
                {
                    //currentDestination = transform.position;
                    //GetComponent<NavMeshAgent>().destination = currentDestination;
                    Invoke("switchToWalk", Random.Range(5.0f, 6.0f));
                    updateZombieAnimator(false, false, false);
                    transitionActive = false;
                }
                break;
            case State.Walk:
                if (transitionActive)
                {
                    //currentDestination = validDestination();
                    //GetComponent<NavMeshAgent>().destination = currentDestination;
                    updateZombieAnimator(true, false, false);
                    
                    transitionActive = false;
                }

                if ((transform.position = currentDestination).magnitude < 2.5f)
                {
                    switchToState(State.Chill);
                }
                break;
            case State.Run:
                if (transitionActive)
                {
                    updateZombieAnimator(false, true, false);

                    transitionActive = false;
                }
                break;
            case State.Die:
                updateZombieAnimator(false, false, true);
                Destroy(this);
                break;
        }
    }

    void switchToState(State newState)
    {
        transitionActive = true;
        currentState = newState;
        
    }

    void updateZombieAnimator(bool walk, bool run, bool die)
    {
        zombieAnimator.SetBool("IsWalking", walk);
        zombieAnimator.SetBool("IsRunning", run);
        zombieAnimator.SetBool("IsDead", die);
    }

    void switchToWalk()
    {
        switchToState(State.Walk);
    }

    Vector3 validDestination()
    {
        float[,] boundaries = { { 0f, 140f }, { -60f, 40f } };
        float x = Random.Range(boundaries[0, 0], boundaries[0,1]);
        float z = Random.Range(boundaries[1, 0], boundaries[1,1]);
        Vector3 destination = new Vector3(x, 
            Terrain.activeTerrain.SampleHeight(new Vector3(x, 0, z)), z);
        return destination;
    }

    void dealDamage()
    {
        if (megan.GetComponent<CapsuleCollider>().radius - this.GetComponent<CapsuleCollider>().radius <= 1)
        {
            meganHP.TakeDamage(10);
        }
    }
}
