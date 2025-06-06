// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore.TestModels.TransportationModel;

namespace Microsoft.EntityFrameworkCore;

#nullable disable

public class TableSplittingSqliteTest(NonSharedFixture fixture, ITestOutputHelper testOutputHelper) : TableSplittingTestBase(fixture, testOutputHelper)
{
    public override async Task ExecuteUpdate_works_for_table_sharing(bool async)
    {
        await base.ExecuteUpdate_works_for_table_sharing(async);

        AssertSql(
            """
@p='1'

UPDATE "Vehicles" AS "v"
SET "SeatingCapacity" = @p
""",
            //
            """
SELECT NOT EXISTS (
    SELECT 1
    FROM "Vehicles" AS "v"
    WHERE "v"."SeatingCapacity" <> 1)
""");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Engine>().ToTable("Vehicles")
            .Property(e => e.Computed).HasComputedColumnSql("1");
    }

    protected override ITestStoreFactory TestStoreFactory
        => SqliteTestStoreFactory.Instance;
}
