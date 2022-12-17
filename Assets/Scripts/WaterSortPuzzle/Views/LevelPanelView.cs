using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WaterSortPuzzle.Services;
using WaterSortPuzzle.Services.LoadSceneServices;
using WaterSortPuzzle.Utils;

namespace WaterSortPuzzle.Views
{
  public class LevelPanelView : MonoBehaviour
  {
    [SerializeField] private Button _button; 
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Image _image;
    
    private ILoadGameSceneService _loadGameSceneService;

    public TMP_Text Text => _text;
    public Image Image => _image;

    public void Initialize()
    {
      _loadGameSceneService = AllServices.Container.Single<ILoadGameSceneService>();
      _button.onClick.AddListener(ClickEvent);
    }

    private void ClickEvent() => 
      _loadGameSceneService.LoadLevel(_text.text.ToInt());
  }
}