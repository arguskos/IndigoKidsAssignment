using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disk2D : AbstractDisk {

    public override Vector3 GetSize()
    {
        return GetComponent<SpriteRenderer>().bounds.size;
    }
}
