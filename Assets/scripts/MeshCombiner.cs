using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using System.Text.RegularExpressions;

public class MeshCombiner : MonoBehaviour
{

    [SerializeField] private MeshFilter headTarget;
    [SerializeField] private MeshFilter torsoTarget;
    [SerializeField] private MeshFilter upperArmLTarget;
    [SerializeField] private MeshFilter upperArmRTarget;
    [SerializeField] private MeshFilter thighLTarget;
    [SerializeField] private MeshFilter thighRTarget;
    [SerializeField] private MeshFilter lowerArmLTarget;
    [SerializeField] private MeshFilter lowerArmRTarget;
    [SerializeField] private MeshFilter handLTarget;
    [SerializeField] private MeshFilter handRTarget;
    [SerializeField] private MeshFilter footLTarget;
    [SerializeField] private MeshFilter footRTarget;
    [SerializeField] private MeshFilter calfLTarget;
    [SerializeField] private MeshFilter calfRTarget;
    [SerializeField] private SkinnedMeshRenderer skin;
    [SerializeField] private TextAsset jsonSkin;

    public IEnumerator Start()
    {
        Skin skinData = Skin.CreateFromJSON(jsonSkin);

        List<string> keys = skinData.GetAllKeys();

        AsyncOperationHandle<IList<Mesh>> handle = Addressables.LoadAssetsAsync<Mesh>(
          keys,
          addressable =>
          {
              Regex headRegex = new("Head", RegexOptions.IgnoreCase);
              Debug.Log(headRegex.IsMatch(addressable.ToString()));
          }, Addressables.MergeMode.Union, false);

        yield return handle;
    }
}
