using Godot;
using System;

public partial class TextMotion : RichTextLabel
{
	float t = 0;
	Vector2 Center;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Center = GetWindow().Size / 2;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		t += (float)delta;
		Position = new Vector2((Mathf.Sin(t) * 100) + Center.X - (Size.X/2), (Mathf.Cos(t) * 100) + Center.Y - (Size.Y/2));
		Rotation = t;

		Color col = (Color)Get("theme_override_colors/default_color");

		Set("theme_override_colors/default_color", new Color(1, 1, 1, 1));
	}
}
