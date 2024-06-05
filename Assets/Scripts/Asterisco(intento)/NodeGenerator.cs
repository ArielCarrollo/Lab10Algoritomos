using UnityEngine;
using System.Collections.Generic;

public class NodeGenerator : MonoBehaviour
{
    public GameObject nodePrefab;
    public int numberOfNodes;
    public float minRandomX;
    public float maxRandomX;
    public float minRandomY;
    public float maxRandomY;
    public float minRandomZ;
    public float maxRandomZ; 

    private List<Transform> nodes = new List<Transform>();

    void Start()
    {
        GenerateRandomNodes();
        ConnectNodes();
    }

    void GenerateRandomNodes()
    {
        for (int i = 0; i < numberOfNodes; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(minRandomX, maxRandomX), Random.Range(minRandomY, maxRandomY), Random.Range(minRandomZ, maxRandomZ));

            GameObject node = Instantiate(nodePrefab, randomPosition, Quaternion.identity, transform);
            nodes.Add(node.transform);
        }
    }

    void ConnectNodes()
    {
        HashSet<Transform> visited = new HashSet<Transform>(); 
        List<Transform> connectedNodes = new List<Transform>(); 

        connectedNodes.Add(nodes[0]);

        while (connectedNodes.Count < nodes.Count)
        {
            Transform closestNode = null;
            float closestDistance = Mathf.Infinity;

            for (int i = 0; i < nodes.Count; i++)
            {
                Transform node = nodes[i];
                if (!connectedNodes.Contains(node))
                {
                    for (int j = 0; j < connectedNodes.Count; j++)
                    {
                        Transform connectedNode = connectedNodes[j];
                        float distance = Vector3.Distance(node.position, connectedNode.position);
                        if (distance < closestDistance)
                        {
                            closestNode = node;
                            closestDistance = distance;
                        }
                    }
                }
            }
            connectedNodes.Add(closestNode);
        }
        DrawConnections(connectedNodes);
    }

    void DrawConnections(List<Transform> connectedNodes)
    {
        for (int i = 0; i < connectedNodes.Count - 1; i++)
        {
            Debug.DrawLine(connectedNodes[i].position, connectedNodes[i + 1].position, Color.green, Mathf.Infinity);
        }
    }
}
