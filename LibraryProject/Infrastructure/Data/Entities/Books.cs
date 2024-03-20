using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryProject.Infrastructure.Data.Entities;

public class Book : BaseHistoricEntity
{
    public string Name { get; init; }
    public string Writer { get; init; }
    public string ImagePath { get; set; }
    public string? Borrower { get; set; }
    public bool IsInLibrary { get; set; }
    public DateTime? ReturnDate { get; set; }
}