using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public bool gameOver;
    public bool hasPowerup = false;
    private Rigidbody playerRb;
    float powerUpStrength = 15;
    //private RotateCamera focalPoint;
    private GameObject focalPoint;
    public GameObject powerUpIndicator;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gameOver = false;
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(Camera.main.transform.forward * forwardInput * speed);

        powerUpIndicator.gameObject.transform.position = transform.position + new Vector3(0, -0.5f, 0);

        if (transform.position.y < -10.0f)
        {
            gameOver = true;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Powerups"))
        {
            hasPowerup = true;
            powerUpIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
            Destroy(other.gameObject);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        powerUpIndicator.gameObject.SetActive(false);
        hasPowerup = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() && hasPowerup)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFrom = collision.gameObject.transform.position - transform.position;

            enemyRb.AddForce(awayFrom * powerUpStrength, ForceMode.Impulse);
        }
    }
}
