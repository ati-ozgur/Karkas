namespace Karkas.Data;

/// <summary>
/// How GetRows writes column names as dictionary keys.
/// </summary>
public enum ColumnNameCase
{
	/// <summary>Column names as returned by the database.</summary>
	AsItIs = 0,
	/// <summary>Column names converted to lower case (invariant culture).</summary>
	ToLower = 1,
	/// <summary>Column names converted to upper case (invariant culture).</summary>
	ToUpper = 2,
}
