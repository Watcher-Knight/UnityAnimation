using UnityEngine;

[AddComponentMenu("2D Animation/Animator Test")]
public class AnimatiorTest : Animator2D
{
    [SerializeField] private AnimationClip Clip;
    [SerializeField] private SpriteRenderer Renderer;
    [SerializeField] private float Speed = 1f;
    [ContextMenu("Play Animation")] public void PlayAnimation()
    {
        PlayClip(Renderer, Clip, Speed);
    }
}