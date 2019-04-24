using System.Collections;
using System.Collections.Generic;
using Pixeye;
using Pixeye.Framework;
using UnityEngine;

public class StarterGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var e = new ent(10);
        e.RemoveAll(Tag.None);
      
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
