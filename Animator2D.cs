using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animator2D : MonoBehaviour
{
    private readonly Dictionary<SpriteRenderer, Coroutine> Coroutines = new();
    private readonly Dictionary<SpriteRenderer, AnimationClip> Clips = new();
    protected void PlayClip(SpriteRenderer renderer, AnimationClip clip, float speed, Action onFinish = null)
    {
        IEnumerator task()
        {
            while (true)
            {
                foreach (Sprite sprite in clip.GetSprites())
                {
                    renderer.sprite = sprite;
                    yield return new WaitForSeconds(1 / speed);
                }

                if (!clip.Repeat) break;
            }

            onFinish?.Invoke();
        }

        if (Coroutines.ContainsKey(renderer)) StopCoroutine(Coroutines[renderer]);
        Coroutines[renderer] = StartCoroutine(task());
        Clips[renderer] = clip;
    }

    protected AnimationClip GetClip(SpriteRenderer renderer)
    {
        if (Clips.ContainsKey(renderer)) return Clips[renderer];
        return null;
    }
}