using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AnimationClip", menuName = "AnimationClip", order = 0)]
public class AnimationClip : ScriptableObject
{
    [SerializeField] private List<Sprite> sprites; // String reference: MenuItems.cs
    [field: SerializeField] public bool Repeat { get; private set; }

    public Sprite[] GetSprites() => sprites.ToArray();
}