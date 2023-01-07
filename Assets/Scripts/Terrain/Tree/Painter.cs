using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JL.Terrain.Tree {
    public class Painter : MonoBehaviour {
        [SerializeField]
        private bool execute = false;

        [SerializeField]
        private int treeCount = 9999;

        [SerializeField]
        private Texture2D texture = null;

        private UnityEngine.Terrain terrain;
        private List<TreeInstance> treeInstances;

        private void Start() {
            if(execute == false) {
                return;
            }

            terrain = transform.GetComponent<UnityEngine.Terrain>();
            treeInstances = new List<TreeInstance>();

            RemoveTrees(terrain);

            while(treeInstances.Count < treeCount) {
                Vector3 position = new Vector3(
                    Random.Range(0f, 1f),
                    0,
                    Random.Range(0f, 1f)
                );

                if(IsTree(texture, position)) {
                    treeInstances.Add(GrowTree(position));
                }
            }

            PlantTrees(terrain, treeInstances.ToArray());
        }

        private void Update() {

        }

        private bool IsTree(Texture2D texture, Vector3 position) {
            bool isTree;

            Color color = texture.GetPixel(
                Mathf.FloorToInt(position.x * texture.width),
                Mathf.FloorToInt(position.z * texture.height)
            );

            isTree = (color.g >= (50 / 255f) && color.g >= (color.r * 1.3f) && color.g >= (color.b * 1.3f)) ? true : false;

            return isTree;
        }

        private TreeInstance GrowTree(Vector3 position) {
            TreeInstance treeInstance = new TreeInstance();

            treeInstance.color = Color.white;
            treeInstance.heightScale = Random.Range(0.5f, 2f);
            treeInstance.lightmapColor = Color.white;
            treeInstance.position = position;
            treeInstance.prototypeIndex = Random.Range(0, 5);
            treeInstance.rotation = Random.Range(0f, 5f);
            treeInstance.widthScale = Random.Range(0.5f, 2f);

            return treeInstance;
        }

        private void PlantTrees(UnityEngine.Terrain terrain, TreeInstance[] treeInstances) {
            terrain.terrainData.SetTreeInstances(treeInstances, true);

            return;
        }

        private void RemoveTrees(UnityEngine.Terrain terrain) {
            terrain.terrainData.treeInstances = new TreeInstance[0];
            
            return;
        }
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JL.Terrain.Tree {
    public class Painter : MonoBehaviour {
        [SerializeField]
        private bool execute = false;

        [SerializeField]
        private int treeCount = 9999;

        [SerializeField]
        private Texture2D texture = null;

        private UnityEngine.Terrain terrain;
        private List<TreeInstance> treeInstances;

        private void Start() {
            if(execute == false) {
                return;
            }

            terrain = transform.GetComponent<UnityEngine.Terrain>();
            treeInstances = new List<TreeInstance>();

            RemoveTrees(terrain);

            print(GetDistance(terrain, new Vector3(1, 0, 0), new Vector3(0, 0, 0)));

            int count = 0;
            float offset = 16f;

            while(treeInstances.Count < treeCount) {
                Vector3 position = new Vector3(Random.Range(0f, 1f), 0, Random.Range(0f, 1f));

                if(IsTree(texture, position) && IsNotOverlap(terrain, treeInstances, position, offset)) {
                    treeInstances.Add(GrowTree(position));
                }
                else {
                    count++;

                    if(count >= 10000) {
                        count = 0;
                        offset = offset / 2;

                        if(offset < 0.01f) {
                            break;
                        }
                    }
                }
            }

            PlantTrees(terrain, treeInstances.ToArray());

            print(offset);
            print(treeInstances.Count);
        }

        private void Update() {

        }

        private float GetDistance(UnityEngine.Terrain terrain, Vector3 positionA, Vector3 positionB) {
            float distance;

            Vector3 convertedPositionA = new Vector3(positionA.x * terrain.terrainData.size.x, 0, positionA.z * terrain.terrainData.size.z);
            Vector3 convertedPositionB = new Vector3(positionB.x * terrain.terrainData.size.x, 0, positionB.z * terrain.terrainData.size.z);

            distance = Vector3.Distance(convertedPositionA, convertedPositionB);

            return distance;
        }

        private bool IsTree(Texture2D texture, Vector3 position) {
            bool isTree;

            Color color = texture.GetPixel(Mathf.FloorToInt(position.x * texture.width), Mathf.FloorToInt(position.z * texture.height));

            isTree = (color.g >= (50 / 255f) && color.g >= (color.r * 1.2f) && color.g >= (color.b * 1.2f)) ? true : false;

            return isTree;
        }

        private bool IsNotOverlap(UnityEngine.Terrain terrain, List<TreeInstance> treeInstances, Vector3 position, float offset) {
            bool isOverlap = false;

            foreach(TreeInstance treeInstance in treeInstances) {
                float distance = GetDistance(terrain, position, treeInstance.position);

                if(distance < offset) {
                    isOverlap = true;
                    break;
                }
            }

            return !isOverlap;
        }

        private TreeInstance GrowTree(Vector3 position) {
            TreeInstance treeInstance = new TreeInstance();

            treeInstance.color = Color.white;
            treeInstance.heightScale = Random.Range(0.5f, 2f);
            treeInstance.lightmapColor = Color.white;
            treeInstance.position = position;
            treeInstance.prototypeIndex = Random.Range(0, 5);
            treeInstance.rotation = Random.Range(0f, 5f);
            treeInstance.widthScale = Random.Range(0.5f, 2f);

            return treeInstance;
        }

        private void PlantTrees(UnityEngine.Terrain terrain, TreeInstance[] treeInstances) {
            terrain.terrainData.SetTreeInstances(treeInstances, true);

            return;
        }

        private void RemoveTrees(UnityEngine.Terrain terrain) {
            terrain.terrainData.treeInstances = new TreeInstance[0];
            
            return;
        }
    }
}
*/
