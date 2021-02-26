using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class Player : MonoBehaviour
{

    public bool idle;
    private CharacterController myCharacterController;
    private Animator animator;
    public float walkMovement;
    public float speed = 100;
    public Text resumeText;
    // Start is called before the first frame update
    void Start()
    {
        myCharacterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        idle = true;
    }

    // Update is called once per frame
    void Update()
    {
            myCharacterController.Move(new Vector3(walkMovement * Time.deltaTime * speed, 0, 0));

            if (transform.position.x >= 8.5)
            {
                transform.position = new Vector3(8.49f, transform.position.y, transform.position.z);

            }

            else if (transform.position.x <= -8.5)
            {
                transform.position = new Vector3(-8.49f, transform.position.y, transform.position.z);
            }



            if (walkMovement == 0 && !idle && !GameManager.Instance.gamePaused)
            {
                animator.SetBool("isRunning", false);
                idle = true;
                transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            }

        
    }

    public void OnWalk(InputAction.CallbackContext context)
    {
        
        walkMovement = context.ReadValue<float>();
        animator.SetBool("isRunning", true);
        idle = false;
        if (!GameManager.Instance.gamePaused)
        {
            if (walkMovement < 0)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
            }
            else
            {
                transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
            }
        }
    }

    public void PauseGame()
    {
        if (!GameManager.Instance.gamePaused && GameManager.Instance.gamePlay)
        {
            Time.timeScale = 0;
            GameManager.Instance.gamePaused = true;
            resumeText.gameObject.SetActive(true);
        }
        else if (GameManager.Instance.gamePaused && GameManager.Instance.gamePlay)
        {
            Time.timeScale = 1;
            GameManager.Instance.gamePaused = false;
            resumeText.gameObject.SetActive(false);
        }

    }

}
