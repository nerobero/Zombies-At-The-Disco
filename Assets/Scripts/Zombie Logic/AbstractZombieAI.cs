using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

namespace Zombie_Logic
{
    public class AbstractZombieAI : MonoBehaviour
    {
        private enum State
        {
            Chill,
            Walk,
            Run,
            Die,
            Hit
        }

        [SerializeField] private GameObject coin;

        [SerializeField] private State currentState;
        private bool transitionActive;

        [SerializeField] private Vector3 currentDestination;

        private float runSpeed;
        private float damageValue;
        private float zombieHealth;

        private float walkSpeed = 5f;
        private const float viewAngle = .25f;
        private const float viewDistance = 15f;

        private GameObject bryce;
        private Animator zombieAnimator;

        [SerializeField] private AudioClip currentSong;
        //private JukeBox juke;

        private bool isBryceDead;

        private static readonly int IsHit = Animator.StringToHash("IsHit");
        private static readonly int IsWalking = Animator.StringToHash("IsWalking");
        private static readonly int IsRunning = Animator.StringToHash("IsRunning");
        private static readonly int IsDead = Animator.StringToHash("IsDead");

        // Start is called before the first frame update
        private void Start()
        {
            bryce = GameObject.FindWithTag("Player");
            walkSpeed = GetComponent<NavMeshAgent>().speed;
            zombieAnimator = GetComponent<Animator>();
            SwitchToState(State.Chill);
            // juke = gameObject.AddComponent<JukeBox>();

            int random = Random.Range(1, 5);

            switch (random)
            {
                case 1:
                    runSpeed = 7f;
                    zombieHealth = 20f;
                    damageValue = 30f;
                    break;
                case 2:
                    runSpeed = 20f;
                    zombieHealth = 10f;
                    damageValue = 10f;
                    break;
                case 3:
                    runSpeed = 15f;
                    zombieHealth = 15f;
                    damageValue = 15f;
                    break;
                case 4:
                    runSpeed = 30f;
                    zombieHealth = 1f;
                    damageValue = 5f;
                    break;
            }
        }

        // Update is called once per frame
        private void Update()
        {
            switch (currentState)
            {
                case State.Chill:
                    if (transitionActive)
                    {
                        currentDestination = transform.position;
                        GetComponent<NavMeshAgent>().destination = currentDestination;
                        UpdateZombieAnimator(false, false, false, false);
                        GetComponent<NavMeshAgent>().speed = 0f;
                        transitionActive = false;
                        Invoke(nameof(SwitchToWalk), 5f);
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
                        UpdateZombieAnimator(true, false, false, false);
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
                        CancelInvoke(nameof(SwitchToWalk)); 
                        UpdateZombieAnimator(false, true, false, false);
                        GetComponent<NavMeshAgent>().speed = runSpeed;
                        transitionActive = false;
                    }

                    currentDestination = bryce.transform.position;
                    GetComponent<NavMeshAgent>().destination = currentDestination;

                    break;

                case State.Hit:
                    if (transitionActive)
                    {
                        CancelInvoke(nameof(SwitchToWalk));
                        currentDestination = transform.position;
                        GetComponent<NavMeshAgent>().destination = currentDestination;
                        GetComponent<NavMeshAgent>().speed = 0f;
                        UpdateZombieAnimator(false, false, false, true);
                        Debug.Log("Hit!");
                        transitionActive = false;
                    }
                    break;

                case State.Die:
                    if (transitionActive)
                    { 
                        var position = transform.position;
                        GetComponent<NavMeshAgent>().destination = currentDestination;
                        currentDestination = position;
                        GetComponent<NavMeshAgent>().speed = 0f;
                        UpdateZombieAnimator(false, false, true, true);
                        Debug.Log("dead");
                        transitionActive = false;
                    }

                    break;
            }
            
            CheckForDeath();

            if (isBryceDead)
            {
               SwitchToState(State.Chill);
            }
        }

        void CheckForDeath()
        {
            if (zombieHealth <= 0)
            {
                SwitchToState(State.Die);
            }
        }

        public void DeadCompleted()
        {
            Destroy(gameObject);
            int random = Random.Range(0, 101);
            switch (random)
            {
                case <= 51:
                    Instantiate(coin, transform.position + (2 * Vector3.up),  Quaternion.identity);
                    Debug.Log("And god said let there be a coin");
                    break;
                default:
                    Debug.Log("No coin for you >:(");
                    break;
            }
        }

        void SwitchToState(State newState)
        {
            transitionActive = true;
            currentState = newState;
        }

        void UpdateZombieAnimator(bool walk, bool run, bool die, bool hit)
        {
            zombieAnimator.SetBool(IsWalking, walk);
            zombieAnimator.SetBool(IsRunning, run);
            zombieAnimator.SetBool(IsDead, die);
            zombieAnimator.SetBool(IsHit, hit);
        }

        void SwitchToWalk()
        {
            SwitchToState(State.Walk);
        }

        bool InView(GameObject target, float viewingAngle, float viewingDistance)
        {
            var transform1 = transform;
            var position = transform1.position;
            var position2 = target.transform.position;

            float dotProduct = Vector3.Dot(transform1.forward, Vector3.Normalize(position2 - position));
            float view = 1.0f - viewingAngle;
            float distance = (position - position2).magnitude;
            return dotProduct >= view && distance < viewingDistance;
        }

        Vector3 ValidDestination()
        {
            float[,] boundaries = { { 280f, 343f }, { 138f, 172f } };
            var x = Random.Range(boundaries[0, 0], boundaries[0, 1]);
            var z = Random.Range(boundaries[1, 0], boundaries[1, 1]);
            var destination = new Vector3(x,
                Terrain.activeTerrain.SampleHeight(new Vector3(x, 0.0f, z)), z);
            return destination;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.CompareTag("Player")) 
            {
                collision.gameObject.GetComponent<PlayerController>().PlayerHpSystem.TakeDamage(damageValue);

                if (collision.gameObject.GetComponent<PlayerController>().PlayerHpSystem.currentHealth == 0)
                    isBryceDead = true;
            }
        }

        public void HitComplete()
        {
            SwitchToState(zombieHealth != 0 ? State.Run : State.Die);
        }

        public void TakeDamage(float damage)
        {
            zombieHealth -= damage;
            SwitchToState(State.Hit);

            Debug.Log("zombie taking damage: health now " + zombieHealth);
        }

        //TODO: call this method when the player uses the jukebox
        public void MusicTime(int index)
        {
            //Tentative to change
            //currentSong = juke.GetSong(index);

            switch (index)
            {
                case <= 3:
                    if (runSpeed == 15f || damageValue == 15f || zombieHealth == 15f)
                    {
                        Deactivate();
                    }

                    break;

                case >= 4 and <= 7:
                    if (runSpeed == 7f || zombieHealth == 20f || damageValue == 30f)
                    {
                        Deactivate();
                    }

                    break;

                case >= 8 and <= 10:
                    if (runSpeed == 20f || zombieHealth == 10f || damageValue == 10f)
                    {
                        Deactivate();
                    }
                        break;

                case 11:
                    //the only fan of thriller :p
                    if (runSpeed == 30f || zombieHealth == 1f || damageValue == 5f) 
                    {
                        Deactivate();
                    }
                    break;
            }
        }

        private void Deactivate()
        {
          SwitchToState(State.Chill);
        }

        private void SecretDeath()
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                SwitchToState(State.Die);
            }
        }
    }
}