using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class BlockDataClass {

    public byte val;
    public int type;

    public BlockDataClass(int typ=0,byte _val=255)
    {
        val = _val;
        type = typ;
    }

}
