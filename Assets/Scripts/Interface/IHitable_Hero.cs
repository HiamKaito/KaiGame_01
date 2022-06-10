using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHitable_Hero
{
    void Hit(Enemy ememy, float damageDeal);
    void Hit(ObjectCanBreak objectCanBreak, float damageDeal);
    void HitBy(E_Goblin e_Goblin, float damageDeal);
    void HitBy(E_Mushroom e_Mushroom, float damageDeal);
}
