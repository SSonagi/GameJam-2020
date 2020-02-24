using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    float jump = 0f;
    float jumpRememberTime = 0.1f;
    bool jumped = false;
    public GameObject camOne;
    public GameObject camTwo;

    AudioListener camOneAudio;
    AudioListener camTwoAudio;
    float camSwitch = 1f;


    // Start is called before the first frame update
    void Start()
    {

        camOneAudio = camOne.GetComponent<AudioListener>();
        camTwoAudio = camTwo.GetComponent<AudioListener>();

        cameraChange(PlayerPrefs.GetInt("CameraPosition"));
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        jump -= Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            jump = jumpRememberTime;
        } 

        if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            controller.Move(0, false, false, true);
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            camSwitch = cameraChange(camSwitch);
            controller.tpPlayer();
        }
    }

    private void FixedUpdate()
    {
        jumped = controller.Move(horizontalMove * Time.fixedDeltaTime * camSwitch, false, jump > 0, false);
        if (jumped)
        {
            jump = 0;
            jumped = false;
        }
    }

    private float cameraChange(float CameraPos) {
        if(CameraPos == 1f) {
            camTwo.SetActive(true);
            camTwoAudio.enabled = true;
            camOne.SetActive(false);
            camOneAudio.enabled = false;
            return -1f;
        } else  {
            camOne.SetActive(true);
            camOneAudio.enabled = true;
            camTwo.SetActive(false);
            camTwoAudio.enabled = false;
            return 1f;
        }
    }
}
