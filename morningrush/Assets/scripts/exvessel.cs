using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class exvessel : MonoBehaviour {
    public List<int> syrup=new List<int>();
    public int shots=-1;
    public int basefluid = -1;
    public int finish = -1;
    public int cuptype;
    public bool fail=false;
    public int size;
}
