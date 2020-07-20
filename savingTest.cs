using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditorInternal;
using UnityEngine;
using Unity.Mathematics;
public class savingTest : MonoBehaviour
{
    public bool useOdin;
    public bool startTest;

    public float timeTotal;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(envSaveTest.Dpath);
    }

    // Update is called once per frame
    void Update()
    {
        if (startTest)
        {
            startTest = false;
            envSaveTest.useOdin = useOdin;
            timeTotal = Time.realtimeSinceStartup;
            StartCoroutine(saveTest());
        }

    }
    IEnumerator saveTest()
    {
        chunk _chunk = new chunk();
        Debug.Log("start saving, useOdin:"+envSaveTest.useOdin);
        float time = Time.realtimeSinceStartup;
        if (_chunk == null)
        {
            yield break;
        }
       Thread sa = envSaveTest.saveChunk(_chunk);

        bool AllLoaded = false;
        while (!AllLoaded)
        {
            AllLoaded = true;
            
                if (sa.IsAlive)
                {
                    AllLoaded = false;
                    yield return null;
                }
        }
        float tim2 = Time.realtimeSinceStartup - time;
        Debug.Log("took save " + tim2);
        StartCoroutine(loadTest());
    }
    IEnumerator loadTest()
    {
        float time = Time.realtimeSinceStartup;
        
        Thread sa = envSaveTest.LoadChunk();
        bool AllLoaded = false;
        while (!AllLoaded)
        {
            AllLoaded = true;

            if (sa.IsAlive)
            {
                AllLoaded = false;
                yield return null;
            }
        }
        float tim2 = Time.realtimeSinceStartup - time;
        Debug.Log("took load " + tim2);
        timeTotal = Time.realtimeSinceStartup - timeTotal;
        Debug.Log("total time " + timeTotal);

    }
}
