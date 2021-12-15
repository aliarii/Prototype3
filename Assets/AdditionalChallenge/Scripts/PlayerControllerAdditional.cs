using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerAdditional : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    public bool isOnGround = true;
    public bool gameOver = false;
    public bool canJump = true;
    public static Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true && !gameOver && doubleJump > 0)
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver && isOnGround)
        {

            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 0.6f);
            canJump = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !gameOver && canJump)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 0.6f);
            canJump = false;
        }

    }
    private void OnCollisionEnter(Collision other)
    {
        //if(other.gameObject.CompareTag("Ground")) gibi de yapılabilir
        if (other.transform.tag == "Ground")
        {
            isOnGround = true;
            canJump = true;
            dirtParticle.Play();
        }
        else if (other.transform.tag == "Obstacle")
        {
            //GameOver();
            gameOver = true;
            Debug.Log("GameOver");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 0.6f);
        }
    }
    private void GameOver()
    {
        Debug.Log("GameOver");
    }
}
