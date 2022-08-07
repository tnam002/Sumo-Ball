using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;

    private GameObject focalPoint;
    public GameObject powerupIndicator;

    public float playerSpeed = 10;
    public float repelPower = 30;

    public bool hasPowerup = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        playerRigidbody.AddForce(focalPoint.transform.forward * vertical * playerSpeed);
        powerupIndicator.transform.position = transform.position;

        if (transform.position.y < -10)
        {
            if (SpawnManager.level > DataManager.Instance.highScore)
            {
                DataManager.Instance.highScore = SpawnManager.level;
                DataManager.Instance.heldBy = DataManager.Instance.playerName;
                DataManager.Instance.Save();
            }
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            hasPowerup = true;
            StartCoroutine(CountdownCoroutine());
            powerupIndicator.SetActive(true);
        }
    }

    IEnumerator CountdownCoroutine()
    {
        yield return new WaitForSeconds(10);
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Vector3 repelVector = (collision.gameObject.transform.position - transform.position).normalized;
            collision.gameObject.GetComponent<Rigidbody>().AddForce(repelVector * repelPower, ForceMode.Impulse);
        }
    }
}
