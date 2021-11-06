using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttacker
{
    void Atk(float dmg);
}

public interface IAim {
    void Aim();
}
