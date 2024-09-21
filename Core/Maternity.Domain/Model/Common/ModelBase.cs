using System.ComponentModel.DataAnnotations;

namespace Maternity.Domain.Model.Common;

public abstract class ModelBase
{
    [Key]
    public int Id { get; private set; }
}