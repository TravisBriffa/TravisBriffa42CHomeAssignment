using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Player : MonoBehaviour
{
    /* In Unity we will be using 2 types of methods; Built-in Methods and User Defined methods.
     * Built in: These methods have their names already setup by Unity since the Unity compiler knows when 
     * the method should be called during the game execution. We only need to implement the code which will
     * be executed upon method call.
     * Note: Upon method definition we need to make sure that the method name is written without spelling 
     * mistakes and in the proper casing.
     * User Defined: These methods are created by the current developer to better organise the code.
     * Since the name will be invented it is important that we don't use the same name which is already
     * used for other built-in methods, keywords and variables.
     * Since the Unity compiler does not call these methods, it is important to remember that we, as
     * developers call the method where is required.
     */

    //global variables
    [SerializeField] float movementSpeed = 5f;


    [SerializeField] int playerHealth = 100;


    [SerializeField] AudioClip damage;
    [SerializeField] [Range(0, 1)] float damageVolume = 0.75f;
    [SerializeField] AudioClip carOvertake;
    [SerializeField] [Range(0, 1)] float carOvertakeVolume = 0.1f;

    Coroutine firingCoroutine;

    float xMin;
    float xMax;
    float yMin;
    float yMax;
    void Start()
    {
        SetUpBoundaries();


    }


    void Update()
    {
        // print("This is the Update method");
        Move();
    }

    
    
    void Move()
    {


        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;



        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);


        transform.position = new Vector3(newXPos,transform.position.y);

    }
    void SetUpBoundaries()
    {
        Camera gameCamera = Camera.main; 
        float padding = 0.5f;

 

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;

    }

    

    


   
  
    private void OnTriggerEnter2D(Collider2D collision)
    {

        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();

        if (!damageDealer) 
        {
            return; 
        }

        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        playerHealth -= damageDealer.GetDamage(); // health = health - damagedDealer.GetDamage();
        // A -= B; => A = A - B;
        damageDealer.Hit();

        if (playerHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        AudioSource.PlayClipAtPoint(damage, Camera.main.transform.position, damageVolume);

        Destroy(gameObject);
    }
}


