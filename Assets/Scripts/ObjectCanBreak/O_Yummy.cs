using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_Yummy : ObjectCanBreak
{
    public override void HitBy(HeroAssassin heroAssassin, float damageDeal)
    {
        Debug.Log(base._stats.Name + " got damaged " + damageDeal + " by " + heroAssassin.stats.Name);
        base.takeDamage(damageDeal);
    }

    public override void HitBy(HeroWizard heroWizard, float damageDeal)
    {
        Debug.Log(base._stats.Name + " got damaged " + damageDeal + " by " + heroWizard.stats.Name);
        base.takeDamage(damageDeal);
    }
}
