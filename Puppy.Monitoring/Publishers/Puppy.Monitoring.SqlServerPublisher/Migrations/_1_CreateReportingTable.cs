﻿using FluentMigrator;

namespace Puppy.Monitoring.SqlServerPublisher.Migrations
{
    [Migration(1)]
    public class _1_CreateReportingTable : Migration
    {
        private const string tableName = "ReportingEvent";

        public override void Up()
        {
            Create
                .Table(tableName)
                .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
                .WithColumn("PublishedOn").AsDateTime().NotNullable()
                .WithColumn("Year").AsInt16().NotNullable()
                .WithColumn("Month").AsInt16().NotNullable()
                .WithColumn("Day").AsInt16().NotNullable()
                .WithColumn("Hour").AsInt16().NotNullable()
                .WithColumn("Minute").AsInt16().NotNullable()
                .WithColumn("Second").AsInt16().NotNullable()
                .WithColumn("Timestamp").AsInt32().NotNullable()
                .WithColumn("Category").AsString().NotNullable()
                .WithColumn("SubCategory").AsString().Nullable()
                .WithColumn("TookMilliseconds").AsInt32().Nullable()
                .WithColumn("EventType").AsString().Nullable();
        }

        public override void Down()
        {
            Delete
                .Table(tableName);
        }
    }
}