using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    [Header("Level Modules")]
    [SerializeField] private List<Transform> levelModules = new List<Transform>();
    [SerializeField] private Transform endLevelModule;


    private Transform nextModule;
    private float oldX = 0;


    [Header("Power Ups")]
    [SerializeField] private GameObject airBubble;
    [SerializeField, Range(0, 1), Tooltip("The chance for an airbubble to spawn. The lower the number the less chance")] 
    private float airBubbleChance;
    [SerializeField] private GameObject flippers;
    [SerializeField, Range(0, 1), Tooltip("The chance for flippers to spawn. The lower the number the less chance")] 
    private float flippersChance;
    [SerializeField] private GameObject healthKit;
    [SerializeField, Range(0, 1), Tooltip("The chance for a Health Kit to spawn. The lower the number the less chance")] 
    private float healthKitChance;


    private bool emergencyAir = true;



    // Start is called before the first frame update
    void Start()
    {
        float xPos = Camera.main.transform.position.x;

        nextModule = GameObject.Instantiate(levelModules[Random.Range(0, levelModules.Count)], new Vector3(xPos + 21, 0, 0), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        SpawnLevel();

        if(PlayerStats.oxygenLevel <= 5 && emergencyAir)
        {
            SpawnEmergencyAir();
            emergencyAir = false;
        }
        if(PlayerStats.oxygenLevel > 5 && !emergencyAir)
        {
            emergencyAir = true;
        }
        
    }

    private void SpawnLevel()
    {
        float xPos = Camera.main.transform.position.x;

        if (Score.score <= 500)
        {

            if (oldX - xPos <= 0.1f)
            {
                SpawnPowerUp();

                nextModule = GameObject.Instantiate(levelModules[Random.Range(0, levelModules.Count)], new Vector3(xPos + 40, 0, 0), Quaternion.identity);
                oldX = nextModule.position.x - 20;

            }
        }
        else
        {
            if (oldX - xPos <= 0.1f)
            {
                SpawnPowerUp();

                nextModule = GameObject.Instantiate(endLevelModule, new Vector3(xPos + 40, 0, 0), Quaternion.identity);
                oldX = nextModule.position.x - 20;
            }
        }
        
    }

    private void SpawnEmergencyAir()
    {        
            float xPos = Camera.main.transform.position.x;

            GameObject.Instantiate(airBubble, new Vector3(xPos + 20, 0, 0), Quaternion.identity);        
    }

    public void SpawnPowerUp()
    {
        float xPos = Camera.main.transform.position.x;

        float chance = Random.Range(0f, 1f);
        //Debug.Log(chance);
        if(chance < airBubbleChance)
        {
            GameObject.Instantiate(airBubble, new Vector3(xPos + 40, 3, 0), Quaternion.identity);            
            Debug.Log("Spawned Air Bubble");
        }
        if (chance < flippersChance)
        {
            GameObject.Instantiate(flippers, new Vector3(xPos + 50, -3.2f, 0), Quaternion.identity);
            Debug.Log("Spawned Flippers");
        }
        if (chance < healthKitChance)
        {
            GameObject.Instantiate(healthKit, new Vector3(xPos + 30, -3.3f, 0), Quaternion.identity);
            Debug.Log("Spawned Health Kit");
        }

    }


}
