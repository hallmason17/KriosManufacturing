using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace KriosManufacturing.Core.Models;

public class Item
{
    public long Id { get; set; }

    public required string Sku { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    ICollection<InventoryRecord>? InventoryRecords { get; set; }
}