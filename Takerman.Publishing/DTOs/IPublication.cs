namespace Takerman.Publishing.Data.DTOs
{
    public interface IPublication
    {
        int ProjectId { get; set; }

        PostType Type { get; }
    }
}