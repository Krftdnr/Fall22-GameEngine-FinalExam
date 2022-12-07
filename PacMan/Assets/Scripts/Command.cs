 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Command
{
    public void Perform();
    public void Undo();
    //public void Redo();
}
