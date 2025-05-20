namespace Karkas.Examples.Chinook.Dal;

public partial class EmployeeDal
{
	public DateTime GetBirthDate(int employeeId)
	{
		string sql = @"SELECT ""BirthDate""
		FROM ""Employee"" WHERE ""EmployeeId"" = :employeeId";
		var pb = getParameterBuilder();
		pb.AddParameter(":employeeId", employeeId);
		return Template.GetOneValue<DateTime>(sql,pb.GetParameterArray());
	}
}

