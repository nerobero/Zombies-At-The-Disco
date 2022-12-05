using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zombie_Logic;

public class JukeboxLogic : MonoBehaviour
{
    private GameObject playerObj = null;

    private GameObject juke = null;
    public GameObject jukeboxDisplay;

    public GameObject jukeboxDisplayChild;
    [SerializeField] public AudioClip[] songlist;
    private AudioSource source;
    int songCounter = 0;
    private GameObject zombie;
    
    public PlayerInputControl playerinputs;

    //changing music
    private InputAction interact;
    
    // Start is called before the first frame update
    void Start()
    {
        if (playerObj == null)
            playerObj = GameObject.FindGameObjectWithTag("Player");
        if (juke == null)
            juke = GameObject.Find("Jukebox");
        if (zombie == null)
            zombie = GameObject.FindWithTag("Zombie");
        jukeboxDisplay.SetActive(false);
        source = gameObject.GetComponent<AudioSource>();
        source.clip = songlist[songCounter];
        source.Play();
        zombie.GetComponent<AbstractZombieAI>().MusicTime(songCounter);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Player Position: X = " + playerObj.transform.position.x +
        //" --- Y = " + playerObj.transform.position.y + " --- Z = " +
        //playerObj.transform.position.z);
        float dist = Vector3.Distance(playerObj.transform.position, juke.transform.position);

        if (dist <= 10f && Input.GetKey(KeyCode.F) )
        {
            jukeboxDisplay.SetActive(true);
            
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Debug.Log("Left arrow");
                //(jukeboxDisplayChild.GetComponent("JukeboxCanvas_Front")).transform.Rotate(0.0f,
                //0.0f, 36.0f, Space.Self);
                //jukeboxDisplay.transform.Rotate(0.0f, 0.0f, 36.0f, Space.Self);

                
                GameObject childGUI = jukeboxDisplay.transform.GetChild(1).gameObject;
                childGUI.transform.Rotate(0.0f, 0.0f, -36.0f, Space.Self);
                songCounter++;
                Debug.Log(songlist.Length);
                if (songCounter >= songlist.Length)
                {
                    songCounter = 0;
                }
                source.clip = songlist[songCounter];
                source.Play();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                GameObject child = jukeboxDisplay.transform.GetChild(1).gameObject;
                child.transform.Rotate(0.0f, 0.0f, 36.0f, Space.Self);
                songCounter--;
                if (songCounter < 0)
                {
                    songCounter = songlist.Length - 1;
                }
                source.clip = songlist[songCounter];
                source.Play();
                //Debug.Log("Euler angles: " + child.eulerAngles.z);
            }
        }
        else
        {
            jukeboxDisplay.SetActive(false);
        }
    }
    
    /**private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision started.");
    }

    private void OnCollisionStay(Collision collision)
    {
        jukeboxDisplay.SetActive(true);
    }
    
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Collision ended.");
        jukeboxDisplay.SetActive(false);
    }**/
}
