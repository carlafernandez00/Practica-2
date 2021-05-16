using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMachineControl : MonoBehaviour
{
    public GameObject hayShootObj;  // Reference to the Hay Bale object
    public Transform haySpawpoint;

    public float thresholdShoot;   // Smallest amount of time between shoots
    private float shootTimer;      // Time that keeps the track whether the machine can shoot

    public Transform modelParent;  // Parent transform of the model 

    // reference to the different hay machines
    public GameObject blueModelPrefab;
    public GameObject yellowModelPrefab;
    public GameObject redModelPrefab;

    // Start is called before the first frame update
    void Start()
    {
        LoadModel();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        Move();

        // Shooting
        UpdateShooting();
    }

    
	// Shoot is called every time the user wants to shoot a hay bale  
    private void ShootHay()
    {
       Instantiate(hayShootObj,haySpawpoint.position, Quaternion.identity, transform);
       SoundManager.Instance.PlayShootClip(); //make this sound when a hay is shooted
    }

    private void UpdateShooting()
    {
        shootTimer -= Time.deltaTime;
        if(shootTimer<=0 && Input.GetKey(KeyCode.Space))
        {
            shootTimer = thresholdShoot;
            ShootHay();
        }
    }

    // Define the movement of the Hay Machine
    private void Move()
    {
        float inputKeyValue = Input.GetAxis("Horizontal");
        float moveAmount = 30;

        if (inputKeyValue > 0 && transform.position.x < 22)
        {
            transform.Translate(Vector3.right * moveAmount * Time.deltaTime);
        }
        else if (inputKeyValue < 0 && transform.position.x > -22)
        {
            transform.Translate(Vector3.left * moveAmount * Time.deltaTime);
        }
    }

    private void LoadModel()
    {
        Destroy(modelParent.GetChild(0).gameObject); // Destroy the current model

        // Instantiate a hay machine model based on the color chosen
        switch (GameSettings.hayMachineColor)
        {
            case HayMachineColor.Blue:
                Instantiate(blueModelPrefab, modelParent);
            break;

            case HayMachineColor.Yellow:
                Instantiate(yellowModelPrefab, modelParent);
            break;

            case HayMachineColor.Red:
                Instantiate(redModelPrefab, modelParent);
            break;
        }



    }
}
