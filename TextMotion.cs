using Godot;
using System;

public enum FunctionSelection
{
	Function1,
	Function2
}

public partial class TextMotion : RichTextLabel
{
	[Export] FunctionSelection functionSelection;
	[Export] float shiftSpeed = .001f;
	float _t = 0;
	Vector2 _Center;
	public override void _Ready()
	{
		_Center = GetWindow().Size / 2;
	}
	public override void _Process(double delta)
    {
        _t += (float)delta;

		if (functionSelection == FunctionSelection.Function1)
        {
            FirstMotionFunction();
        }
		else if (functionSelection == FunctionSelection.Function2)
		{
			SecondMotionFunction();
		}
    }

    void FirstMotionFunction()
    {        
        Position = new Vector2((Mathf.Sin(_t) * 200) + _Center.X - (Size.X / 2), (Mathf.Cos(_t) * 200) + _Center.Y - (Size.Y / 2));

        Rotation = _t - Mathf.Sin(_t);

        Color outlineColor = RainbowShift(shiftSpeed, "theme_override_colors/font_outline_color");
        Set("theme_override_colors/font_outline_color", outlineColor);

        Color defaultColor = RainbowShift(shiftSpeed+(shiftSpeed/15), "theme_override_colors/default_color");
        Set("theme_override_colors/default_color", defaultColor);
    }
	void SecondMotionFunction()
	{
        Position = new Vector2((Mathf.Sin(_t) * 200) + _Center.X - (Size.X / 2), (Mathf.Cos(_t) * 200) + (_Center.Y - 90) - (Size.Y / 2));

        Rotation = _t + Mathf.Sin(_t);

        Color outlineColor = RainbowShift(shiftSpeed+(shiftSpeed/12), "theme_override_colors/font_outline_color");
        Set("theme_override_colors/font_outline_color", outlineColor);

        Color defaultColor = RainbowShift(shiftSpeed, "theme_override_colors/default_color");
        Set("theme_override_colors/default_color", defaultColor);
	}

    Color RainbowShift(float shiftSpeed, string colorNodePath)
    {
        Vector3 HSV = new Vector3();

        Color col = (Color)Get(colorNodePath);

        col.ToHsv(out HSV.X, out HSV.Y, out HSV.Z);

        Color newColor = Color.FromHsv(HSV.X + shiftSpeed, HSV.Y, HSV.Z);

        return newColor;
    }

}
