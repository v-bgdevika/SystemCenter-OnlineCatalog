#########################################
# Remove test accounts from user roles.
#########################################

"Remove test accounts from user roles..."

"ReadOnlyOperator: smx\smx_user : Virgo#01"
$momUserRole = get-UserRole | where { $_.Name -eq "OperationsManagerReadOnlyOperators" }
$momUserRole.Users.Remove("smx\smx_user");
$momUserRole.Update();

"Operator: smx\momuser : M_user#01"
$momUserRole = get-UserRole | where { $_.Name -eq "OperationsManagerOperators" }
$momUserRole.Users.Remove("smx\momuser");
$momUserRole.Update();

"AdvancedOperator: smx\momreporting : M_reporting#01"
$momUserRole = get-UserRole | where { $_.Name -eq "OperationsManagerAdvancedOperators" }
$momUserRole.Users.Remove("smx\momreporting");
$momUserRole.Update();

"Author: smx\momauthor : M_author#01"
$momUserRole = get-UserRole | where { $_.Name -eq "OperationsManagerAuthors" }
$momUserRole.Users.Remove("smx\momauthor");
$momUserRole.Update();

"Finished."

