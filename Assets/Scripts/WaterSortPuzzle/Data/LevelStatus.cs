using System;
using System.Collections.Generic;

namespace WaterSortPuzzle.Data
{
  [Serializable]
  public class LevelStatus
  {
    public List<Availability> levels = new List<Availability>();
  }
}