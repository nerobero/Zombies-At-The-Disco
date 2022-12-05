<<<<<<< HEAD
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
//
// public class HealthBarHeart : MonoBehaviour
// {
//     // Start is called before the first frame update
//     void Start()
//     {
//         
//     }
//
//     // Update is called once per frame
//     void Update()
//     {
//         int currentHealth = (int)playerObj.getComponent<HPSystem>().currentHealth;
//         gameObject.GetComponent<Image>.fillAmount = currentHealth;
//         
//     }
// }
=======
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
>>>>>>> 1db23ff26fc058f32ad4b97359979273dfa37d55
