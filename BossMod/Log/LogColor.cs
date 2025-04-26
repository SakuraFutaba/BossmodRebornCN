namespace BossMod.Log;

public static class LogColor
{
    public static Vector4 Number { get; internal set; } = new(0.929f, 0.580f, 0.753f, 1f);   // ED94C0
    public static Vector4 Property { get; internal set; } = new(0.400f, 0.765f, 0.800f, 1f); // 66C3CC
    public static Vector4 Parameter { get; internal set; } = new(0.741f, 0.741f, 0.741f, 1f);// BDBDBD
    public static Vector4 Keywords { get; internal set; } = new(0.424f, 0.584f, 0.922f, 1f); // 6C95EB
    public static Vector4 String { get; internal set; } = new(0.788f, 0.635f, 0.427f, 1f);   // C9A26D
    public static Vector4 Methods { get; internal set; } = new(0.224f, 0.800f, 0.608f, 1f);  // 39CC9B
    public static Vector4 Class { get; internal set; } = new(0.757f, 0.569f, 1f, 1f);    // C191FF
    public static Vector4 Enum { get; internal set; } = new(0.882f, 0.749f, 1f, 1f);     // E1BFFF
    public static Vector4 Comment { get; internal set; } = new(0.522f, 0.769f, 0.424f, 1f);     // 85C46C
    public static Vector4 Inactive { get; internal set; } = new(0.4706f, 0.4706f, 0.4706f, 1f);     // 787878
    public static Vector4 Say { get; internal set; } = new(0xF7 / 255f, 0xF7 / 255f, 0xF7 / 255f, 1f);
    public static Vector4 Yell { get; internal set; } = new(0xFF / 255f, 0xFF / 255f, 0x00 / 255f, 1f);
    public static Vector4 Shout { get; internal set; } = new(0xFF / 255f, 0xA6 / 255f, 0x66 / 255f, 1f);
    public static Vector4 Tell { get; internal set; } = new(0xFF / 255f, 0xB8 / 255f, 0xDE / 255f, 1f);
    public static Vector4 Party { get; internal set; } = new(0x66 / 255f, 0xE5 / 255f, 0xFF / 255f, 1f);
    public static Vector4 Alliance { get; internal set; } = new(0xFF / 255f, 0x7F / 255f, 0x00 / 255f, 1f);
    public static Vector4 FreeCompany { get; internal set; } = new(0xAB / 255f, 0xDB / 255f, 0xE5 / 255f, 1f);
    public static Vector4 Emote { get; internal set; } = new(0xBA / 255f, 0xFF / 255f, 0xF0 / 255f, 1f);
    public static Vector4 LinkShell { get; internal set; } = new(0xD4 / 255f, 0xFF / 255f, 0x7D / 255f, 1f);
    public static Vector4 NpcYell { get; internal set; } = new(0xAB / 255f, 0xD6 / 255f, 0x47 / 255f, 1f);
    public static Vector4 Error { get; internal set; } = new(0xFF / 255f, 0x4A / 255f, 0x4A / 255f, 1f);
    public static Vector4 Echo { get; internal set; } = new(0xCC / 255f, 0xCC / 255f, 0xCC / 255f, 1f);
}
