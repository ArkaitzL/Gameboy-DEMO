using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    [SerializeField] NPCAnims anims;
    Animator animator;
    Transform personaje;

    void Start()
    {
        personaje = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();

        if (anims.clips.Count == 0) {
            Debug.LogWarning("Faltan Animaciones");
            return;
        }

        int random = Random.Range(0, anims.clips.Count);
        AnimationClip seleccionado = anims.clips[random];

        animator.Play(seleccionado.name);
    }
}

