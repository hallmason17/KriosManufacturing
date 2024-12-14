using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace KriosManufacturing.Core.Models;

public class Lot
{
    public long Id { get; set; }

    public required string LotNumber { get; set; }

    public DateOnly ExpirationDate { get; set; }
}