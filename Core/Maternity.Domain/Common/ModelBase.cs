using System.ComponentModel.DataAnnotations;

namespace Maternity.Domain.Common;

public abstract class ModelBase
{
    [Key]
    public int Id { get; private set; }
}