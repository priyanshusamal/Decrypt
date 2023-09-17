using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Key : MonoBehaviour
{
     public enum EffectType{
        None,
        Pressed,
        Highlight1,
        Highlight2
    }

    [Header("Effect")]
    public EffectType effectType;
    private Animator anim;

    [Header("Data")]
    [SerializeField] private char data;


    private void Start() {
        data = GetComponentInChildren<TMP_Text>().text[0];
        anim = GetComponent<Animator>();
    }
    private void Update() {
        switch(effectType){
            case EffectType.None:
                anim.SetBool("Pressable2",false);
                anim.SetBool("Pressable1",false);
                break;
            case EffectType.Highlight1:
                anim.SetBool("Pressable2",false);
                anim.SetBool("Pressable1",true);
                break;
            case EffectType.Highlight2:
                anim.SetBool("Pressable1",false);
                anim.SetBool("Pressable2",true);
                break;

            case EffectType.Pressed:
                anim.SetBool("Pressable2",false);
                anim.SetBool("Pressable1",false);
                anim.SetTrigger("Pressed");
                effectType = EffectType.None;
                break;
            default:
                anim.SetBool("Pressable2",false);
                anim.SetBool("Pressable1",false);
                break;
        }
        
    }

    public char GetData()
    {
        return data;
    }

    public void Pressed()
    {
        effectType = EffectType.Pressed;
    }
}
