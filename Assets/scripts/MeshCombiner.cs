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
              Regex torsoRegex = new("Torso", RegexOptions.IgnoreCase);
              Regex handLRegex = new("HandL", RegexOptions.IgnoreCase);
              Regex handRRegex = new("HandR", RegexOptions.IgnoreCase);
              Regex calfLRegex = new("CalfL", RegexOptions.IgnoreCase);
              Regex calfRRegex = new("CalfR", RegexOptions.IgnoreCase);
              Regex thighLRegex = new("ThighL", RegexOptions.IgnoreCase);
              Regex thighRRegex = new("ThighR", RegexOptions.IgnoreCase);
              Regex upperArmLRegex = new("UpperArmL", RegexOptions.IgnoreCase);
              Regex upperArmRRegex = new("UpperArmR", RegexOptions.IgnoreCase);
              Regex lowerArmLRegex = new("LowerArmL", RegexOptions.IgnoreCase);
              Regex lowerArmRRegex = new("LowerArmR", RegexOptions.IgnoreCase);
              Regex footLRegex = new("FootL", RegexOptions.IgnoreCase);
              Regex footRRegex = new("FootR", RegexOptions.IgnoreCase);

              if (headRegex.IsMatch(addressable.ToString()))
              {
                  headTarget.sharedMesh = addressable;
              }
              else if (torsoRegex.IsMatch(addressable.ToString()))
              {
                  torsoTarget.sharedMesh = addressable;
              }
              else if (handLRegex.IsMatch(addressable.ToString()))
              {
                  handLTarget.sharedMesh = addressable;
              }
              else if (handRRegex.IsMatch(addressable.ToString()))
              {
                  handRTarget.sharedMesh = addressable;
              }
              else if (calfLRegex.IsMatch(addressable.ToString()))
              {
                  calfLTarget.sharedMesh = addressable;
              }
              else if (calfRRegex.IsMatch(addressable.ToString()))
              {
                  calfRTarget.sharedMesh = addressable;
              }
              else if (thighLRegex.IsMatch(addressable.ToString()))
              {
                  thighLTarget.sharedMesh = addressable;
              }
              else if (thighRRegex.IsMatch(addressable.ToString()))
              {
                  thighRTarget.sharedMesh = addressable;
              }
              else if (upperArmLRegex.IsMatch(addressable.ToString()))
              {
                  upperArmLTarget.sharedMesh = addressable;
              }
              else if (upperArmRRegex.IsMatch(addressable.ToString()))
              {
                  upperArmRTarget.sharedMesh = addressable;
              }
              else if (lowerArmLRegex.IsMatch(addressable.ToString()))
              {
                  lowerArmLTarget.sharedMesh = addressable;
              }
              else if (lowerArmRRegex.IsMatch(addressable.ToString()))
              {
                  lowerArmRTarget.sharedMesh = addressable;
              }
              else if (footLRegex.IsMatch(addressable.ToString()))
              {
                  footLTarget.sharedMesh = addressable;
              }
              else if (footRRegex.IsMatch(addressable.ToString()))
              {
                  footRTarget.sharedMesh = addressable;
              }
              else
              {
                  Debug.LogError("Addressable does not match any body part");
              }

          }, Addressables.MergeMode.Union, false);

        yield return handle;
    }
}
