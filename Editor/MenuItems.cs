using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class ManuItems
{
    [MenuItem("Assets/Create Animation Clip")]
    private static void CreateAnimationClip()
    {
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        Object[] objects = AssetDatabase.LoadAllAssetsAtPath(path);
        Sprite[] sprites = objects.Where(o => o is Sprite).Cast<Sprite>().ToArray();

        string[] pathList = path.Split('/');
        string[] directoryList = pathList.Take(pathList.Count() - 1).ToArray();
        string directory = string.Join('/', directoryList);
        string[] nameList = pathList.Last().Split(".");
        nameList = nameList.Take(nameList.Count() - 1).ToArray();
        string name = string.Join('/', nameList);

        AnimationClip clip = ScriptableObjectFactory.Create<AnimationClip>(directory, name);

        FieldInfo spritesField = clip.GetType().GetField("sprites", BindingFlags.NonPublic | BindingFlags.Instance);
        spritesField.SetValue(clip, new List<Sprite>(sprites));

        EditorUtility.SetDirty(clip);
    }
}