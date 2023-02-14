using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : MonoBehaviour
{

    [SerializeField] GameObject[] portions;
    [SerializeField] int index;

    public bool IsFinished => index == portions.Length;

    AudioSource _audioSource;
    
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.playOnAwake = false;
        SetVisuals();

    }

    void OnValidate(){
        SetVisuals();
    }

    [ContextMenu(itemName:"Consume it!")]


    public void Consume(){
        if(! IsFinished){
            index ++;
            SetVisuals();
            _audioSource.Play();
        }
    }

    void SetVisuals(){
        for(int i=0; i < portions.Length; i++){
            portions[i].SetActive(i == index);
        }
    }


}
