using WaterSortPuzzle.Data;

namespace WaterSortPuzzle.Services.PersistentProgress
{
  public class PersistentProgressService :IPersistentProgressService
  {
    public PlayerProgress Progress {get; set;}
  }
}