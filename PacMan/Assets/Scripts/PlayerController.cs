using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameControls inputAction;

    public float moveSpeed;

    Vector3 move;

    void Start()
    {
        inputAction = PlayerInputController.controller.inputAction;

        inputAction.Player.MoveLeft.performed += cntxt => move = Vector2.left;
        //inputAction.Player.MoveLeft.canceled += cntxt => move = Vector2.zero;

        inputAction.Player.MoveRight.performed += cntxt => move = Vector2.right;
        //inputAction.Player.MoveRight.canceled += cntxt => move = Vector2.zero;

        inputAction.Player.MoveUp.performed += cntxt => move = Vector2.up;
        //inputAction.Player.MoveUp.canceled += cntxt => move = Vector2.zero;

        inputAction.Player.MoveDown.performed += cntxt => move = Vector2.down;
        //inputAction.Player.MoveDown.canceled += cntxt => move = Vector2.zero;

        inputAction.Player.Quit.performed += cntxt => QuitGame();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(move * moveSpeed);
        //Debug.Log(transform.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.CompareTag("Collectable"))
        {
            EatItem(collision.gameObject);
        }
    }

    private void EatItem(GameObject item)
    {
        Command command = new EatItemCommand(item);
        CommandInvoker.AddCommand(command);
    }
    
    void QuitGame()
    {
        Application.Quit();
    }
}
