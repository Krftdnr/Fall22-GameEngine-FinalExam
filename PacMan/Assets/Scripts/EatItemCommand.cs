using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatItemCommand : Command
{
    GameObject item;

    public EatItemCommand(GameObject pellet)
    {
        item = pellet;
    }

    public void Perform()
    {
        item.SetActive(false);
    }

    public void Undo()
    {
        item.SetActive(true);
    }
}
