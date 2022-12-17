using System;

namespace WaterSortPuzzle.Data
{
  [Serializable]
  public class PlayerProgress
  {
    public LevelStatus levelStatus;
    
    public PlayerProgress()
    {
      levelStatus = new LevelStatus();
    }
  }
}