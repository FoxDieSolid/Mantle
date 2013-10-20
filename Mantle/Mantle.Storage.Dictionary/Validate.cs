using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mantle.Storage.Dictionary
{
    public static class Validate
    {
        public static bool EntityIdIsProvided(string entityId)
        {
            var isValid = String.IsNullOrEmpty(entityId);

            if (String.IsNullOrEmpty(entityId))
                throw new ArgumentException("Entity ID is required.", "entityId");

            return isValid;
        }


        public static bool DictionaryIdIsProvided(string dictionaryId)
        {
            var isValid = String.IsNullOrEmpty(dictionaryId);

            if (String.IsNullOrEmpty(dictionaryId))
                throw new ArgumentException("Dictionary ID is required.", "dictionaryId");

            return isValid;
        }
    }
}
