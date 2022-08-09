using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollactableStrawberry : ItemCollatableBase
{
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddSberry();
    }
}
