using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCombiner : MonoBehaviour
{

    [SerializeField] private List<Mesh> sources;
    [SerializeField] private SkinnedMeshRenderer skin;

    [ContextMenu("Mesh Combiner")]
    // Start is called before the first frame update
  private void CombineMeshes() {

    var combine = new CombineInstance[sources.Count];
    for (int i = 0; i < sources.Count; i++) {
      GameObject obj = new GameObject();
      MeshFilter source = obj.AddComponent<MeshFilter>();
      source.mesh = sources[i];
      combine[i].mesh = source.sharedMesh;
      combine[i].transform = source.transform.localToWorldMatrix;
      DestroyImmediate(obj);
    }

    var mesh = new Mesh();
    mesh.CombineMeshes(combine);
    skin.sharedMesh = mesh;

  }

  void Start() {
    CombineMeshes();
  }
}
