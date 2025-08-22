using Godot;
using System;

public partial class InteractionDemo : Node {
	[Export] BaseGrid other { get; set; }
	public override void _Ready() {
		base._Ready();
		other.SetContents(5, 5, new LuminesVS.game.tile.Tile(1, false)); //maybe
		//game.tile.tile okay i guiess that works
	}
}
