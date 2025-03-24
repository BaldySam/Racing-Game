using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

namespace SplineMeshTools.Colliders
{
    [RequireComponent(typeof(MeshCollider))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    public class SplinePavement : MonoBehaviour
    {
        public float width = 1f;
        public float height = 1f;
        public Vector3 offsetInput = Vector3.zero;
        private Vector3 offset;
        public int resolution = 10;
        private MeshCollider meshCollider;
        [SerializeField] private SplineContainer splineContainer;
        [SerializeField] private bool refresh;
        [SerializeField] float textureScale = 5f; // Change the scale of the texture here
        [SerializeField] float textureRotation;
 
        private void OnValidate()
        {
            // Ensure resolution is never below 1
            resolution = Mathf.Max(1, resolution);

            // Regenerate the mesh whenever values are changed in the editor
            GenerateAndAssignMesh();
        }

        private void GenerateAndAssignMesh()
        {
            if (meshCollider == null)
            {
                meshCollider = GetComponent<MeshCollider>();

                if (meshCollider == null)
                {
                    meshCollider = gameObject.AddComponent<MeshCollider>();
                }
            }

            Rigidbody rb = GetComponent<Rigidbody>();
            if (!rb.isKinematic)
            {
                Debug.LogWarning("Rigidbody is changed to be Kinematic.");
                rb.isKinematic = true;
            }
            meshCollider.sharedMesh = GenerateBoxColliderMesh();
        }

        public Mesh GenerateBoxColliderMesh()
        {
            MeshFilter meshFilter = GetComponent<MeshFilter>();
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            List<Vector3> combinedVertices = new List<Vector3>();
            List<int> combinedTriangles = new List<int>();
            offset = new Vector3(offsetInput.x, offsetInput.y, offsetInput.z);
        
            foreach (Spline spline in splineContainer.Splines)
            {
                Mesh mesh = new Mesh();
        
                Vector3[] vertices = new Vector3[resolution * 8];
                int[] triangles = new int[(resolution) * 36];
        
                for (int i = 0; i < resolution; i++)
                {
                    float t = i / (float)(resolution - 1);
        
                    Vector3 tangent = spline.EvaluateTangent(t);
                    Vector3 right = Vector3.Cross(Vector3.up, tangent).normalized * width / 2f;
                    Vector3 up = Vector3.up * height / 2f;
        
                    Vector3 splinePosition = (Vector3)spline.EvaluatePosition(t) + Vector3.Scale(offset, right);
        
                    if (i == 0)
                    {
                        // Front face (first segment)
                        vertices[0] = splinePosition - right - up;      // Bottom left
                        vertices[1] = splinePosition + right - up;      // Bottom right
                        vertices[2] = splinePosition - right + up;      // Top left
                        vertices[3] = splinePosition + right + up;      // Top right
                    }
        
                    // Back face (offset by depth)
                    vertices[i * 4 + 4] = splinePosition - right - up;
                    vertices[i * 4 + 5] = splinePosition + right - up;
                    vertices[i * 4 + 6] = splinePosition - right + up;
                    vertices[i * 4 + 7] = splinePosition + right + up;
        
                    // Triangle assignment
                    int vi = i * 4;
                    int ti = i * 36;
        
                    // Left face
                    triangles[ti + 12] = vi;
                    triangles[ti + 13] = vi + 4;
                    triangles[ti + 14] = vi + 2;
        
                    triangles[ti + 15] = vi + 4;
                    triangles[ti + 16] = vi + 6;
                    triangles[ti + 17] = vi + 2;
        
                    // Right face
                    triangles[ti + 18] = vi + 1;
                    triangles[ti + 19] = vi + 3;
                    triangles[ti + 20] = vi + 5;
        
                    triangles[ti + 21] = vi + 5;
                    triangles[ti + 22] = vi + 3;
                    triangles[ti + 23] = vi + 7;
        
                    // Top face
                    triangles[ti + 24] = vi + 2;
                    triangles[ti + 25] = vi + 6;
                    triangles[ti + 26] = vi + 3;
        
                    triangles[ti + 27] = vi + 3;
                    triangles[ti + 28] = vi + 6;
                    triangles[ti + 29] = vi + 7;
        
                    // Bottom face
                    triangles[ti + 30] = vi;
                    triangles[ti + 31] = vi + 1;
                    triangles[ti + 32] = vi + 4;
                    triangles[ti + 33] = vi + 4;
                    triangles[ti + 34] = vi + 1;
                    triangles[ti + 35] = vi + 5;

                }
        
                combinedVertices.AddRange(vertices);
                combinedTriangles.AddRange(triangles);
                mesh.vertices = vertices;
                mesh.triangles = triangles;
                mesh.RecalculateNormals();
            }
        
            Mesh combinedMesh = new Mesh();
            combinedMesh.SetVertices(combinedVertices);
            combinedMesh.SetTriangles(combinedTriangles, 0);
            combinedMesh.RecalculateNormals();
            combinedMesh.RecalculateBounds();

            Vector2[] uvs = new Vector2[combinedVertices.Count];

            // Calculate the UV coordinates based on the tangent direction and rotation
            for (int i = 0; i < combinedVertices.Count / 4; i++)
            {
                Vector3 tangent = combinedVertices[i * 4 + 1] - combinedVertices[i * 4];
                Vector2 uv = new Vector2(tangent.x, tangent.z).normalized * textureScale;

                // Apply rotation to the UV coordinates
                Quaternion rotation = Quaternion.Euler(0f, textureRotation, 0f);
                uv = rotation * uv;

                uvs[i * 4] = uv;
                uvs[i * 4 + 1] = uv;
                uvs[i * 4 + 2] = uv;
                uvs[i * 4 + 3] = uv;
            }

            combinedMesh.SetUVs(0, uvs);

            meshFilter.mesh = combinedMesh;

            return combinedMesh;
        }
    }
}