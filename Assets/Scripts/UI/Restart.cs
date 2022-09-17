using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Restart : ScriptableObject
{
    [SerializeField] private bool _restart;

    public bool restart
    {
        get
        {
            return _restart;
        }
        set
        {
            _restart = value;
        }
    }
    
}
