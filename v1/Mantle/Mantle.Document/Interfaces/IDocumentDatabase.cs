using System;

namespace Mantle.Document.Interfaces
{
    public interface IDocumentDatabase
    {
       string Id { get; set; }
       DateTime Timestamp { get;}
    }
}