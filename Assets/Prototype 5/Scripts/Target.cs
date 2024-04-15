using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    private Rigidbody targetRigidBody;
    private GameManager gameManager; //create reference for GameManager's Script to use the methods from the game manager script
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPosition = -2;

    public ParticleSystem explosionParticle; //effect when destorying object. Drag effect to the object in inspector
    public int pointValue; //can assign for each object in the inspector

    // Start is called before the first frame update
    void Start()
    {
        targetRigidBody = GetComponent<Rigidbody>();
        gameManager=GameObject.Find("Game Manager").GetComponent<GameManager>(); //GameManager is the script

        targetRigidBody.AddForce(RandomForce(), ForceMode.Impulse); //Random.Range(min,max)
        targetRigidBody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);  //add torque to let object rotate
    
        transform.position = RandomSpawnPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //when click the object using mouse, destroy the object
    private void OnMouseDown()
    {
        if(gameManager.isGameActive)  //if the game is over, won't run these codes
        {  
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation); //set to current position of the gameobject and same rotation as the explosion particle
            //can use if statement to add/minus score according to the objects
            gameManager.UpdateScore(pointValue); //UpdateScore() method is actually from GameManager's script

        }
    }

    private void OnTriggerEnter(Collider other)
    { 
        //object disappear when run into the sensor
        Destroy(gameObject);

        if(!gameObject.CompareTag("Bad")) //beside bad object, means good objects
        {             
            gameManager.GameOver();
        }
    }

    Vector3 RandomForce()  //since we using Vector3
    {  
        return Vector3.up * Random.Range(minSpeed,maxSpeed);    //it directly mutiply with others, so no need 'new'
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPosition()
    {
        return new Vector3(Random.Range(-xRange,xRange), ySpawnPosition, 0);    //need 'new'
    }

}
