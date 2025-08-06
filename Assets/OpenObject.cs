using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenObject : MonoBehaviour
{
    public GameObject Object;
    public void ObjectOpen() 
    { 
        Object.SetActive(true);
    }

}
