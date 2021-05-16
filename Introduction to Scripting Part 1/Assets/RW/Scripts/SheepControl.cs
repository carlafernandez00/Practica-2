using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepControl : MonoBehaviour
{
    private float runSpeed;              // speed at which the sheep runs 
    private bool hitByHay;               // controls if the sheep has been hit

    public float gotHayDestroyDelay = 0.5f; 
    public float dropDestroyDelay = 2f;

    private Collider myCollider;
    private Rigidbody myRigidbody;

    private SheepSpawner sheepSpawner;

    public float heartOffset;            //Offset in the Y axis
    public GameObject heartPrefab;       //Reference to the heart obj

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * runSpeed, Space.World);
    }


    // When the sheep is hit by a hay bale
    private void HitByHay()
    {
        sheepSpawner.RemoveSheepFromList(gameObject); //Remove the sheep from the spawner's list

        hitByHay = true;
        runSpeed = 0;
        Destroy(gameObject, gotHayDestroyDelay); //destroy the sheep after the gotHayDestroyDelay delay

        //when a sheep is hit, create a heart
        Instantiate(heartPrefab, transform.position + new Vector3(0, heartOffset, 0), Quaternion.identity);

        //Animate the disappearance of the sheep
        TweenScale tweenScale = gameObject.AddComponent<TweenScale>();
        tweenScale.targetScale = 0;
        tweenScale.timeToReachTarget = gotHayDestroyDelay;

        //Make a sound when the sheep is hit
        SoundManager.Instance.PlaySheepHitClip();

        // we saved a sheep, increase the GameStateManager counter
        GameStateManager.Instance.SavedSheep();
    }

    // Make the sheep drop
    private void Drop()
    {
        sheepSpawner.RemoveSheepFromList(gameObject); //Remove the sheep from the spawner's list
        GameStateManager.Instance.DroppedSheep();     //A sheep dropeed, call the DroppedSheep() method

        myRigidbody.isKinematic = false;        // Now it's non-kinematic so it's affected by gravity
		myCollider.isTrigger = false;           //The sheep becomes a solid obj
        Destroy(gameObject, dropDestroyDelay);  //destroy the sheep after the dropHayDestroyDelay delay

        //Make a sound when the sheep drops
        SoundManager.Instance.PlaySheepDroppedClip();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hay") && !hitByHay)
        {
            Destroy(other.gameObject);  // Destroy the hay bale
            HitByHay();
        }
        else if (other.CompareTag("DropSheep")) {
            Drop();
        }
    }

    // reference to a SheepSpawner
    public void SetSpawner(SheepSpawner spawner)
    {
        sheepSpawner = spawner;
    }

    public float GetSpeed()
    {
        return runSpeed;
    }

    public void SetSpeed(float newSpeed)
    {
        runSpeed = newSpeed;
    }
}
