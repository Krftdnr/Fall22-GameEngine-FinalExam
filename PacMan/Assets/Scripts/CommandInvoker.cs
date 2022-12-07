using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker : MonoBehaviour
{
    GameControls inputAction;

    static Queue<Command> commandBuffer;
    static List<Command> commandHistory;
    static int counter;

    //Subject subject = new Subject();

    // Start is called before the first frame update
    void Start()
    {
        commandBuffer = new Queue<Command>();
        commandHistory = new List<Command>();

        inputAction = PlayerInputController.controller.inputAction;

        inputAction.Player.Undo.performed += cntxt => UndoSeven();
        //inputAction.Editor.Redo.performed += cntxt => RedoCommand();
    }

    public static void AddCommand(Command command)
    {
        while (commandHistory.Count > counter)
        {
            commandHistory.RemoveAt(counter);
        }

        commandBuffer.Enqueue(command);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (commandBuffer.Count > 0)
        {
            Command c = commandBuffer.Dequeue();
            c.Perform();

            commandHistory.Add(c);
            counter++;
            Debug.Log("Command history length: " + commandHistory.Count);
        }
    }

    public void UndoCommand()
    {
        if (commandBuffer.Count <= 0)
        {
            if (counter > 0)
            {
                counter--;
                commandHistory[counter].Undo();
            }
        }
    }

    public void UndoSeven()
    {
        for (var i = 0; i < 6; i++)
            UndoCommand();
    }

    //public void RedoCommand()
    //{
    //    if (commandBuffer.Count <= 0)
    //    {
    //        if (counter < commandHistory.Count)
    //        {
    //            commandHistory[counter].Redo();
    //            counter++;
    //        }
    //    }
    //}
}
