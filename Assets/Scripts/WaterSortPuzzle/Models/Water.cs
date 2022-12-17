using UnityEngine;
using WaterSortPuzzle.Views;

namespace WaterSortPuzzle.Models
{
  public class Water
  {
    public Color Color { get; private set; }
    public WaterView View { get; set; }

    private Transform _transform;

    public Water(Color color) => 
      SetColor(color);

    private void SetColor(Color color) => 
      Color = color;

    public void SetParent(Transform parent)
    {
      _transform = View.transform;
      
      _transform.SetParent(parent);
      _transform.position = parent.position + new Vector3(0,0,-0.1f);
      _transform.rotation = parent.rotation;
    }
    
  }
}