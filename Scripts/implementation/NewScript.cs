using Godot;
using System;

[Tool]
public partial class NewScript : Node {
  [Export] public PackedScene square { get; set; }
  [Export]
  public int width {
    get => width_;
    set {
      width_ = value;
      if (IsNodeReady()) {
        UpdateGrid();
      }
    }
  }

  [Export]
  public int height {
    get => height_;
    set {
      height_ = value;
      if (IsNodeReady()) {
        UpdateGrid();
      }
    }
  }
  [Export]
  public int spacing {
    get => spacing_;
    set {
      spacing_ = value;
      if (IsNodeReady()) {
        UpdateGrid();
      }
    }
  }
  [Export] public Vector2 Offset;

  private int width_;
  private int height_;

  private int spacing_;


  public override void _Ready() {
    // called on initialization
    //Sprite2D sqr = square.Instantiate<Sprite2D>();
    UpdateGrid();


  }
  public override void _Process(double delta) {
    // called every frame

  }

  private void UpdateGrid() {
    while (GetChildren().Count > 0) {
      var square = GetChildren()[0];

      RemoveChild(square);
      square.QueueFree();
    }

    CreateGrid(width_, height_, spacing);
  }

  public void CreateGrid(int width, int height, int spacing) {
    //Sprite2D squares[] = { square.Instantiate<Sprite2D>() };
    for (int i = 0; i < height; i++) {

      for (int i2 = 0; i2 < width; i2++) {
        Sprite2D sqr = square.Instantiate<Sprite2D>();
        sqr.Position = new Vector2(i2 * spacing, i * spacing) + Offset;
        AddChild(sqr);
      }
    }
  }
}
