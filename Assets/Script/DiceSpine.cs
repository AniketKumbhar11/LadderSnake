using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSpine : MonoBehaviour
{
    // Start is called before the first frame update
    public Material[] resultmat;
    private Animator Anim;
    public GameObject Dice;
    private AudioSource Audio;
    public AudioClip Clip;

    void Start()
    {
        Anim=GetComponent<Animator>();
        Audio = GetComponent<AudioSource>();
        
    }

    public void Attachresult()
    {
        Dice.GetComponent<MeshRenderer>().material=resultmat[GameHolder.result-1];
    }

public void AnimationStart()
{
   Audio.PlayOneShot(Clip);
}


    public void AnimationEnd()
    {
     
        
   Audio.Stop();
        
        Anim.SetBool("Play",false);
        GameHolder.Isdiceplay=false;
      
        Debug.Log("1");
    }
    void Update()
    {
        if (GameHolder.Isdiceplay)
        Anim.SetBool("Play",true);
        
    }
}
