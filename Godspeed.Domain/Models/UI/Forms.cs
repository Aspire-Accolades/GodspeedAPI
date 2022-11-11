using System.ComponentModel.DataAnnotations.Schema;

namespace Godspeed.Domain.Models.UI
{
  [Table(nameof(Forms), Schema = "UI")]
  public class Forms
  {
    public int FormID { get; set; }
    public string Page { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Style { get; set; } = string.Empty;
    public string Feild1Style { get; set; } = string.Empty;
    public string? Feild2Style { get; set; } = string.Empty;
    public string? Feild3Style { get; set; } = string.Empty;
    public string Button1Style { get; set; } = string.Empty;
    public string? Button2Style { get; set; } = string.Empty;
    public string? Button3Style { get; set; } = string.Empty;
    public string? Button4Style { get; set; } = string.Empty;
    public string? Button5Style { get; set; } = string.Empty;
    public string? Optional1Style { get; set; } = string.Empty;
    public string? Optional2Style { get; set; } = string.Empty;
    public string? Optional3Style { get; set; } = string.Empty;
    public string Text1Style { get; set; } = string.Empty;
    public string? Text2Style { get; set; } = string.Empty;
    public string? Text3Style { get; set; } = string.Empty;
    public string? BorderStyle { get; set; } = string.Empty;
    public int EntityApplicationID { get; set; }
  }
}
