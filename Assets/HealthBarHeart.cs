using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarHeart : MonoBehaviour
{
    private GameObject playerObj;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.Find("Bryce");
    }

    // Update is called once per frame
    void Update()
    {
        float currentHealth = playerObj.GetComponent<HPSystem>().currentHealth;
        float maxHealth = playerObj.GetComponent<HPSystem>().maxHealth;
        gameObject.GetComponent<Image>().fillAmount = currentHealth / maxHealth;

    }
}
