$(_OBJ_DIR)\$(CPUTYPE)\ManagementPackCatalog.Tables.Setup.sql: createTableSql.cmd
	createTableSql.cmd $(_OBJ_DIR)\$(CPUTYPE)\ManagementPackCatalog.Tables.Setup.sql

$(_OBJ_DIR)\$(CPUTYPE)\ManagementPackCatalog.StoredProcedures.Setup.sql: createStoredProcedureSql.cmd
	createStoredProcedureSql.cmd $(_OBJ_DIR)\$(CPUTYPE)\ManagementPackCatalog.StoredProcedures.Setup.sql

$(_OBJ_DIR)\$(CPUTYPE)\ManagementPackCatalog.AdminStoredProcedures.Setup.sql: createAdminStoredProcedureSql.cmd
	createAdminStoredProcedureSql.cmd $(_OBJ_DIR)\$(CPUTYPE)\ManagementPackCatalog.AdminStoredProcedures.Setup.sql


