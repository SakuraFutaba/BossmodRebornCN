using ImGuiNET;

namespace BossMod.Log;

public class DevBarWindow : UIWindow
{
    public DevBarWindow()
        : base("##Bossmod DevBar", false, new(0, 0), ImGuiWindowFlags.NoDecoration | ImGuiWindowFlags.NoBackground)
    {
        RespectCloseHotkey = false;
        IsOpen = true;
        ForceMainWindow = true;
    }

    public override void Draw()
    {
        if (ECommons.DalamudServices.Svc.PluginInterface.IsDevMenuOpen)
        {
            if (ImGui.BeginMainMenuBar())
            {
                if (ImGui.BeginMenu("LogWindow"))
                {
                    Plugin.WndLog.Toggle();
                    ImGui.EndMenu();
                }

                ImGui.EndMainMenuBar();
            }
        }
    }
}
