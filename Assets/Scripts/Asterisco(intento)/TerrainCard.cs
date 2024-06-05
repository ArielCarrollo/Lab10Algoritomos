using UnityEngine;
public abstract class TerrainCard : MonoBehaviour
{

    public abstract void ApplyEffect(Grid grid, Vector2Int position);
}

public class VortexCard : TerrainCard
{

    public override void ApplyEffect(Grid grid, Vector2Int position)
    {

    }
}
