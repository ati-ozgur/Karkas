using System;

namespace Karkas.CodeGeneration.Helpers.Interfaces;

public class ForeignKeyInformation
{
    private string sourceTable;
    private string sourceColumn;
    private string targetColumn;
    private string targetTable;

    public string SourceTable { get => sourceTable; set => sourceTable = value; }
    public string SourceColumn { get => sourceColumn; set => sourceColumn = value; }
    public string TargetColumn { get => targetColumn; set => targetColumn = value; }
    public string TargetTable { get => targetTable; set => targetTable = value; }


    public override string ToString()
    {
        return $"{SourceTable} {SourceColumn} {TargetTable} {TargetColumn} ";
    }
}
