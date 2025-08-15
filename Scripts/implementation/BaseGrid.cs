using System.Collections.Generic;
using System.Data.Common;
using Godot;
using LuminesVS.game;
using LuminesVS.game.stub;
using LuminesVS.game.tile;

[Tool]
public partial class BaseGrid : Node, ITileGrid {
  [Export] public PackedScene square { get; set; }
  [Export] public PackedScene tile { get; set; }

  [Export]
  public int Width {
    get => width_;
    set {
      if (value != width_) {
        width_ = value;
        grid_data = new(width_, height_);
      }

      if (IsNodeReady()) {
        UpdateGrid();
      }
    }
  }

  [Export]
  public int Height {
    get => height_;
    set {
      if (value != height_) {
        height_ = value;
        grid_data = new(width_, height_);
      }

      if (IsNodeReady()) {
        UpdateGrid();
      }
    }
  }
  [Export]
  public int Spacing {
    get => spacing_;
    set {
      spacing_ = value;
      if (IsNodeReady()) {
        UpdateGrid();
      }
    }
  }

  [Export]
  public Vector2 Offset;

  private int width_;
  private int height_;

  private int spacing_;

  private readonly List<Sprite2D> squares = [];
  private readonly List<TileAnimSwitcher> tiles = [];
  private TileGridStub grid_data;

  public BaseGrid() {
    grid_data = new(12, 8);
  }

  public override void _Ready() {
    // called on initialization
    //Sprite2D sqr = square.Instantiate<Sprite2D>();
    while (GetChildren().Count > 0) {
      var square = GetChildren()[0];

      RemoveChild(square);
      square.QueueFree();
    }
    
    UpdateGrid();
    UpdateTiles();

    SetContents(1, 0, new Tile(2, false));
  }

  public Tile GetContents(int x, int y) {
    return grid_data.GetContents(x, y);
  }

  public void SetContents(int x, int y, Tile tile) {
    grid_data.SetContents(x, y, tile);
    UpdateTile(x, y);
    // update grid
  }

  private void UpdateGrid() {
    CreateGrid(width_, height_, spacing_);

    // update tiles
  }

  private void UpdateTiles() {
    int child_count = Width * Height;
    for (int i = 0; i < child_count; i++) {
      int x = i % Width;
      int y = i / Width;
      UpdateTile(x, y);
    }
  }

  private void UpdateTile(int x, int y) {
    TileAnimSwitcher tile_node = tiles[y * Width + x];
    Tile data = grid_data.GetContents(x, y);
    if (data.Empty()) {
      tile_node.Hide();
    }
    else {
      tile_node.Show();
      // prob: pass a plaintext string?
      tile_node.CurrentState = (byte)(data.GetColor() - 1);
      GD.Print("new state: ", tile_node.CurrentState);
    }
  }

  public void CreateGrid(int width, int height, int spacing) {
    //Sprite2D squares[] = { square.Instantiate<Sprite2D>() };
    int child_count = width * height;
    while (squares.Count < child_count) {
      Sprite2D sqr = square.Instantiate<Sprite2D>();
      TileAnimSwitcher tile = this.tile.Instantiate<TileAnimSwitcher>();

      AddChild(sqr);
      AddChild(tile);

      squares.Add(sqr);
      tiles.Add(tile);
    }

    for (int i = 0; i < child_count; i++) {
      int x = i % width;
      int y = height - (i / width) - 1;

      Sprite2D sqr = squares[i];
      TileAnimSwitcher tile = tiles[i];

      sqr.Position = new Vector2(x * spacing, y * spacing) + Offset;
      tile.Position = sqr.Position;

      sqr.Show();
      tile.Show();
    }

    for (int i = child_count; i < squares.Count; i++) {
      squares[i].Hide();
      tiles[i].Hide();
    }
  }
}