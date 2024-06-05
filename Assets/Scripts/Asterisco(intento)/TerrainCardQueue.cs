using System.Collections.Generic;
using UnityEngine;

public class TerrainCardQueue : MonoBehaviour
{
    private Queue<TerrainCard> cards = new Queue<TerrainCard>();

    public void AddCard(TerrainCard card)
    {
        cards.Enqueue(card);
    }

    public void UseNextCard(Grid grid, Vector2Int position)
    {
        if (cards.Count > 0)
        {
            TerrainCard nextCard = cards.Dequeue();
            nextCard.ApplyEffect(grid, position);
        }
    }
}
