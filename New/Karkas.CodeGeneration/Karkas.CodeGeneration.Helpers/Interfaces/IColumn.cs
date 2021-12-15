using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Karkas.CodeGenerationHelper.Interfaces
{
    public interface IColumn
    {
        bool IsAutoKey { get; }

        bool IsIdentity { get; }

        string Name { get;  }

        bool IsInPrimaryKey { get;  }

        bool IsInForeignKey { get;  }

        bool IsNullable { get;  }

        bool IsRequired { get;  }

        string LanguageType { get;  }

        ITable Table { get; }
        IView View { get; }

        bool IsComputed { get;  }

        string DbTargetType { get;  }

        string DataTypeName { get;  }

        int CharacterMaxLength { get;  }

        bool isStringType { get; }
        bool isStringTypeWithoutLength { get; }
        bool isNumericType { get; }

        string ContainerName { get; }
        string ContainerSchemaName { get; }



    }
}
