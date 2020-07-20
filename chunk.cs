using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
[System.Serializable]
/*********************************************
 * uncomment code to test different data type
 **********************************************/

//struct int,byte
/*
 public class chunk 
{
    public BlockData[,,] data;
    public chunk()
    {
        data = new BlockData[128,256,128];
        for(int x = 0; x < 128; x++)
        {
            for (int y = 0; y < 64; y++)
            {
                for (int z = 0; z< 128; z++)
                {
                    data[x,y,z] = new BlockData(y);
                }
            }
        }
    }
}
 */
//class int,byte

public class chunk
{
    public BlockDataClass[,,] data;
    public chunk()
    {
        data = new BlockDataClass[128, 256, 128];
        for (int x = 0; x < 128; x++)
        {
            for (int y = 0; y < 64; y++)
            {
                for (int z = 0; z < 128; z++)
                {
                    data[x, y, z] = new BlockDataClass(y);
                }
            }
        }
    }
}
//int
/*
public class chunk
{
    public int[,,] data;
    public chunk()
    {
        data = new int[128, 256, 128];
        for (int x = 0; x < 128; x++)
        {
            for (int y = 0; y < 64; y++)
            {
                for (int z = 0; z < 128; z++)
                {
                    data[x, y, z] = 1;
                }
            }
        }
    }
}*/

//string
/*
public class chunk
{
    public string[,,] data;
    public chunk()
    {
        data = new string[128, 256, 128];
        for (int x = 0; x < 128; x++)
        {
            for (int y = 0; y < 64; y++)
            {
                for (int z = 0; z < 128; z++)
                {
                    //data[x, y, z] = "NANI"+y;
                    //data[x, y, z] = y+"According to all known laws of aviation, there is no way a bee should be able to fly. Its wings are too small to get its fat little body off the ground. The bee, of course, flies anyway because bees don't care what humans think is impossible.";
                }
            }
        }
    }
}*/

//byte 3d
/*
public class chunk
{
    public byte[,,] data;
    public chunk()
    {
        data = new byte[128, 256, 128];
        for (int x = 0; x < 128; x++)
        {
            for (int y = 0; y < 64; y++)
            {
                for (int z = 0; z < 128; z++)
                {
                    data[x, y, z] = 255;
                }
            }
        }
    }
}*/

//byte 1d
/*
public class chunk
{
    public byte[] data;
    public chunk()
    {
        data = new byte[4194304];
        for (int x = 0; x < 128; x++)
        {
            for (int y = 0; y < 64; y++)
            {
                for (int z = 0; z < 128; z++)
                {
                    data[x+256*(y+128*z)] = 255;
                }
            }
        }
    }
}*/