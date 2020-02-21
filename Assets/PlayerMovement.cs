using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;

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

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
        } 
        
        if(Input.GetKeyDown(KeyCode.C)) {
            camSwitch = cameraChange(camSwitch);
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime * camSwitch, false, jump);
        jump = false;
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
