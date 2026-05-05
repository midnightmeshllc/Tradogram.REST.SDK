namespace Tradogram.REST.SDK.DTO.Response
{
    public class getOumResponse
    {
        public List<Unit> Units { get; set; } = new List<Unit>();
    }

    public class Unit
    {
        public string UnitName { get; set; } = string.Empty;
        public string UnitShortName { get; set; } = string.Empty;
        public string UnitGroupName { get; set; } = string.Empty;
    }
}
