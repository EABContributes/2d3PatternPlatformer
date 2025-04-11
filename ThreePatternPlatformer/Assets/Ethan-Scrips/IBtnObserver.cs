using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBtnObserver 
{
    void onButtonActivated();
    void onButtonDeactivated();
}
