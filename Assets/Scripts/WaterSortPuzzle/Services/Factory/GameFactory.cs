using System;
using System.Collections.Generic;
using UnityEngine;
using WaterSortPuzzle.Data;
using WaterSortPuzzle.Models;
using WaterSortPuzzle.Services.PersistentProgress;
using WaterSortPuzzle.Views;
using Object = UnityEngine.Object;

namespace WaterSortPuzzle.Services.Factory
{
  public class GameFactory : IGameFactoryService
  {
    private const string UIRootPath = "Prefabs/RootCanvas";
    private const string LevelChoiceWindowPath = "Prefabs/LevelChoiceWindow";
    private const string LevelPanel = "Prefabs/LevelPanel";
    private const string FlaskViewPath = "Prefabs/Flask";
    private const string WaterViewPath = "Prefabs/Water";
    
    private readonly IPersistentProgressService _progressService;
    private Transform _uiRoot;
    private Camera _camera;

    public List<Flask> InitializedFlasks { get; } = new List<Flask>();

    public GameFactory(IPersistentProgressService progressService) => 
      _progressService = progressService;

    public void SetCamera() =>
      _camera = Camera.main;


    public void CreateUIRoot()
    {
      var canvas = Resources.Load<GameObject>(UIRootPath);
      var root = Object.Instantiate(canvas);
      _uiRoot = root.transform;
    }

    public void InitializeFlasks(List<Flask> flasks, Action onInit = null)
    {
      var flaskPrefab = Resources.Load<FlaskView>(FlaskViewPath);
      var waterPrefab = Resources.Load<WaterView>(WaterViewPath);
      var positions = CalculatePositions(flasks.Count);


      for (int i = 0; i < flasks.Count; i++)
      {
        var flaskView = Object.Instantiate(flaskPrefab, positions[i], Quaternion.identity);
        flasks[i].SetView(flaskView);
        
        int j = 0 ;
        foreach (var water in flasks[i].Stack)
        {
          var waterView = Object.Instantiate(waterPrefab, flasks[i].View.FluidsPositions[j]);
          water.View = waterView;
          waterView.SetColor(water.Color);
          j++;
        }
        InitializedFlasks.Add(flasks[i]);
      }
      onInit?.Invoke();
    }

    public void CreateLevelChoiceWindow()
    {
      var window = Resources.Load<LevelChoiceWindowView>(LevelChoiceWindowPath);
      var windowGameObject = Object.Instantiate(window, _uiRoot);
      var panel = Resources.Load<LevelPanelView>(LevelPanel);

      int i = 1;
      foreach (var availability in _progressService.Progress.levelStatus.levels)
      {
        CreteLevelPanel(availability, windowGameObject.Content, panel, i);
        i++;
      }
    }

    private void CreteLevelPanel(Availability availability, Transform parent, LevelPanelView panel, int levelNum)
    {
      var levelPanel = Object.Instantiate(panel, parent);
      levelPanel.Text.text = levelNum.ToString();
      switch (availability)
      {
        case Availability.Passed:
          levelPanel.Image.color = Color.green;
          break;
        case Availability.Available:
          levelPanel.Image.color = Color.yellow;
          break;
        case Availability.NotAvailable:
          levelPanel.Image.color = Color.gray;
          break;
      }

      levelPanel.Initialize();
    }

    private List<Vector2> CalculatePositions(int flasksCount)
    {
      List<Vector2> positions = new List<Vector2>(flasksCount);

      var rowNumber = Math.Ceiling((float)flasksCount / 2);
      var heightStep = Screen.height / 3;

      var yPos = Screen.height - heightStep;
      for (int i = 0; i < 2; i++)
      {
        bool evenNum = flasksCount % 2 == 0;
        var widthStep = Screen.width / (!evenNum && i == 1 ? rowNumber : rowNumber + 1);
        var xPos = widthStep;

        for (int j = 0; j < (!evenNum && i == 1 ? rowNumber - 1 : rowNumber); j++)
        {
          var pos = _camera.ScreenToWorldPoint(new Vector2((float)xPos, yPos));
          positions.Add(pos);
          xPos += widthStep;
        }

        yPos -= heightStep;
      }

      return positions;
    }
  }
}