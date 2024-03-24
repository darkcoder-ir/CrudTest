namespace Mc2.CrudTest.Core.Domain.Abstracation.Models ;

  public  interface AuditableDbEntity
  {
    public string CreatedBy { get; set; } 

    public DateTime CreatedUtc { get; set; }

    public string? LastModifiedBy { get; set; }

    public DateTime? LastModifiedUtc { get; set; }
  }