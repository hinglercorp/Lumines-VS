using Godot;
using System;

public partial class NewScript : Node {
	[Export] public PackedScene square { get; set; }
	[Export] public int width;
	[Export] public int height;
	[Export] public int spacing;
	[Export] public Vector2 Offset;
	public override void _Ready() {
		// called on initialization
		//Sprite2D sqr = square.Instantiate<Sprite2D>();
		CreateGrid(width, height, spacing);


	}
	public override void _Process(double delta) {
		// called every frame
		
	}
	public void CreateGrid(int width, int height, int spacing){
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
