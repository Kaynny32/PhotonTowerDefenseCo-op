using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerBase : MonoBehaviour
{
    public float Range;
    public float Damage;
    public float Hp;

    public abstract void Attack();
}
