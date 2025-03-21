using Unity.Splines.Examples;
using UnityEngine;

public class MeshColliderSorter : MonoBehaviour
{
    LoftRoadBehaviour loftRoadBehaviour;
    MeshCollider meshCollider;

    void OnValidate()
    {
        loftRoadBehaviour = GetComponent<LoftRoadBehaviour>();
        meshCollider = GetComponent<MeshCollider>();

        if (loftRoadBehaviour != null && meshCollider != null)
        {
            meshCollider.sharedMesh = loftRoadBehaviour.mesh;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        loftRoadBehaviour = GetComponent<LoftRoadBehaviour>();
        meshCollider = GetComponent<MeshCollider>();

        if (loftRoadBehaviour != null && meshCollider != null)
        {
            meshCollider.sharedMesh = loftRoadBehaviour.mesh;
        }
    }
}
