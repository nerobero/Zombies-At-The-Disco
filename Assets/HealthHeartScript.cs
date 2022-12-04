using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class HealthHeartScript : MonoBehaviour
{
    private GameObject playerObj = null;

    
    //public event Action<float> OnHealthPctChanged = delegate { };
    // Start is called before the first frame update
    private void onStart()
    {
        if (playerObj == null)
            playerObj = GameObject.Find("Bryce");
    }
    void OnEnable()
    {
        //currentHealth = maxHealth;
    }
    
    public void modifyHealth(int amount)
    {

    }

    // Update is called once per frame
    void Update()
    {
        //int currentHealth = (int)(playerObj.GetComponent<HPSystem>().currentHealth / 100); 
        
        //gameObject.GetComponent<Image>().fillAmount = currentHealth;
        if (Input.GetKeyDown("g"))
        {
            gameObject.GetComponent<Image>().fillAmount -= 0.1f;
        }
    }
}
