using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uniquematerial : MonoBehaviour
{
    public bool _plusX{set; get;}
    public bool _plusY{set; get;}
    public bool _minusX{set; get;}
    public bool _minusY{set; get;}
    public Vector2 _2dPos { set; get; }

    [SerializeField] private Renderer renderer;
    public void Setup()
    {
        MaterialPropertyBlock myMatBlock = new MaterialPropertyBlock();
        myMatBlock.SetVector("_2dPos", _2dPos);
        
        if(_plusX)myMatBlock.SetFloat("_plusX",0);
        else myMatBlock.SetFloat("_plusX",1);
        
        if(_plusY)myMatBlock.SetFloat("_plusY",0);
        else myMatBlock.SetFloat("_plusY",1);
        
        if(_minusX)myMatBlock.SetFloat("_minusX",0);
        else myMatBlock.SetFloat("_minusX",1);
        
        if(_minusY)myMatBlock.SetFloat("_minusY",0);
        else myMatBlock.SetFloat("_minusY",1);
        
        renderer.SetPropertyBlock(myMatBlock);
    }
}
