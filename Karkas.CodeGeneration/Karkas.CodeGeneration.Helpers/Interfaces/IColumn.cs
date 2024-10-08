using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karkas.CodeGeneration.Helpers.Interfaces
{
    public interface IColumn
    {
        bool IsAutoKey { get; }

        bool IsIdentity { get; }

        string Name { get;  }

        bool IsInPrimaryKey { get;  }

        bool IsInForeignKey { get;  }

        ForeignKeyInformation ForeignKeyInformation { get; }


        bool IsNullable { get;  }

        bool IsRequired { get;  }

        string LanguageType { get;  }

        ITable Table { get; }
        IView View { get; }

        bool IsComputed { get;  }

        string DbTargetType { get;  }

        string DataTypeName { get;  }

        int CharacterMaxLength { get;  }

        bool IsStringType { get; }
        bool IsStringTypeWithoutLength { get; }
        bool IsNumericType { get; }

        string ContainerName { get; }
        string ContainerSchemaName { get; }

        string DataTypeInDatabase { get; }

        string GetColumnInformationSchemaProperty(string propertyName);
    }
}
