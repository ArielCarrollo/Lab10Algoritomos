using UnityEngine;

public class Manager: MonoBehaviour
{

    public Inventory playerInventory;
    public TerrainCardQueue terrainCardQueue;
    public Grid grid;
    public Vector2Int playerBasePosition;

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
    public void UseTerrainCard()
    {
        terrainCardQueue.UseNextCard(grid, playerBasePosition);
    }
}
