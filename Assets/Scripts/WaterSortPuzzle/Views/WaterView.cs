using UnityEngine;

namespace WaterSortPuzzle.Views
{
  public class WaterView : MonoBehaviour
  {
    [SerializeField] private SpriteRenderer _color;

    public void SetColor(Color color) => 
      _color.color = color;
  }
}