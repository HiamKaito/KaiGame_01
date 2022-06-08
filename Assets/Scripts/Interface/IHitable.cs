using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHitable
{
    void takeDamage();
    void takeDamage(float damage);
    void takeDamage(float damage, string damageDealer);
}
