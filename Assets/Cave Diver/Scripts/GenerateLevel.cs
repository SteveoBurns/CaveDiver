using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    [SerializeField] private List<Transform> levelModules = new List<Transform>();

    private Transform nextModule;


    private float oldX = 0;
    


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
    }

    private void SpawnLevel()
    {
        float xPos = Camera.main.transform.position.x;


        if (oldX - xPos <= 0.1f)
        {
            nextModule = GameObject.Instantiate(levelModules[Random.Range(0, levelModules.Count)], new Vector3(xPos + 40, 0, 0), Quaternion.identity);
            oldX = nextModule.position.x - 20;
        }
        
    }

}
