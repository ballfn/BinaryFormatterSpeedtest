using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct BlockData {

    public byte offset;
    public int type;

    public BlockData(int typ=0,byte val=255)
    {
        offset = val;
        type = typ;
    }

}
