using Karkas.Examples;

TestHelperMultiTenant.TestTenantsAreIsolated();
TestHelperMultiTenant.TestTenantIdIsCaseInsensitive();
TestHelperMultiTenant.TestTransactionCommitStaysInTenant();
TestHelperMultiTenant.TestTransactionRollbackInTenant();
TestHelperMultiTenant.TestGuidTenant();
TestHelperMultiTenant.TestInvalidAndUnknownTenants();

Console.WriteLine("All multi tenant tests passed");
