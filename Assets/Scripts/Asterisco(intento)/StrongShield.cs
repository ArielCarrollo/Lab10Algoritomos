using UnityEngine;
using System.Collections.Generic;
public class StrongShield : Item
{
    public override void ApplyEffect(PlayerAttributes playerAttributes)
    {
        playerAttributes.baseHealth += 5;
        playerAttributes.UpdateStats(); 
    }
}
