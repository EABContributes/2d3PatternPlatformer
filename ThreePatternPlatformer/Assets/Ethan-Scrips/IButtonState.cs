using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IButtonState
{
    void EnterState(ButtonTile aButtonTile);
    void ExecuteState(ButtonTile aBuutonTile);
    void ExitState(ButtonTile aButtonTile);
}
