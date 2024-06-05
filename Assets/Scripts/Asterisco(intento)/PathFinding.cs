using UnityEngine;
using System.Collections.Generic;

public class Pathfinding
{
    // Método para encontrar el camino más corto desde el inicio hasta el objetivo
    public List<Vector2Int> FindPath(Vector2Int start, Vector2Int goal, Grid grid)
    {
        List<Vector2Int> path = new List<Vector2Int>();

        HashSet<Vector2Int> openSet = new HashSet<Vector2Int>(); // Lista abierta
        HashSet<Vector2Int> closedSet = new HashSet<Vector2Int>(); // Lista cerrada

        Dictionary<Vector2Int, Vector2Int> cameFrom = new Dictionary<Vector2Int, Vector2Int>(); // Diccionario para almacenar el camino recorrido

        Dictionary<Vector2Int, int> gScore = new Dictionary<Vector2Int, int>();
        gScore[start] = 0;

        Dictionary<Vector2Int, int> hScore = new Dictionary<Vector2Int, int>();
        hScore[start] = CalculateManhattanDistance(start, goal);

        List<Vector2Int> openSetWithScores = new List<Vector2Int>();
        openSetWithScores.Add(start);

        while (openSetWithScores.Count > 0)
        {
            Vector2Int current = openSetWithScores[0];
            foreach (var node in openSetWithScores)
            {
                if (CalculateFScore(node, gScore, hScore) < CalculateFScore(current, gScore, hScore))
                {
                    current = node;
                }
            }

            if (current == goal)
            {
                path = ReconstructPath(cameFrom, current);
                break;
            }

            openSetWithScores.Remove(current);
            closedSet.Add(current);

            foreach (Vector2Int neighbor in grid.GetNeighbors(current))
            {
                if (closedSet.Contains(neighbor))
                    continue;

                int tentativeGScore = gScore[current] + CalculateDistanceBetween(current, neighbor);

                if (!openSet.Contains(neighbor) || tentativeGScore < gScore[neighbor])
                {
                    cameFrom[neighbor] = current;
                    gScore[neighbor] = tentativeGScore;
                    hScore[neighbor] = CalculateManhattanDistance(neighbor, goal);

                    if (!openSet.Contains(neighbor))
                    {
                        openSet.Add(neighbor);
                        openSetWithScores.Add(neighbor);
                    }
                }
            }
        }

        return path;
    }

    private int CalculateManhattanDistance(Vector2Int a, Vector2Int b)
    {
        return Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y);
    }

    private int CalculateFScore(Vector2Int node, Dictionary<Vector2Int, int> gScore, Dictionary<Vector2Int, int> hScore)
    {
        return gScore[node] + hScore[node];
    }

    private List<Vector2Int> ReconstructPath(Dictionary<Vector2Int, Vector2Int> cameFrom, Vector2Int current)
    {
        List<Vector2Int> path = new List<Vector2Int>();
        path.Add(current);

        while (cameFrom.ContainsKey(current))
        {
            current = cameFrom[current];
            path.Insert(0, current);
        }

        return path;
    }

    private int CalculateDistanceBetween(Vector2Int a, Vector2Int b)
    {
        return 1;
    }
}
