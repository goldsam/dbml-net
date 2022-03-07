using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using FluentMigrator;
using FluentMigrator.Expressions;

namespace Dbml.FluentMigrator
{
    public class DbmlProcessor : IMigrationProcessor
    {

        Model.Database _model = new Model.Database();

#pragma warning disable CS0612 // Type or member is obsolete
        public IMigrationProcessorOptions Options => throw new NotImplementedException();
#pragma warning restore CS0612 // Type or member is obsolete

        public string ConnectionString => throw new NotImplementedException();

        public string DatabaseType => throw new NotImplementedException();

        public IList<string> DatabaseTypeAliases => throw new NotImplementedException();

        public void BeginTransaction()
        {
        }

        public void CommitTransaction()
        {
        }

        public void RollbackTransaction()
        {
        }


        public bool ColumnExists(string schemaName, string tableName, string columnName)
        {
            if (tableName == null)
            {
                throw new ArgumentNullException(nameof(tableName));
            }

            return _model.Tables.Any(t => string.Equals(t.Name, tableName, StringComparison.OrdinalIgnoreCase)
                && string.Equals(t.Schema?.Name, schemaName, StringComparison.OrdinalIgnoreCase));
        }

        
        public bool ConstraintExists(string schemaName, string tableName, string constraintName)
        {
            return false;
        }

        public bool DefaultValueExists(string schemaName, string tableName, string columnName, object defaultValue)
        {
            return false;
        }

        public void Dispose()
        {
        }

        public void Execute(string sql)
        {
            throw new NotImplementedException();
        }

        public void Execute(string template, params object[] args)
        {
            throw new NotImplementedException();
        }

        public bool Exists(string template, params object[] args)
        {
            throw new NotImplementedException();
        }

        public bool IndexExists(string schemaName, string tableName, string indexName)
        {
            throw new NotImplementedException();
        }

        public void Process(CreateSchemaExpression expression)
        {
            throw new NotImplementedException();
        }

        public void Process(DeleteSchemaExpression expression)
        {
            throw new NotImplementedException();
        }

        public void Process(AlterTableExpression expression)
        {
            throw new NotImplementedException();
        }

        public void Process(AlterColumnExpression expression)
        {
            throw new NotImplementedException();
        }

        public void Process(CreateTableExpression expression)
        {
            throw new NotImplementedException();
        }

        public void Process(CreateColumnExpression expression)
        {
            throw new NotImplementedException();
        }

        public void Process(DeleteTableExpression expression)
        {
            throw new NotImplementedException();
        }

        public void Process(DeleteColumnExpression expression)
        {
            throw new NotImplementedException();
        }

        public void Process(CreateForeignKeyExpression expression)
        {
            throw new NotImplementedException();
        }

        public void Process(DeleteForeignKeyExpression expression)
        {
            throw new NotImplementedException();
        }

        public void Process(CreateIndexExpression expression)
        {
            throw new NotImplementedException();
        }

        public void Process(DeleteIndexExpression expression)
        {
            throw new NotImplementedException();
        }

        public void Process(RenameTableExpression expression)
        {
            throw new NotImplementedException();
        }

        public void Process(RenameColumnExpression expression)
        {
            throw new NotImplementedException();
        }

        public void Process(InsertDataExpression expression)
        {
            throw new NotImplementedException();
        }

        public void Process(AlterDefaultConstraintExpression expression)
        {
            throw new NotImplementedException();
        }

        public void Process(PerformDBOperationExpression expression)
        {
            throw new NotImplementedException();
        }

        public void Process(DeleteDataExpression expression)
        {
            throw new NotImplementedException();
        }

        public void Process(UpdateDataExpression expression)
        {
            throw new NotImplementedException();
        }

        public void Process(AlterSchemaExpression expression)
        {
            throw new NotImplementedException();
        }

        public void Process(CreateSequenceExpression expression)
        {
            throw new NotImplementedException();
        }

        public void Process(DeleteSequenceExpression expression)
        {
            throw new NotImplementedException();
        }

        public void Process(CreateConstraintExpression expression)
        {
            throw new NotImplementedException();
        }

        public void Process(DeleteConstraintExpression expression)
        {
            throw new NotImplementedException();
        }

        public void Process(DeleteDefaultConstraintExpression expression)
        {
            throw new NotImplementedException();
        }

        public DataSet Read(string template, params object[] args)
        {
            throw new NotImplementedException();
        }

        public DataSet ReadTableData(string schemaName, string tableName)
        {
            throw new NotImplementedException();
        }

        

        public bool SchemaExists(string schemaName)
        {
            throw new NotImplementedException();
        }

        public bool SequenceExists(string schemaName, string sequenceName)
        {
            throw new NotImplementedException();
        }

        public bool TableExists(string schemaName, string tableName)
        {
            throw new NotImplementedException();
        }
    }
}
