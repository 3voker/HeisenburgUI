using UnityEngine;
using System.Collections;
using System;


    public class PauseMenuManager : MonoBehaviour
    {

        // Use this for initialization
        [SerializeField]
        GameObject pauseMenuPanel;
        Player player;
        Simple3rdPersonCamera thirdpersoncamera;

        bool paused = false;
        bool myCheck = false;

    public KeyCode kbPauseButton;
    public GamepadButtons gpPauseButton;


    bool IsPauseMenuShowing{ get { return pauseMenuPanel.activeSelf; } }

        void Start()
        {
            player = GameObject.FindObjectOfType<Player>();
            thirdpersoncamera = GameObject.FindObjectOfType<Simple3rdPersonCamera>();

            paused = false;
            HidePauseMenu();
    }



        // Update is called once per frame
        void Update()
        {        
            HandleInput();
            UpdateCursor();
           // UpdateThirdPersonController();
        }
        void HandleInput()
        {
        //If bool is true and start button pressed. Pause game. Freeze time.
        //Else will unpause and hide the pause menu.
        if (Input.GetKeyDown(kbPauseButton)
        || (player.controller.gamepadInput && player.controller.myGamepad.GetButtonDown(gpPauseButton))
        && !IsPauseMenuShowing)
        {
            ShowPauseMenu();

            Debug.Log("Hiding Pause Menu");
        }
        else if (Input.GetKeyDown(kbPauseButton) 
            || (player.controller.gamepadInput && player.controller.myGamepad.GetButtonDown(gpPauseButton)) 
            && IsPauseMenuShowing)
            {              
                    Debug.Log("Closing Pause Menu");
                    HidePauseMenu();
                                                            
            }

        }
        public void ShowPauseMenu()
        {
        pauseMenuPanel.SetActive(true);
        thirdpersoncamera.canMoveCamera = false;
        Time.timeScale = 0;
        paused = true;
    }


    public void HidePauseMenu()
    {
        pauseMenuPanel.SetActive(false);
        thirdpersoncamera.canMoveCamera = true;
        Time.timeScale = 1;
        paused = false;
    }

    private void UpdateCursor()
        {
            if (IsPauseMenuShowing)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            //else
            //{
            //    Cursor.visible = false;
            //    Cursor.lockState = CursorLockMode.Locked;
            //}
        }
    }
