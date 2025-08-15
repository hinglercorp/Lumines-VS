using Godot;
using System;

public partial class TileAnimSwitcher : AnimatedSprite2D {
	[Export] public SpriteFrames anims;
	[Export] public Byte currentState;
	public override void _Ready() {
		UpdateSprites();
	}
	public void UpdateSprites() {
		switch (currentState) {
			case 0:
				this.Animation = new StringName("state1");
				break;
			case 1:
				this.Animation = new StringName("state2");
				break;
			case 2:
				this.Animation = new StringName("state3");
				break;
		}
		this.Play();
	}
}
