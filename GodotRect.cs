
using Godot;
using System;

public partial class GodotRect : RigidBody2D
{
    bool pressing = false;
    private Vector2 initialMousePos;

    public override void _Ready()
    {
        var textureButton = GetNode<TextureButton>("TextureButton");
        textureButton.ButtonDown += () =>
        {
            pressing = true;
            initialMousePos = GetGlobalMousePosition() - GlobalPosition;
        };
        textureButton.ButtonUp += () => pressing = false;
        textureButton.GuiInput += (@event) =>
        {
            if (@event is InputEventMouseButton mouseEvent)
            {
                if (mouseEvent.ButtonIndex == MouseButton.Right && mouseEvent.Pressed == false)
                {
                    // MenuManager.getInstance().aquireMenu<TestTargetRightClickMenu>(this, mouseEvent);


                }
            }
        };
    }

    public override void _Process(double delta)
    {
        if (pressing)
        {

            Vector2 mousePos = GetGlobalMousePosition();
            GlobalPosition = mousePos - initialMousePos;
        }
    }

    private void showMenu()
    {

    }
    private void _screen_exited()
    {
        QueueFree();
    }
}
