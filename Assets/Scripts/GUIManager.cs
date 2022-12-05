using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GUIManager : MonoBehaviour
{
    private GameObject Bryce;
    private GameObject waveSpawner;
    
    private GroupBox report;
    private Label health;
    private Label weapon;
    private Label wave;
    
    // Start is called before the first frame update
    void Start()
    {
        Bryce = GameObject.Find("Bryce");
        waveSpawner = GameObject.Find("WaveSpawner1");

        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        report = root.Q<GroupBox>("report");
        wave = root.Q<Label>("WaveNumber");
        weapon = root.Q<Label>("Weapon");
        health = root.Q<Label>("Health");

    }

    // Update is called once per frame
    void Update()
    {
        health.text = "Health: " + Bryce.GetComponent<HPSystem>().currentHealth;
        wave.text = "Wave: " + (waveSpawner.GetComponent<WaveSpawner>().nextWave + 1);
    }
}
