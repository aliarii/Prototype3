using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftAdditional : MonoBehaviour
{
    private float speed = 30;
    private float leftBound = -15;
    private PlayerControllerAdditional playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerControllerAdditional>();
        //isGameFast = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);

        }
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            speed = 50;
            PlayerControllerAdditional.playerAnim.speed = 2;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            speed = 30;
            PlayerControllerAdditional.playerAnim.speed = 1;
        }
    }
}
