using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    public bool canSpawn = true;    //if it's true, the script will keep spawning sheep
    public GameObject sheepPrefab;
    public float timeBetweenSpawns; //Time between the spawning of sheep 
    public List<Transform> sheepSpawnPositions = new List<Transform>(); //Positions from where the sheep will be spawned
    private List<GameObject> sheepList = new List<GameObject>(); //Sheep alive in the scene
    private float newSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // this fuction will be called everytime we want to create a sheep
    private void SpawnSheep()
    {
        // Obtain one of the spawn positions randomly 
        Vector3 randomPosition = sheepSpawnPositions[Random.Range(0, sheepSpawnPositions.Count)].position;

        // Create the sheep obj and add it to the list
        GameObject sheep = Instantiate(sheepPrefab, randomPosition, sheepPrefab.transform.rotation);
        newSpeed += 3;
        sheep.GetComponent<SheepControl>().SetSpeed(newSpeed);
        

        sheepList.Add(sheep);

        sheep.GetComponent<SheepControl>().SetSpawner(this);
    }

    // We'll create sheep every timeBetweenSpawns sec. while canSpawn is true -> we use a Coroutine
    private IEnumerator SpawnRoutine() // 1
    {
        while (canSpawn)
        {
            SpawnSheep();
            yield return new WaitForSeconds(timeBetweenSpawns); // Pause the execution timeBetweenSpawns sec
        }
    }

    //This method removes the sheep obj from the sheepList
    public void RemoveSheepFromList(GameObject sheep)
    {
        sheepList.Remove(sheep);
    }


    public void DestroyAllSheep()
    {
        //Iterate the sheepList and remove every sheep obj
        foreach (GameObject sheep in sheepList) // 1
        {
            Destroy(sheep); // 2
        }
        sheepList.Clear();  //Clear the list references
    }
}
