﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Microsoft.EntityFrameworkCore.Query.Relationships.Projection;

public abstract class OwnedReferenceNoTrackingProjectionRelationalTestBase<TFixture>(TFixture fixture)
    : OwnedReferenceNoTrackingProjectionTestBase<TFixture>(fixture)
        where TFixture : OwnedRelationshipsRelationalFixtureBase, new()
{
}
