using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPCAnims", menuName = "ScriptableObjects/NPCAnims", order = 1)]
public class NPCAnims : ScriptableObject
{
    public List<AnimationClip> clips;
}


[CreateAssetMenu(fileName = "Controles", menuName = "ScriptableObjects/Controles", order = 1)]
public class Controles : ScriptableObject
{
    public KeyCode interactuar = KeyCode.E;
    public KeyCode secundaria = KeyCode.F;
}
