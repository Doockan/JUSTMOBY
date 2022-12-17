using System;
using UnityEngine;

namespace WaterSortPuzzle.Views
{
  public class FlaskView : MonoBehaviour
  {
    [SerializeField] private Transform[] _fluidsPositions;

    public Transform[] FluidsPositions => _fluidsPositions;
    public Action OnClick;

    private void OnMouseDown() => 
      OnClick?.Invoke();
  }
}
