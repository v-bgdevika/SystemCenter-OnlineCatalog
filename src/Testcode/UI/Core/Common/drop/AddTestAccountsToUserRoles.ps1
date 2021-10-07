#########################################
# Add test accounts to user roles.
#########################################

"Adding test accounts to user roles..."

"ReadOnlyOperator: smx\smx_user : Virgo#01"
$momUserRole = get-UserRole | where { $_.Name -eq "OperationsManagerReadOnlyOperators" }
$momUserRole.Users.Add("smx\smx_user");
$momUserRole.Update();

"Operator: smx\momuser : M_user#01"
$momUserRole = get-UserRole | where { $_.Name -eq "OperationsManagerOperators" }
$momUserRole.Users.Add("smx\momuser");
$momUserRole.Update();

"AdvancedOperator: smx\momreporting : M_reporting#01"
$momUserRole = get-UserRole | where { $_.Name -eq "OperationsManagerAdvancedOperators" }
$momUserRole.Users.Add("smx\momreporting");
$momUserRole.Update();

"Author: smx\momauthor : M_author#01"
$momUserRole = get-UserRole | where { $_.Name -eq "OperationsManagerAuthors" }
$momUserRole.Users.Add("smx\momauthor");
$momUserRole.Update();

"Administrator: smx\Momv3 Test Admins"
$momUserRole = get-UserRole | where { $_.Name -eq "OperationsManagerAdministrators" }
$momUserRole.Users.Add("smx\Momv3 Test Admins");
$momUserRole.Update(); 
"Administrator: Remove Builtin\Administrators"
$momUserRole.Users.Remove("BUILTIN\Administrators");
$momUserRole.Update();

"Finished."

